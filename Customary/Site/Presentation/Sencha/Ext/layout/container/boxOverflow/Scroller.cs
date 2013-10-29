using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.layout.container.boxOverflow
{
    public abstract class Scroller : Ext.layout.container.boxOverflow.None
    {
        public static implicit operator Ext.util.Observable(Ext.layout.container.boxOverflow.Scroller model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}