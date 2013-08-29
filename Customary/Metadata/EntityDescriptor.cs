using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    public class EntityDescriptor : ComplexDescriptor
    {
        public Dictionary<string, TableMapping> Mapping { get; set; }
    }
}