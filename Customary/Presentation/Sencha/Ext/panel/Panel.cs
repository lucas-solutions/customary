using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.panel
{
    public class Panel : Ext.panel.AbstractPanel
    {
        private Builder _builder;

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder(this));
        }

        protected override Scriptable ToScriptable()
        {
            return ToBuilder();
        }

        public class Builder : Panel.Builder<Panel, Panel.Builder>
        {
            public Builder()
                : base(new Panel())
            {
            }

            public Builder(Panel model)
                : base(model)
            {
            }

            public static implicit operator Builder(Panel model)
            {
                return model.ToBuilder();
            }
        }

        public new class Builder<TModel, TBuilder> : Ext.panel.AbstractPanel.Builder<TModel, TBuilder>
            where TModel : Panel
            where TBuilder : Panel.Builder<TModel, TBuilder>
        {
            public Builder(TModel model)
                : base(model)
            {
            }
        }
    }
}