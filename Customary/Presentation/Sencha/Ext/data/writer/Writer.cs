using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data.writer
{
    public abstract class Writer : Base
    {
        public new abstract class Builder<TModel, TBuilder> : Base.Builder<TModel, TBuilder>
            where TModel : Writer
            where TBuilder : Writer.Builder<TModel, TBuilder>
        {
            public Builder(TModel model)
                : base(model)
            {
            }
        }

        public new abstract class Serializer<TModel, TSerializer> : Base.Serializer<TModel, TSerializer>
            where TModel : Writer
            where TSerializer : Writer.Serializer<TModel, TSerializer>
        {
            public Serializer(TModel model)
                : base(model)
            {
            }
        }
    }
}