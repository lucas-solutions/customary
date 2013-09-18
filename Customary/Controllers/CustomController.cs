using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Diagnostics;
    using Custom.Filters;
    using Custom.Models;
    using Custom.Presentation;
    using System.Web.Routing;

    [Diagnostics(Category="Controller", Instance="Custom")]
    public abstract class CustomController : Controller
    {
        private readonly NameValueCollection _queryString;
        private readonly string _redirectParam;
        private readonly Uri _redirectUri;
        private ControllerLog _log;
        private readonly CookieRepository _identification = new CookieRepository(System.Web.HttpContext.Current, TimeSpan.FromMinutes(30));
        private readonly CookieRepository _customizations = new CookieRepository(System.Web.HttpContext.Current, TimeSpan.FromDays(30), true, true);
        private readonly CookieRepository _globalizations = new CookieRepository(System.Web.HttpContext.Current, TimeSpan.FromDays(30), true, true, true);

        public CustomController()
        {
            var logger = Global.Container.GetInstance<ILogger>();
            _queryString = new NameValueCollection(System.Web.HttpContext.Current.Request.QueryString);
        }

        protected CustomController(string redirectName)
            : this()
        {
            var request = System.Web.HttpContext.Current.Request;
            try
            {
                string redirectValue;
                if (_queryString.TryGetQueryNameValue(ref redirectName, out redirectValue))
                {
                    var requestUri = request.Url;
                    var requestUrl = HttpUtility.UrlDecode(requestUri.OriginalString);
                    var redirectIndex = GetQueryParamIndex(requestUrl, redirectName);

                    redirectValue = requestUrl.Substring(requestUrl.IndexOf('=', redirectIndex) + 1).Trim();

                    _queryString = HttpUtility.ParseQueryString(new Uri(requestUrl.Substring(0, requestUrl.Substring(0, redirectIndex).LastIndexOfAny(new[] { '?', '&' }))).Query);
                    _queryString[redirectName] = redirectValue;

                    if (Uri.TryCreate(redirectValue, UriKind.RelativeOrAbsolute, out _redirectUri))
                    {
                        if (!_redirectUri.IsAbsoluteUri)
                        {
                            var appPath = request.Url.GetLeftPart(UriPartial.Scheme | UriPartial.Authority) + request.ApplicationPath;
                            var appUri = new Uri(appPath, UriKind.Absolute);
                            _redirectUri = new Uri(appUri, _redirectUri);
                        }

                        var redirectQuery = HttpUtility.ParseQueryString(_redirectUri.Query);

                        foreach (var key in redirectQuery.AllKeys)
                        {
                            string value, name = key;
                            if (!_queryString.TryGetQueryNameValue(ref name, out value))
                                _queryString[key] = redirectQuery[key];
                            else if (_queryString[name] != redirectQuery[key])
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Message("Error parsing redirectionUrl").Error(e).Category(LogCategories.Error);
            }
            _redirectParam = redirectName;
        }

        public SimpleInjector.Container Container
        {
            get { return Global.Container; }
        }

        protected CookieRepository Identification
        {
            get { return _identification; }
        }

        protected CookieRepository Customizations
        {
            get { return _customizations; }
        }

        protected CookieRepository Globalizations
        {
            get { return _customizations; }
        }

        public ControllerLog Log
        {
            get { return _log ?? (_log = Global.Logger.Log<ControllerLog>()); }
            set { _log = value; }
        }

        public NameValueCollection QueryString
        {
            get { return _queryString; }
        }

        public string RedirectParam
        {
            get { return _redirectParam; }
        }

        private int GetQueryParamIndex(string url, string queryParam)
        {
            int index, len = queryParam.Length;
            for (index = url.IndexOf('?'); index > 0; index = url.IndexOf('&', index))
            {
                for (index++; char.IsWhiteSpace(url[index]); index++) ;

                if (url.Length < index + len)
                {
                    index = -1;
                    break;
                }

                if (string.Equals(queryParam, url.Substring(index, len), StringComparison.InvariantCultureIgnoreCase))
                {
                    var equalIndex = url.IndexOf('=', index + len);
                    if (equalIndex == index + len || url.Substring(index + len, equalIndex - (index + len)).Trim().Length.Equals(0))
                        break;
                }
            }
            return index;
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            Log.Request(requestContext);
            var result = base.BeginExecute(requestContext, callback, state);
            //_log.Controller(this);
            return result;
        }

        protected override void EndExecute(IAsyncResult asyncResult)
        {
            base.EndExecute(asyncResult);
            _log.Send();
        }

        static readonly string[] Framework = new[] {
            "JQuery",
            "IE",
            "Mobile",
            "Knockout",
            "AngularJs",
            "ExtJs"
        };

        protected internal virtual PageResult Page(string viewName, string layout, object model)
        {
            if (model != null)
            {
                base.ViewData.Model = new PageModel
                {
                    Title = ViewBag.Title,
                    Main = viewName,
                };
            }
            return new PageResult { ViewName = viewName, TempData = base.TempData, ViewEngineCollection = this.ViewEngineCollection };
        }
    }
}