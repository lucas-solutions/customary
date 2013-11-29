using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.chart.series
{
    public abstract class Series : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.chart.series.Series model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}