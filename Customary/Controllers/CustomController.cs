using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    public abstract class CustomController : Controller
    {
        private readonly NameValueCollection _queryString;
        private readonly string _redirectParam;
        private readonly CookieRepository _identification = new CookieRepository(System.Web.HttpContext.Current, TimeSpan.FromMinutes(30));
        private readonly CookieRepository _customizations = new CookieRepository(System.Web.HttpContext.Current, TimeSpan.FromDays(30), true, true);
        private readonly CookieRepository _globalizations = new CookieRepository(System.Web.HttpContext.Current, TimeSpan.FromDays(30), true, true, true);

        public CustomController()
        {
            _queryString = new NameValueCollection(System.Web.HttpContext.Current.Request.QueryString);
        }

        protected CustomController(string redirectName)
            : this()
        {
            string redirectValue;
            if (_queryString.TryGetQueryNameValue(ref redirectName, out redirectValue))
            {
                var requestUrl = HttpUtility.UrlDecode(System.Web.HttpContext.Current.Request.Url.OriginalString);
                var redirectIndex = GetQueryParamIndex(requestUrl, redirectName);

                redirectValue = requestUrl.Substring(requestUrl.IndexOf('=', redirectIndex) + 1).Trim();

                var redirectQuery = HttpUtility.ParseQueryString(new Uri(redirectValue).Query);
                var requestQuery = HttpUtility.ParseQueryString(new Uri(requestUrl.Substring(0, requestUrl.Substring(0, redirectIndex).LastIndexOfAny(new[] { '?', '&' }))).Query);

                _queryString = new NameValueCollection();
                foreach (var param in requestQuery.AllKeys)
                    _queryString[param] = requestQuery[param];

                _queryString[redirectName] = redirectValue;
            }
            _redirectParam = redirectName;
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
    }
}