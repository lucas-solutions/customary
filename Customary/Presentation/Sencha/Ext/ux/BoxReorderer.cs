using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.ux
{
    public abstract class BoxReorderer : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.ux.BoxReorderer model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}