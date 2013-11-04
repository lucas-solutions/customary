using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    public sealed class ModelDefinition : TypeDefinition
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

        public bool Template
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
        /// Singleton
        /// </summary>
        public bool Singleton
        {
            get;
            set;
        }

        /// <summary>
        /// "Belongs to" type name
        /// </summary>
        public string Principal { get; set; }

        /// <summary>
        /// Comma separated list of head (column in a grid) properties
        /// </summary>
        public string Head
        {
            get;
            set;
        }

        public bool Generic
        {
            get;
            set;
        }

        /// <summary>
        /// Generic arguments. If generic is set to true.
        /// { name, type }
        /// </summary>
        public Dictionary<string, string> Arguments
        {
            get;
            set;
        }

        public List<PropertyDefinition> Properties
        {
            get { return _properties ?? (_properties = new List<PropertyDefinition>()); }
            set { _properties = value; }
        }

        /// <summary>
        /// Document name, table name, REST (Representational state transfer) service URL.
        /// </summary>
        public StoreInfo Store
        {
            get;
            set;
        }
    }
}