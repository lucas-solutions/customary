using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Data.Metadata
{
    public enum PropertyRoles
    {
        Optional,

        Embedded,

        Required,

        Index,

        Unique,

        Identity,

        HasMany,

        BelongsTo
    }

    /*public sealed class PropertyRoles : Enum<PropertyRoles, int>
    {
        static readonly PropertyRoles[] _members;

        static PropertyRoles()
        {
            _members = null;
        }

        /// <summary>
        /// Default (reset) value
        /// </summary>
        public static readonly PropertyRoles Optional = new PropertyRoles("Optional", 0);

        /// <summary>
        /// Required value or reference. If a collection at least one element is required.
        /// </summary>
        public static readonly PropertyRoles Required = new PropertyRoles("Required", 1);

        /// <summary>
        /// Properties of this type are indexes.
        /// </summary>
        public static readonly PropertyRoles Index = new PropertyRoles("Index", 2);

        /// <summary>
        /// Indexed and unique
        /// </summary>
        public static readonly PropertyRoles Unique = new PropertyRoles("Unique", 4);

        /// <summary>
        /// Can contain or reference 0 or one or many
        /// </summary>
        public static readonly PropertyRoles HasMany = new PropertyRoles("HasMany", 8);

        private int _value;

        private PropertyRoles(string name, int value)
            : base(name)
        {
            _value = value;
        }

        protected override PropertyRoles[] Members
        {
            get { return _members; }
        }
    }*/
}
