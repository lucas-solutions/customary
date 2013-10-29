using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.util
{
    public abstract class AbstractMixedCollection : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.util.AbstractMixedCollection model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}