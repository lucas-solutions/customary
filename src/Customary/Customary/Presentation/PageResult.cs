using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Custom.Presentation
{
    public class PageResult : ActionResult
    {
        private TempDataDictionary _tempData;
        private ViewDataDictionary _viewData;
        private System.Web.Mvc.ViewEngineCollection _viewEngineCollection;
        private string _viewName;

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(this.ViewName))
            {
                ViewName = context.RouteData.GetRequiredString("action");
            }
            ViewEngineResult result = null;
            if (View == null)
            {
                result = ViewEngineCollection.FindView(context, ViewName, null);
                View = result.View;
            }
            /*var output = context.HttpContext.Response.Output;
            var viewContext = new ViewContext(context, View, ViewData, TempData, output);
            View.Render(viewContext, output);*/

            var sb = new StringBuilder();
            using (var output = new StringWriter(sb))
            {
                var viewContext = new ViewContext(context, View, ViewData, TempData, output);
                View.Render(viewContext, output);
            }
            
            if (result != null)
            {
                result.ViewEngine.ReleaseView(context, View);
            }

            using (var input = new StringReader(sb.ToString()))
            {
                var source = XDocument.Load(input).Nodes().Select(o => o.ToString()).FirstOrDefault();

                context.HttpContext.Response.Output.Write(source);
            }

            // transform

            context.HttpContext.Response.Output.Write(sb.ToString());

            context.RequestContext.HttpContext.Response.ContentType = "text/javascript";
        }

        private ViewEngineResult FindView(ControllerContext context)
        {
            var result = ViewEngineCollection.FindPartialView(context, ViewName);
            if (result.View != null)
            {
                return result;
            }
            var builder = new StringBuilder();
            foreach (string str in result.SearchedLocations)
            {
                builder.AppendLine();
                builder.Append(str);
            }
            throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Page Not Found", new object[] { ViewName, builder }));
        }

        public object Model
        {
            get { return this.ViewData.Model; }
        }

        public TempDataDictionary TempData
        {
            get { return _tempData ?? (_tempData = new TempDataDictionary()); }
            set { this._tempData = value; }
        }

        public IView View
        {
            get;
            set;
        }

        public ViewDataDictionary ViewData
        {
            get { return _viewData ?? (_viewData = new ViewDataDictionary()); }
            set { _viewData = value; }
        }

        public System.Web.Mvc.ViewEngineCollection ViewEngineCollection
        {
            get { return (_viewEngineCollection ?? ViewEngines.Engines); }
            set { _viewEngineCollection = value; }
        }

        public string ViewName
        {
            get { return (_viewName ?? string.Empty); }
            set { _viewName = value; }
        }
    }
}