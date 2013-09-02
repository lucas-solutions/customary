using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Transforms
{
    public static class StringsTransforms
    {
        public static string ToHtmlList(this IEnumerable<string> items, string tag = "ul")
        {
            return string.Concat("<", tag, ">", items.Select(o => string.Concat("<li>", o, "</li>")), "</", tag, ">");
        }
    }
}
