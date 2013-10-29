using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    public abstract class StructuralDefinition : TypeDefinition
    {
        private List<PropertyDefinition> _properties;

        /// <summary>
        /// Is abtract class
        /// </summary>
        public bool Abstract
        {
            get;
            set;
        }

        /// <summary>
        /// Name of the identity property.
        /// </summary>
        public string Identity
        {
            get;
            set;
        }

        /// <summary>
        /// Name of the display property
        /// </summary>
        public string Display
        {
            get;
            set;
        }

        /// <summary>
        /// "Belongs to" type name
        /// </summary>
        public string Principal { get; set; }

        public List<PropertyDefinition> Properties
        {
            get { return _properties ?? (_properties = new List<PropertyDefinition>()); }
            set { _properties = value; }
        }
    }
}