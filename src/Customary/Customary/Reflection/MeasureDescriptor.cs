using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Reflection
{
    using Custom.Documents;

    public class MeasureDescriptor : BusinessType
    {
        public string BaseQuantity { get; set; }
    }
}