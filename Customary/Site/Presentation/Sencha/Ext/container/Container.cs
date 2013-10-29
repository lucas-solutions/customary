using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.container
{
    public abstract class Container : Ext.container.AbstractContainer
    {
        public new abstract class Builder<TModel, TBuilder> : AbstractContainer.Builder<TModel, TBuilder>
            where TModel : Container
            where TBuilder : Container.Builder<TModel, TBuilder>
        {
            public Builder(TModel obj)
                : base(obj)
            {
            }
        }
    }
}