using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public abstract class Association : Ext.Base
    {
        /// <summary>
        /// The string name of the model that is being associated with.
        /// </summary>
        [Required]
        public string AssociatedModel
        {
            get;
            set;
        }

        /// <summary>
        /// The string name of the model that owns the association.
        /// </summary>
        [Required]
        public string OwnerModel
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the property in the data to read the association from. Defaults to the name of the associated model.
        /// </summary>
        public string AssociationKey
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the primary key on the associated model
        /// </summary>
        public string PrimaryKey
        {
            get;
            set;
        }

        /// <summary>
        /// The type configuration can be used when creating associations using a configuration object.
        /// </summary>
        public abstract string Type
        {
            get;
        }

        public void WriteTo(ScriptWriter writer)
        {
        }
    }
}