using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    public class PropertyDefinition : DefinitionBase
    {
        /// <summary>
        /// Default value for primitives, enum, units, texts and even entities. And constants of course.
        /// </summary>
        public object Default { get; set; }

        /// <summary>
        /// Property type: primitive, enum, unit, text, complex or entity
        /// </summary>
        public string PropertyType { get; set; }

        public PropertyRoles Role { get; set; }

        /// <summary>
        /// Column mapping and transformation for a given table name
        /// </summary>
        //public PropertyMapping Mapping { get; set; }
    }
}