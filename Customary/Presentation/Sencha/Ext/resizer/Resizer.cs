using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.resizer
{
    public abstract class Resizer : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.resizer.Resizer model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}