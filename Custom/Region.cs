using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom
{
    [Data.Metadata.Complex("e9b74aaf-034a-4fed-be5f-c2522af5daef")]
    public sealed class Region
    {
        public Guid id { get; set; }

        public string Code { get; set; }

        public Text Name { get; set; }

        public string Parent { get; set; }

        /// <summary>
        /// Official language
        /// </summary>
        public string Language { get; set; }
    }
}