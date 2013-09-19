using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    public abstract class ElementLoader : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.ElementLoader model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}