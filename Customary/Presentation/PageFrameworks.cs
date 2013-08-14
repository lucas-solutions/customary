using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public enum PageFrameworks
    {
        None = 0,
        Css3 = 1,
        Html5 = 2,
        Angular = 4,
        Backbone = 8,
        JQuery = 16,
        JQueryMobile = 32,
        Knockout = 64,
        SenchaExt = 128,
        SenchaTouch = 256
    }
}