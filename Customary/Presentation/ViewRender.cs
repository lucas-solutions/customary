using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Custom.Presentation
{
    public class ViewRender
    {
        private ControllerContext _controllerContext;
        private object _model;
        private TempDataDictionary _tempData;
        private IView _view;
        private ViewDataDictionary _viewData;
        private string _viewName;
        private ViewEngineCollection _viewEngineCollection;

        public ControllerContext ControllerContext
        {
            get { return _controllerContext; }
            set { _controllerContext = value; }
        }

        public TempDataDictionary TempData
        {
            get { return _tempData ?? (_tempData = new TempDataDictionary()); }
            set { _tempData = value; }
        }

        public object Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public IView View
        {
            get { return _view; }
            set { _view = value; }
        }

        public ViewDataDictionary ViewData
        {
            get { return _viewData ?? (_viewData = new ViewDataDictionary()); }
            set { _viewData = value; }
        }

        public string ViewName
        {
            get { return _viewName; }
            set { _viewName = value; }
        }

        public ViewEngineCollection ViewEngineCollection
        {
            get { return (_viewEngineCollection ?? (_viewEngineCollection = ViewEngines.Engines)); }
        }

        public string[] Render()
        {
            var lines = new List<string>();
            using (var input = new StringReader(ToString()))
            {
                for (var line = input.ReadLine(); line != null; line = input.ReadLine())
                    lines.Add(line);
            }
            return lines.ToArray();
        }

        public void Render(TextWriter writer)
        {
            var context = ControllerContext;

            ViewEngineResult result = null;

            if (_view == null)
            {
                result = ViewEngineCollection.FindView(context, ViewName, null);
                _view = result.View;
            }

            var viewContext = new ViewContext(context, _view, ViewData, TempData, writer);
            _view.Render(viewContext, writer);

            if (result != null)
            {
                result.ViewEngine.ReleaseView(context, _view);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                Render(writer);
            }
            return sb.ToString();
        }
    }
}