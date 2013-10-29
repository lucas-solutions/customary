using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.fx
{
    public abstract class Anim : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.fx.Anim model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}