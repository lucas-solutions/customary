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
    partial class ScriptFunction
    {
        private Serializer _serializer;

        public Serializer ToSerializer()
        {
            return _serializer ?? (_serializer = new Serializer(this));
        }

        public class Serializer : IScriptSerializer
        {
            private ScriptFunction _fn;
            private Func<string[]> _render;

            public Serializer(ScriptFunction fn)
            {
                _fn = fn;
            }

            public TSerializer Cast<TSerializer>()
                where TSerializer : class, IScriptSerializer
            {
                return this as TSerializer;
            }

            public Serializer Override(Func<string[]> render)
            {
                _render = render;
                return this;
            }

            public string[] Render()
            {
                return _render != null ? _render() : null;
            }

            public void Serialize(TextWriter writer)
            {
                if (_render != null)
                {
                    var script = Render();
                    if (script != null)
                        foreach (var line in script)
                            writer.WriteLine(line);
                }
            }
        }
    }
}