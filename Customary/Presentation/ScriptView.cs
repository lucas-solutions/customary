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
    public class ScriptView
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

        public object Model
        {
            get { return _model; }
            set { _model = value; }
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

        public string ViewName
        {
            get { return _viewName; }
            set { _viewName = value; }
        }

        public ViewEngineCollection ViewEngineCollection
        {
            get { return (_viewEngineCollection ?? (_viewEngineCollection = ViewEngines.Engines)); }
        }

        public string[] Naked()
        {
            return Strip(Render());
        }

        public string[] NakedFn()
        {
            string name;
            NameValueCollection attributes;
            return NakedFn(out name, out attributes);
        }

        public string[] NakedFn(out string name, out NameValueCollection attributes)
        {
            const string function = "function";

            name = null;

            attributes = new NameValueCollection();
            var output = Strip(Render(), attributes);

            if (output != null && output.Length > 0)
            {
                var line = (output[0] ?? string.Empty);
                var padding = line.IndexOf(function);
                if (padding < 0)
                {
                    // log error
                    return output;
                }

                var paramsIndex = line.IndexOf('(', padding + function.Length);
                if (paramsIndex < 0)
                {
                    // log error
                    return output;
                }

                name = line.Substring(padding + function.Length, paramsIndex - (padding + function.Length)).Trim();
                output[0] = string.Concat(function, ' ', line.Substring(paramsIndex));
                for (var i = 1; padding > 0 && i < output.Length; i++)
                {
                    if (string.IsNullOrEmpty(output[i]))
                        continue;

                    if (string.IsNullOrWhiteSpace(output[i].Substring(0, padding)))
                        output[i] = output[i].Substring(padding);
                    else
                        output[i] = output[i].TrimStart();
                }
            }

            return output;
        }

        public static string[] Strip(string[] input, NameValueCollection attributes = null)
        {
            int first = 0, last = input.Length - 1, tagIndex = -1;
            for (var i = 0; i < input.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(input[i]))
                    first = i + 1;
                else
                {
                    var line = input[i].Trim().ToLower();
                    if (line.StartsWith("<script"))
                    {
                        tagIndex = i;
                        first = i + 1;
                    }
                    else break;
                }
            }

            for (var i = input.Length - 1; i >= first; i++)
            {
                if (string.IsNullOrWhiteSpace(input[i]))
                    last = i - 1;
                else
                {
                    var line = input[i].Trim().ToLower();
                    if (line.StartsWith("</script"))
                        last = i - 1;
                    break;
                }
            }

            if (attributes != null && tagIndex > -1)
            {
                var xml = input[tagIndex].Trim();
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
            var output = new string[length];

            Array.Copy(input, first, output, 0, length);

            return output;
        }

        public string[] Render()
        {
            var lines = new List<string>();
            using (var input = new StringReader(ToString()))
            {
                for (var line = input.ReadLine(); line != null; line = input.ReadLine())
                    lines.Add(string.IsNullOrWhiteSpace(line) ? string.Empty : line.TrimEnd());
            }
            return lines.ToArray();
        }

        public void Render(TextWriter writer)
        {
            ViewEngineResult result = null;

            if (_view == null)
            {
                result = ViewEngineCollection.FindPartialView(ControllerContext, ViewName);
                _view = result.View;
            }

            ViewData.Model = Model;

            var viewContext = new ViewContext(ControllerContext, View, ViewData, TempData, writer);
            _view.Render(viewContext, writer);

            if (result != null)
            {
                result.ViewEngine.ReleaseView(ControllerContext, View);
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