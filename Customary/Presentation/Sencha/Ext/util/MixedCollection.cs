using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.util
{
    public abstract class MixedCollection : Ext.util.AbstractMixedCollection
    {
        public static implicit operator Ext.util.Sortable(Ext.util.MixedCollection model)
        {
            return model.Mixins.Get<Ext.util.Sortable>();
        }
    }
}