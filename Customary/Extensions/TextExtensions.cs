using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom
{
    using global::Raven.Json.Linq;

    public static class TextExtensions
    {
        public static void SetCurrentThreadCultureText(this RavenJObject target, string name, Dictionary<string, string> text)
        {
            if (text != null)
            {
                for (var culture = System.Threading.Thread.CurrentThread.CurrentCulture; !string.IsNullOrEmpty(culture.Name); culture = culture.Parent)
                {
                    string value;
                    if (text.TryGetValue(culture.Name, out value))
                    {
                        var text2 = new RavenJObject();
                        text2[culture.Name] = value;
                        target[name] = text2;
                        return;
                    }
                }
            }
        }
    }
}