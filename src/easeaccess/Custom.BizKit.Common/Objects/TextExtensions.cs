using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Objects
{
    public static class TextExtensions
    {
        public static TextObject Select(this List<TextObject> list, CultureInfo culture)
        {
            return list.SingleOrDefault(o => o.Culture ==  culture.Name);
        }
    }
}
