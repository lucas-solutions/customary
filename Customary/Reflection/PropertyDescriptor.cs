using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Reflection
{
    using Raven.Json.Linq;

    public class PropertyDescriptor : MemberDescriptor
    {
        public string PropertyType { get; set; }

        public string Dependant { get; set; }

        public string Principal { get; set; }

        public PropertyRoles Role { get; set; }

        public Dictionary<string, ColumnMapping> Mapping { get; set; }
    }
}