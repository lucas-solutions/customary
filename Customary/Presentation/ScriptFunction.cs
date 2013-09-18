using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public partial class ScriptFunction : IScriptable
    {
        private Action<List<string>> _render;

        public ScriptFunction Override(Action<List<string>> render)
        {
            _render = render;
            return this;
        }

        public void Render(List<string> lines)
        {
            if (_render != null)
                _render(lines);
        }

        public void Write(TextWriter writer)
        {
            var lines = new List<string>();
            Render(lines);
            writer.WriteAllLines(lines);
        }
    }
}