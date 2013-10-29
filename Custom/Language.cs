using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Globalization
{
    [Data.Metadata.Enum("36f767d8-e037-4064-a18e-c4c662efa3af")]
    public class Language
    {
        public Guid id { get; set; }

        public string Code { get; set; }

        public Text Text { get; set; }
    }
}