using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Globalization
{
    using Custom.Metadata;

    public class CurrencyDescriptor : MeasurementDescriptor
    {
        public string Symbol { get; set; }
    }
}