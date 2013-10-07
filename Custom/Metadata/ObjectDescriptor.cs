using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    public abstract class ObjectDescriptor : TypeDescriptor
    {
        private List<PropertyDescriptor> _properties;

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

        public List<PropertyDescriptor> Properties
        {
            get { return _properties ?? (_properties = new List<PropertyDescriptor>()); }
            set { _properties = value; }
        }
    }
}