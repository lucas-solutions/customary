using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.app
{
    public abstract class Controller : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.app.Controller model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}