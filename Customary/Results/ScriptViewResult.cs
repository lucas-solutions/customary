using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Custom.Results
{
    using Custom.Site.Presentation;

    public partial class ScriptViewResult : ActionResult, IScriptable, IHtmlString
    {
        private object _model;
        private string _viewName;
        private ControllerContext _controllerContext;
        private TempDataDictionary _tempData;
        private IView _view;
        private ViewDataDictionary _viewData;
        private ViewEngineCollection _viewEngineCollection;

        public object Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public string ViewName
        {
            get
            {
                if (string.IsNullOrEmpty(_viewName) && _controllerContext != null)
                {
                    var areaName = _controllerContext.RouteData.Values["area"];
                    var controllerName = _controllerContext.RouteData.Values["controller"];
                    var actionName = _controllerContext.RouteData.Values["action"];

                    var viewName = areaName != null
                        ? string.Format("~/Areas/{0}/Views/{1}/{2}.cshtml", areaName, controllerName, actionName)
                        : string.Format("~/Views/{0}/{1}.cshtml", controllerName, actionName);

                    _viewName = viewName;// _controllerContext.RouteData.Values["action"] as string;
                }

                return _viewName;
            }
            set { _viewName = value; }
        }

        public ControllerContext ControllerContext
        {
            get { return _controllerContext ?? (_controllerContext = new ControllerContext()); }
            set { _controllerContext = value; }
        }

        public virtual bool Direct
        {
            get { return !(Strip || TrimLeft); }
            set { Strip = TrimLeft = false; }
        }

        public bool Strip
        {
            get;
            set;
        }

        public bool TrimLeft
        {
            get;
            set;
        }

        public TempDataDictionary TempData
        {
            get { return _tempData ?? (_tempData = new TempDataDictionary()); }
            set { _tempData = value; }
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

        public ViewEngineCollection ViewEngineCollection
        {
            get { return (_viewEngineCollection ?? (_viewEngineCollection = ViewEngines.Engines)); }
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response ?? context.RequestContext.HttpContext.Response;

            response.ContentType = "text/javascript";

            var strip = Strip;
            Strip = true;
            Write(context, response.Output);
            Strip = strip;
        }

        public static void Unbox(List<string> lines, int first, int count, NameValueCollection attributes = null)
        {
            int last = first + count - 1;
            int first0 = first, last0 = last; 
            
            int tagIndex = -1;
            for (var i = first; i < last; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    lines[i] = string.Empty;
                    first = i + 1;
                }
                else
                {
                    var line = lines[i].Trim().ToLower();
                    if (line.StartsWith("<script"))
                    {
                        tagIndex = i;
                        first = i + 1;
                    }
                    else break;
                }
            }

            for (var i = last; i > first; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    lines[i] = string.Empty;
                    last = i - 1;
                }
                else
                {
                    var line = lines[i].Trim().ToLower();
                    if (line.StartsWith("</script"))
                        last = i - 1;
                    break;
                }
            }

            if (attributes != null && tagIndex > -1)
            {
                var xml = lines[tagIndex].Trim();
                using (var sr = new StringReader(xml))
                {
                    var reader = XmlTextReader.Create(sr);
                    if (reader.Read() && reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.MoveToFirstAttribute())
                        {
                            attributes.Add(reader.Name, reader.Value);
                            while (reader.MoveToNextAttribute())
                            {
                                attributes.Add(reader.Name, reader.Value);
                            }
                        }

                        if (reader.IsStartElement())
                        {
                        }
                    }
                }
            }

            if (last < last0)
                lines.RemoveRange(last + 1, last0 - last);

            if (first > first0)
                lines.RemoveRange(first0, first - first0);
        }

        public virtual void Render(List<string> lines)
        {
            if (!Strip && !TrimLeft)
                lines.Add(ToString());
            else
            {
                var first = lines.Count;
                using (var input = new StringReader(ToString()))
                {
                    for (var line = input.ReadLine(); line != null; line = input.ReadLine())
                        lines.Add(string.IsNullOrWhiteSpace(line) ? string.Empty : line.TrimEnd());
                }

                if (Strip)
                    Unbox(lines, first, lines.Count - first);

                if (TrimLeft)
                    lines.TrimLeft(first, lines.Count - 1);
            }
        }

        protected void WriteDirect(TextWriter writer)
        {
            ViewEngineResult result = null;

            if (_view == null)
            {
                result = ViewEngineCollection.FindPartialView(ControllerContext, ViewName);
                _view = result.View;
            }

            ViewData.Model = Model;

            var viewContext = new ViewContext(ControllerContext, _view, ViewData, TempData, writer);
            _view.Render(viewContext, writer);

            if (result != null)
            {
                result.ViewEngine.ReleaseView(ControllerContext, _view);
            }
        }

        public void Write(TextWriter writer)
        {
            if (Direct)
                WriteDirect(writer);
            else
            {
                var lines = new List<string>();
                Render(lines);
                writer.WriteAllLines(lines);
            }
        }

        public void Write(ControllerContext context, TextWriter writer)
        {
            _controllerContext = context ?? _controllerContext;

            Write(writer);
        }

        public string ToHtmlString()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            using (var writer = new StringWriter(CultureInfo.InvariantCulture))
            {
                WriteDirect(writer);
                return writer.ToString();
            }
        }

        public class Builder : Builder<ScriptViewResult, Builder>
        {
            public static implicit operator ScriptViewResult(Builder builder)
            {
                return builder != null ? builder.ToModel() : null;
            }
            
            public Builder()
                : base(new ScriptFunction())
            {
            }

            public Builder(ScriptViewResult model)
                : base(model ?? new ScriptViewResult())
            {
            }
        }

        public abstract class Builder<TModel, TBuilder>
            where TModel : ScriptViewResult
            where TBuilder : Builder<TModel, TBuilder>
        {
            private readonly TModel _model;

            protected Builder(TModel model)
            {
                _model = model;
            }

            public TBuilder Model(object value)
            {
                ToModel().Model = value;
                return (TBuilder)this;
            }

            public TBuilder Strip(bool value = true)
            {
                ToModel().Strip = value;
                return (TBuilder)this;
            }

            public TBuilder TrimLeft(bool value = true)
            {
                ToModel().TrimLeft = value;
                return (TBuilder)this;
            }

            public TModel ToModel()
            {
                return _model;
            }
        }
    }
}