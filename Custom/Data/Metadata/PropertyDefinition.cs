using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    public class PropertyDefinition : BaseDefinition
    {
        /// <summary>
        /// Default value for primitives, enum, units, texts and even entities. And constants of course.
        /// </summary>
        public object Default { get; set; }

        /// <summary>
        /// If the property is a collection (Role with HasMany), the IdProperty is the property in the Property Type that represents the identity of the item in the collection.
        /// This is used for update and delete.
        /// </summary>
        public string IdProperty { get; set; }

        /// <summary>
        /// Property type: primitive, enum, unit, text, complex or entity
        /// </summary>
        public string Type { get; set; }

        public PropertyRoles Role { get; set; }

        /// <summary>
        /// Column mapping and transformation for a given table name
        /// </summary>
        //public PropertyMapping Mapping { get; set; }
    }
}