using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    using Custom.Data.Persistence;

    public class MeasureDescriptor : TypeDefinition
    {
        public string BaseQuantity { get; set; }
    }
}