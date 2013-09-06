using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Custom.Presentation
{
    public abstract class ScriptBuilder
    {
        public static implicit operator MvcHtmlString (ScriptBuilder builder)
        {
            return builder != null ? new MvcHtmlString(builder.ToString()) : null;
        }

        public virtual ScriptResult Result()
        {
            return new ScriptResult(this);
        }

        public abstract void Write(TextWriter writer);

        public override string ToString()
        {
            var sb = new StringBuilder();
            using (var output = new StringWriter(sb))
            {
                var writer = new ScriptWriter(output);
                Write(writer);
            }
            return sb.ToString();
        }
    }
}