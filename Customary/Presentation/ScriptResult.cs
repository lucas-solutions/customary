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
            
            var output = response.Output;
            if (string.IsNullOrEmpty(_scriptable.Template))
            {
                var writer = new ScriptWriter();
                _scriptable.Script(writer);
                writer.WriteTo(output);
            }
            else
            {
                ViewEngineResult result = null;

                if (_view == null)
                {
                    result = ViewEngineCollection.FindView(context, _scriptable.Template, null);
                    _view = result.View;
                }

                var sb = new StringBuilder();
                using (var sw = new StringWriter(sb))
                {
                    var viewContext = new ViewContext(context, _view, ViewData, TempData, sw);
                    _view.Render(viewContext, sw);
                }

                if (result != null)
                {
                    result.ViewEngine.ReleaseView(context, _view);
                }

                using (var input = new StringReader(sb.ToString()))
                {
                    var source = XDocument.Load(input).Nodes().Select(o => o.ToString()).FirstOrDefault();

                    output.Write(source);
                }
            }
        }
    }
}