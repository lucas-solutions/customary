using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public class HasManyAssociation : Ext.data.Association
    {
        /// <summary>
        /// True to automatically load the related store from a remote source when instantiated.
        /// </summary>
        public bool AutoLoad
        {
            get;
            set;
        }

        /// <summary>
        /// Optionally overrides the default filter that is set up on the associated Store.
        /// </summary>
        public string FilterProperty
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the foreign key on the associated model that links it to the owner model.
        /// </summary>
        public string ForeignKey
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the function to create on the owner model to retrieve the child store.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Optional configuration object that will be passed to the generated Store.
        /// </summary>
        public object StoreConfig
        {
            get;
            set;
        }

        /// <summary>
        /// The type configuration can be used when creating associations using a configuration object.
        /// </summary>
        public override string Type
        {
            get { return "hasMany"; }
        }

        protected override IScriptSerializer ToNativeSerializer()
        {
            throw new NotImplementedException();
        }
    }
}