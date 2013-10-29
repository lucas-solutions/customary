using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.draw
{
    public abstract class Sprite : Ext.Class
    {
        public static implicit operator Ext.util.Animate(Ext.draw.Sprite model)
        {
            return model.Mixins.Get<Ext.util.Animate>();
        }

        public static implicit operator Ext.util.Observable(Ext.draw.Sprite model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}