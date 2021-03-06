﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    using Custom.Data.Persistence;

    public sealed class ModelDefinition : TypeDefinition
    {
        private List<PropertyDefinition> _properties;

        /// <summary>
        /// Is embedded. Not an entity, and specifies belongsTo
        /// </summary>
        public string BelongsTo
        {
            get;
            set;
        }

        /// <summary>
        /// Is embedded. Not an entity
        /// </summary>
        public bool Embeddable
        {
            get;
            set;
        }

        /// <summary>
        /// Can not be inheried. Only Final models can be instantiated.
        /// Final models can not be Embeddable. They represent an entity or document.
        /// There is no direct relationship between Embeddable and final.
        /// For example:
        /// * The Type model is not Embeddable, and it is not Final.
        /// * The Model model is not Embeddable and it is Final.
        /// * The Property model is Embeddable and it is Final.
        /// * The Definition model is Embeddable but it is not Final.
        /// </summary>
        public bool Final
        {
            get;
            set;
        }

        /// <summary>
        /// Name of the identity property.
        /// </summary>
        public string IdProperty
        {
            get;
            set;
        }

        /// <summary>
        /// Name of the display property
        /// </summary>
        public string DisplayProperty
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
        public string Store
        {
            get;
            set;
        }

        public ModelUI UI
        {
            get;
            set;
        }
    }
}