using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.container
{
    partial class Viewport
    {
        public class Builder : Ext.container.Viewport.Builder<Viewport, Viewport.Builder>
        {
            public Builder()
                : base(new Viewport())
            {
            }

            public Builder(Viewport model)
                : base(model)
            {
            }

            public static implicit operator Viewport.Builder(Viewport model)
            {
                return model.ToBuilder();
            }
        }

        public abstract class Builder<TModel, TBuilder> : Ext.container.Container.Builder<TModel, TBuilder>
            where TModel : Viewport
            where TBuilder : Viewport.Builder<TModel, TBuilder>
        {
            public Builder(TModel model)
                : base(model)
            {
            }
        }
    }
}