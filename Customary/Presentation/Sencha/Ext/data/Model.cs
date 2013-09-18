using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    using Custom.Presentation.Sencha.Ext.Util;
    using System.IO;

    /// <summary>
    /// Alternative name: Ext.data.Record
    /// </summary>
    [Ext("Ext.data.Model")]
    public partial class Model : Base, Observable
    {
        private AssociationCollection _associations;
        private FieldCollection _fields;
        private ValidationsCollection _validations;
        private ScriptField<Ext.data.proxy.Proxy> _proxy;

        /// <summary>
        /// An array of associations for this model.
        /// </summary>
        public AssociationCollection Associations
        {
            get { return _associations ?? (_associations = new AssociationCollection()); }
        }

        /// <summary>
        /// One or more BelongsTo associations for this model.
        /// </summary>
        public string BelongsTo
        {
            get;
            set;
        }

        /// <summary>
        /// The string type of the default Model Proxy.
        /// </summary>
        public string DefaultProxyType
        {
            get;
            set;
        }

        /// <summary>
        /// The fields for this model.
        /// </summary>
        public FieldCollection Fields
        {
            get { return _fields ?? (_fields = new FieldCollection()); }
        }

        /// <summary>
        /// One or more HasMany associations for this model.
        /// </summary>
        public string HasMany
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the field treated as this Model's unique id.
        /// </summary>
        public string IdProperty
        {
            get;
            set;
        }

        /// <summary>
        /// The id generator to use for this model.
        /// </summary>
        public string IdGen
        {
            get;
            set;
        }

        /// <summary>
        /// The property on this Persistable object that its data is saved to.
        /// </summary>
        public string PersistenceProperty
        {
            get;
            set;
        }

        /// <summary>
        /// The proxy to use for this model.
        /// </summary>
        public ScriptField<Ext.data.proxy.Proxy> Proxy
        {
            get { return _proxy ?? (_proxy = new ScriptField<Ext.data.proxy.Proxy>()); }
            set { (_proxy ?? (_proxy = new ScriptField<Ext.data.proxy.Proxy>())).Assign(value); }
        }

        /// <summary>
        /// An array of validations for this model.
        /// </summary>
        public ValidationsCollection Validations
        {
            get { return _validations ?? (_validations = new ValidationsCollection()); }
        }
    }
}