using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.draw
{
    public abstract class CompositeSprite : Ext.util.MixedCollection
    {
        public static implicit operator Ext.util.Animate(Ext.draw.CompositeSprite model)
        {
            return model.Mixins.Get<Ext.util.Animate>();
        }
    }
}