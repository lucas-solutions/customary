using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.data
{
    public abstract class Batch : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.data.Batch model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}