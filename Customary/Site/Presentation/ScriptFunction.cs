using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

namespace Custom.Site.Presentation
{
    using Custom.Results;
    
    public class ScriptFunction : ScriptViewResult
    {
        public override bool Direct
        {
            get { return !(Strip || TrimLeft || Anonimous); }
            set { Anonimous = Strip = TrimLeft = false; }
        }

        public bool Anonimous
        {
            get;
            set;
        }

        public void Anonimize(List<string> lines)
        {
            string name;
            NameValueCollection attributes;
            Anonimize(lines, out name, out attributes);
        }

        public void Anonimize(List<string> lines, out string name, out NameValueCollection attributes)
        {
            const string function = "function";

            name = null;

            attributes = new NameValueCollection();

            var first = lines.Count;
            base.Render(lines);
            Unbox(lines, first, lines.Count - first, attributes);
            lines.TrimLeft();

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
            }
        }

        public override void Render(List<string> lines)
        {
            if (Anonimous)
                Anonimize(lines);
            else
                base.Render(lines);
        }

        public new class Builder : Builder<ScriptFunction, Builder>
        {
            public static implicit operator ScriptFunction(Builder builder)
            {
                return builder != null ? builder.ToModel() : null;
            }

            public Builder()
                : base(new ScriptFunction())
            {
            }

            public Builder(ScriptFunction model)
                : base(model ?? new ScriptFunction())
            {
            }

            public Builder Anonimous()
            {
                ToModel().Anonimous = true;
                return this;
            }
             
            public Builder Anonimous(bool value)
            {
                ToModel().Anonimous = false;
                return this;
            }
        }
    }
}