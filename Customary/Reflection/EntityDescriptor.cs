using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Reflection
{
    public class EntityDescriptor : ComplexDescriptor
    {
        public Dictionary<string, TableMapping> Mapping { get; set; }
    }
}