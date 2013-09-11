using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public class BelongsToAssociation : Ext.data.Association
    {
        /// <summary>
        /// The name of the foreign key on the owner model that links it to the associated model.
        /// </summary>
        public string ForeignKey
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the getter function that will be added to the local model's prototype.
        /// </summary>
        public string GetterName
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the setter function that will be added to the local model's prototype.
        /// </summary>
        public string SetterName
        {
            get;
            set;
        }

        /// <summary>
        /// The type configuration can be used when creating associations using a configuration object.
        /// </summary>
        public override string Type
        {
            get { return "belongsTo"; }
        }

        protected override IScriptSerializer ToNativeSerializer()
        {
            throw new NotImplementedException();
        }
    }
}