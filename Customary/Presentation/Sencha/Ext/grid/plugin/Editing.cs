using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.grid.plugin
{
    [Ext(Name = "Ext.grid.plugin.Editing", XType = "editorgrid")]
    public abstract class Editing : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.grid.plugin.Editing model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}