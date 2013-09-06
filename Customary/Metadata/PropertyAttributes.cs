using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    [DefaultValue(PropertyAttributes.Optional)]
    public enum PropertyAttributes : byte
    {
        /// <summary>
        /// Default (reset) value
        /// </summary>
        Optional = 0,

        /// <summary>
        /// Required value or reference. If a collection at least one element is required.
        /// </summary>
        Required = 1,

        /// <summary>
        /// Properties of this type are indexes.
        /// </summary>
        Index = 2,

        /// <summary>
        /// Indexed and unique
        /// </summary>
        Unique = 4,

        /// <summary>
        /// Primitive property that represents the identity (ID). Usually a GUID. Properties of this type are the primary key in a database.
        /// </summary>
        Identity = 8,

        /// <summary>
        /// Can contain or reference 0 or one or many
        /// </summary>
        Collection = 16,

        /// <summary>
        /// One or many
        /// </summary>
        RequiredCollection = Required | Collection,
    }
}