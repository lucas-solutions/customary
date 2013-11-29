using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public abstract class Tree : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.data.Tree model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}