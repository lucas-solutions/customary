using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.panel
{
    [DefaultValue(ScrollDirections.none)]
    public enum ScrollDirections
    {
        none,
        horizontal,
        vertical,
        both
    }
}