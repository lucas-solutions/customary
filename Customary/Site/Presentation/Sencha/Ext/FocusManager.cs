using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext
{
    public abstract class FocusManager : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.FocusManager model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}