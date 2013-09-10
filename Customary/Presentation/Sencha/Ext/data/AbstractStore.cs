using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public abstract class AbstractStore : Base
    {
        public new abstract class Builder<TModel, TBuilder> : Base.Builder<TModel, TBuilder>
            where TModel : AbstractStore
            where TBuilder : AbstractStore.Builder<TModel, TBuilder>
        {
            public Builder(TModel model)
                : base(model)
            {
            }
        }

        public new abstract class Serializer<TModel, TSerializer> : Base.Serializer<TModel, TSerializer>
            where TModel : AbstractStore
            where TSerializer : AbstractStore.Serializer<TModel, TSerializer>
        {
            public Serializer(TModel model)
                : base(model)
            {
            }
        }
    }
}