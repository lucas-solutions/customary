using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    using Raven.Json.Linq;

    public class PropertyDescriptor : MemberDescriptor
    {
        /// <summary>
        /// Default value for primitives, enum, units, texts and even entities. And constants of course.
        /// </summary>
        public string Default { get; set; }

        /// <summary>
        /// Property type: primitive, enum, unit, text, complex or entity
        /// </summary>
        public string PropertyType { get; set; }

        public string Dependant { get; set; }

        /// <summary>
        /// Belongs to
        /// </summary>
        public string Principal { get; set; }

        /// <summary>
        /// Column mapping and transformation for a given table name
        /// </summary>
        public Dictionary<string, ColumnMapping> Mapping { get; set; }
    }
}