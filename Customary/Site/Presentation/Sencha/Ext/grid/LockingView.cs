using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.grid
{
    public abstract class LockingView : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.grid.LockingView model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}