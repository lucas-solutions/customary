using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    partial class Model
    {
        private Builder _builder;

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder(this));
        }

        public class Builder : Ext.data.Model.Builder<Model, Model.Builder>
        {
            public Builder()
                : this(new Model())
            {
            }

            internal Builder(Model model)
                : base(model)
            {
                model._builder = this;
            }

            public static implicit operator Model.Builder(Model model)
            {
                return model.ToBuilder();
            }
        }

        public new abstract class Builder<TModel, TBuilder> : Ext.Class.Builder<TModel, TBuilder>
            where TModel : Model
            where TBuilder : Model.Builder<TModel, TBuilder>
        {
            public Builder(TModel model)
                : base(model)
            {
            }

            /// <summary>
            /// An array of associations for this model.
            /// </summary>
            public TBuilder Associations(Action<AssociationCollection> action)
            {
                action(ToModel().Associations);
                return (TBuilder)this;
            }

            /// <summary>
            /// One or more BelongsTo associations for this model.
            /// </summary>
            public TBuilder BelongsTo(string value)
            {
                ToModel().BelongsTo = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// One or more BelongsTo associations for this model.
            /// </summary>
            public TBuilder BelongsTo(Model value)
            {
                //ToModel().BelongsTo = value.Name;
                return (TBuilder)this;
            }

            /// <summary>
            /// The string type of the default Model Proxy.
            /// </summary>
            public TBuilder DefaultProxyType(string value)
            {
                ToModel().DefaultProxyType = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// The fields for this model.
            /// </summary>
            public TBuilder Fields(Action<FieldCollection> action)
            {
                action(ToModel().Fields);
                return (TBuilder)this;
            }

            /// <summary>
            /// One or more HasMany associations for this model.
            /// </summary>
            public TBuilder HasMany(string value)
            {
                ToModel().HasMany = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// One or more HasMany associations for this model.
            /// </summary>
            public TBuilder HasMany(string model, string name)
            {
                ToModel().Associations.HasMany(model: model, name: name);
                return (TBuilder)this;
            }

            /// <summary>
            /// The name of the field treated as this Model's unique id.
            /// </summary>
            public TBuilder IdProperty(string value)
            {
                ToModel().IdProperty = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// The id generator to use for this model.
            /// </summary>
            public TBuilder IdGen(string value)
            {
                ToModel().IdGen = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// The property on this Persistable object that its data is saved to.
            /// </summary>
            public TBuilder PersistenceProperty(string value)
            {
                ToModel().PersistenceProperty = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// The proxy to use for this model.
            /// </summary>
            public TBuilder Proxy(string value)
            {
                ToModel().Proxy = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// The proxy to use for this model.
            /// </summary>
            public TBuilder Proxy(Ext.data.proxy.Proxy value)
            {
                ToModel().Proxy = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// The proxy to use for this model.
            /// </summary>
            public TBuilder Proxy(Action<Ext.data.proxy.Proxy> action)
            {
                Ext.data.proxy.Proxy proxy = ToModel().Proxy;
                if (proxy == null)
                {
                    ToModel().Proxy = proxy = new Ext.data.proxy.Proxy
                    {
                        //Name = (string)ToModel().Proxy
                    };
                }

                action(proxy);
                return (TBuilder)this;
            }

            /// <summary>
            /// An array of validations for this model.
            /// </summary>
            public TBuilder Validations(Action<ValidationsCollection> action)
            {
                action(ToModel().Validations);
                return (TBuilder)this;
            }
        }
    }
}