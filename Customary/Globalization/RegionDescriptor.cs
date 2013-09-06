using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Globalization
{
    using Custom.Metadata;

    public class RegionDescriptor
    {
        public Guid ID { get; set; }

        public string Code { get; set; }

        public TextObject Title { get; set; }

        /// <summary>
        /// Official language
        /// </summary>
        public string Language { get; set; }
    }
}