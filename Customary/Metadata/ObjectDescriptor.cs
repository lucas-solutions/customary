using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    using Custom.Repositories;

    public class ObjectDescriptor : TypeDescriptor
    {
        private List<PropertyDescriptor> _properties;

        /// <summary>
        /// Name of the discriminator property for inheritance
        /// </summary>
        public string Discriminator { get; set; }

        /// <summary>
        /// Name of object type it inherits or extends. Entities can extend object or entity types.
        /// </summary>
        public string Extend { get; set; }

        /// <summary>
        /// Name of the identity property.
        /// </summary>
        public string Identity { get; set; }

        /// <summary>
        /// Name of the default text property
        /// </summary>
        public string Label { get; set; }

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