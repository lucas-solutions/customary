using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    partial class ScriptObject
    {
        public abstract class Builder<TModel, TBuilder>
            where TModel : ScriptObject
            where TBuilder : ScriptObject.Builder<TModel, TBuilder>
        {
            public static implicit operator TModel(Builder<TModel, TBuilder> builder)
            {
                return builder._model;
            }

            private readonly TModel _model;

            protected Builder(TModel model)
            {
                this._model = model;
            }

            public virtual TBuilder ID(string id)
            {
                ToModel().ID = id;
                return (this as TBuilder);
            }

            public virtual TBuilder Namespace(string ns)
            {
                ToModel().Namespace = ns;
                return (this as TBuilder);
            }
            public virtual TModel ToModel()
            {
                return _model;
            }
        }
    }
}