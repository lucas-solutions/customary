using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.util
{
    public abstract class History : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.util.History model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}