using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.panel
{
    [DefaultValue(LayoutTypes.Auto)]
    public enum LayoutTypes
    {
        Auto,
        card,
        fit,
        hbox,
        vbox,
        anchor,
        table
    }
}