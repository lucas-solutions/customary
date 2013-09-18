using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.App.Models
{
    using Ext = Custom.Presentation.Sencha.Ext;
    using Custom.Metadata;
    using Custom.Presentation;

    public class EntityViewModel
    {
        public EntityDescriptor Descriptor
        {
            get;
            set;
        }

        public Ext.data.Model Model
        {
            get;
            set;
        }

        public Ext.grid.Panel Panel
        {
            get;
            set;
        }
    }
}