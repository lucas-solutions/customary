using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data.reader
{
    public abstract class Reader : Base
    {
        public string IdProperty
        {
            get;
            set;
        }

        public bool ImplicitIncludes
        {
            get;
            set;
        }

        public new abstract class Builder<TModel, TBuilder> : Base.Builder<TModel, TBuilder>
            where TModel : Reader
            where TBuilder : Reader.Builder<TModel, TBuilder>
        {
            public Builder(TModel model)
                : base(model)
            {
            }
        }

        public new abstract class Serializer<TModel, TSerializer> : Base.Serializer<TModel, TSerializer>
            where TModel : Reader
            where TSerializer : Reader.Serializer<TModel, TSerializer>
        {
            public Serializer(TModel model)
                : base(model)
            {
            }
        }
    }
}