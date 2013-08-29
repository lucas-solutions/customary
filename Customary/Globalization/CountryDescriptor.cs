using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Globalization
{
    public class CountryDescriptor : RegionDescriptor
    {
        /// <summary>
        /// Official currency
        /// </summary>
        public string Currency
        {
            get;
            set;
        }
    }
}