using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Documents
{
    public class GlobalizationCountry : GlobalizationRegion
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