using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    [Description("Abstract base class that provides a common interface for publishing events")]
    public abstract class Base : ScriptObject
    {
        protected Base()
        {
        }

        public string Extend
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public new abstract class Builder<TModel, TBuilder> : ScriptObject.Builder<TModel, TBuilder>
            where TModel : Base
            where TBuilder : Base.Builder<TModel, TBuilder>
        {
            public Builder(TModel model)
                : base(model)
            {
            }

            public TBuilder Extend(string value)
            {
                ToModel().Extend = value;
                return (TBuilder)this;
            }

            public TBuilder Name(string value)
            {
                ToModel().Name = value;
                return (TBuilder)this;
            }
        }

        public new abstract class Serializer<TModel, TBuilder> : ScriptObject.Serializer<TModel, TBuilder>
            where TModel : Base
            where TBuilder : Base.Serializer<TModel, TBuilder>
        {
            public Serializer(TModel model)
                : base(model)
            {
            }
        }
    }
}