using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.fx
{
    public abstract class Animator : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.fx.Animator model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}