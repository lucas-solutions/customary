using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.draw
{
    public abstract class Surface : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.draw.Surface model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}