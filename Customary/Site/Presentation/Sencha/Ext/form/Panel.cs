using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.form
{
    public class Panel : Ext.panel.Panel
    {
        public new class Builder : Ext.panel.Panel.Builder<Panel, Builder>
        {
            public Builder()
                : base(new Panel())
            {
            }

            public Builder(Panel model)
                : base(model)
            {
            }
        }
    }
}