using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace Custom.Objects
{
    public class TextObject : Dictionary<string, string>
    {
        static readonly CultureInfo DefaultCulture = new CultureInfo("en");

        public override string ToString()
        {
            string text = null;
            var culture = Thread.CurrentThread.CurrentCulture;
            while (culture != null && !TryGetValue(culture.Name, out text))
            {
                if (culture.Parent != null && culture.Parent != culture)
                    culture = culture.Parent;
                else if (culture.Name != DefaultCulture.Name)
                    culture = DefaultCulture;
                else
                    culture = null;
            }
            return text;
        }
    }
}