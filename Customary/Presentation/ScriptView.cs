using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Custom.Presentation
{
    public partial class ScriptView : IScriptable
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
            get { return _viewName; }
            set { _viewName = value; }
        }

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

        public void Naked(List<string> lines)
        {
            var first = lines.Count;
            Render(lines);
            Strip(lines, first, lines.Count - 1);
        }

        public void NakedFn(List<string> lines)
        {
            string name;
            NameValueCollection attributes;
            NakedFn(lines, out name, out attributes);
        }

        public void NakedFn(List<string> lines, out string name, out NameValueCollection attributes)
        {
            const string function = "function";

            name = null;

            attributes = new NameValueCollection();

            var first = lines.Count;
            Render(lines);
            Strip(lines, first, lines.Count - 1, attributes);

            if (lines != null && lines.Count > 0)
            {
                var line = (lines[0] ?? string.Empty);
                var padding = line.IndexOf(function);
                if (padding < 0)
                {
                    // log error
                    return;
                }

                var paramsIndex = line.IndexOf('(', padding + function.Length);
                if (paramsIndex < 0)
                {
                    // log error
                }

                name = line.Substring(padding + function.Length, paramsIndex - (padding + function.Length)).Trim();
                lines[0] = string.Concat(function, ' ', line.Substring(paramsIndex));
                for (var i = 1; padding > 0 && i < lines.Count; i++)
                {
                    if (string.IsNullOrEmpty(lines[i]))
                        continue;

                    if (string.IsNullOrWhiteSpace(lines[i].Substring(0, padding)))
                        lines[i] = lines[i].Substring(padding);
                    else
                        lines[i] = lines[i].TrimStart();
                }
            }
        }

        public static void Strip(List<string> lines, int first, int last, NameValueCollection attributes = null)
        {
            int tagIndex = -1;
            for (var i = 0; i < lines.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    first = i + 1;
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

            for (var i = lines.Count - 1; i >= first; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    last = i - 1;
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

            var length = last - first + 1;
            lines.RemoveRange(last + 1, lines.Count - last - 1);
            lines.RemoveRange(0, first);
        }

        public void Render(List<string> lines)
        {
            using (var input = new StringReader(ToString()))
            {
                for (var line = input.ReadLine(); line != null; line = input.ReadLine())
                    lines.Add(string.IsNullOrWhiteSpace(line) ? string.Empty : line.TrimEnd());
            }
        }

        public void Write(System.IO.TextWriter writer)
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

        public override string ToString()
        {
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                Write(writer);
            }
            return sb.ToString();
        }
    }
}