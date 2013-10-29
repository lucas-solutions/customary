using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext
{
    partial class Component
    {
        public new abstract class Builder<TModel, TBuilder> : Ext.AbstractComponent.Builder<TModel, TBuilder>
            where TModel : Component
            where TBuilder : Component.Builder<TModel, TBuilder>
        {
            public Builder(TModel obj)
                : base(obj)
            {
            }
        }
    }
}