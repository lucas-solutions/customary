using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    partial class Scriptable
    {
        public class Serializer : IScriptSerializer
        {
            private Func<string[]> _render;

            public Serializer Override(Func<string[]> render)
            {
                _render = render;
                return this;
            }

            public virtual string[] Render()
            {
                string[] lines;
                TryRender(out lines);
                return lines;
            }

            public virtual void Serialize(TextWriter writer)
            {
                var script = Render();
                if (script != null)
                    foreach (var line in script)
                        writer.WriteLine(line);
            }

            protected virtual bool TryRender(out string[] lines)
            {
                lines = _render != null ? _render() : null;
                return lines != null;
            }
        }
    }
}