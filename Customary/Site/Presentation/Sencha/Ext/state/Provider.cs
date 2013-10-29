using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.state
{
    public abstract class Provider : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.state.Provider model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}