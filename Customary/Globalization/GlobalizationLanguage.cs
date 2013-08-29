using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Globalization
{
    using Custom.Metadata;

    public class LanguageDescriptor
    {
        public string Code { get; set; }

        public TextObject Text { get; set; }
    }
}