using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    partial class Field
    {
        private Builder _builder;

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder());
        }

        public class Builder : Field.Builder<Field, Field.Builder>
        {
            public Builder()
                : base(new Field())
            {
            }

            public Builder(Field model)
                : base(model)
            {
            }

            public static implicit operator Builder(Field model)
            {
                return model.ToBuilder();
            }
        }

        public new abstract class Builder<TModel, TBuilder> : ScriptObject.Builder<TModel, TBuilder>
            where TModel : Field
            where TBuilder : Field.Builder<TModel, TBuilder>
        {
            public Builder(TModel model)
                : base(model)
            {
            }

            public TBuilder Convert(ScriptFunction value)
            {
                ToModel().Convert = value;
                return (TBuilder)this;
            }

            public TBuilder DateFormat(string value)
            {
                ToModel().DateFormat = value;
                return (TBuilder)this;
            }

            public TBuilder DefaultValue(object value)
            {
                if (value != null)
                ToModel().DefaultValue = value.ToString();
                return (TBuilder)this;
            }

            public TBuilder Mapping(string value)
            {
                ToModel().Mapping = value;
                return (TBuilder)this;
            }

            public TBuilder Name(string value)
            {
                ToModel().Name = value;
                return (TBuilder)this;
            }

            public TBuilder Persist(bool value)
            {
                ToModel().Persist = value;
                return (TBuilder)this;
            }
            public TBuilder SortDir(string value)
            {
                ToModel().SortDir = value;
                return (TBuilder)this;
            }

            public TBuilder SortType(ScriptFunction value)
            {
                ToModel().SortType = value;
                return (TBuilder)this;
            }

            public TBuilder Type(string value)
            {
                ToModel().Type = value;
                return (TBuilder)this;
            }

            public TBuilder UseNulls(bool value)
            {
                ToModel().UseNulls = value;
                return (TBuilder)this;
            }
        }
    }
}