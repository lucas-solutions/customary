using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.panel
{
    public abstract class AbstractPanel : Ext.container.Container
    {
        public new abstract class Builder<TModel, TBuilder> : Ext.container.Container.Builder<TModel, TBuilder>
            where TModel : AbstractPanel
            where TBuilder : AbstractPanel.Builder<TModel, TBuilder>
        {
            public Builder(TModel model)
                : base(model)
            {
            }
        }
    }
}