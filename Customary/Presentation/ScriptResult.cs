using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Custom.Presentation
{
    public class ScriptResult : ActionResult
    {
        private readonly IScriptable _scriptable;
        private TempDataDictionary _tempData;
        private ViewDataDictionary _viewData;
        private IView _view;
        private ViewEngineCollection _viewEngineCollection;
        
        public ScriptResult(IScriptable scriptable)
        {
            _scriptable = scriptable;
        }

        public TempDataDictionary TempData
        {
            get { return _tempData ?? (_tempData = new TempDataDictionary()); }
            set { _tempData = value; }
        }

        public ViewDataDictionary ViewData
        {
            get { return _viewData ?? (_viewData = new ViewDataDictionary()); }
            set { _viewData = value; }
        }

        public ViewEngineCollection ViewEngineCollection
        {
            get { return (_viewEngineCollection ?? (_viewEngineCollection = ViewEngines.Engines)); }
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var response = context.HttpContext.Response ?? context.RequestContext.HttpContext.Response;

            response.ContentType = "text/javascript";

            _scriptable.WriteTo(response.Output);
        }
    }
}