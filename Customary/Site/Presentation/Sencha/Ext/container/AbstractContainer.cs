using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.container
{
    public abstract class AbstractContainer : Ext.Component
    {
        public new abstract class Builder<TModel, TBuilder> : Component.Builder<TModel, TBuilder>
            where TModel : AbstractContainer
            where TBuilder : AbstractContainer.Builder<TModel, TBuilder>
        {
            public Builder(TModel obj)
                : base(obj)
            {
            }
        }
    }
}