using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Globalization.Models
{
    public class Text
    {
        public string Id
        {
            get;
            set;
        }

        public string Language
        {
            get;
            set;
        }

        public string Locale
        {
            get;
            set;
        }

        /// <summary>
        /// Lating, Cyrilic, etc.
        /// </summary>
        public string Script
        {
            get;
            set;
        }

        public bool Plural
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }
}