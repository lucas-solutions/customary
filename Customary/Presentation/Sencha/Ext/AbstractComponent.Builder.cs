using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    partial class AbstractComponent
    {
        public new abstract class Builder<TModel, TBuilder> : Base.Builder<TModel, TBuilder>
            where TModel : AbstractComponent
            where TBuilder : AbstractComponent.Builder<TModel, TBuilder>
        {
            // Methods
            public Builder(TModel model)
                : base(model)
            {
            }
        }
    }
}