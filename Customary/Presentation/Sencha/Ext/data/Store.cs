using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public class Store : AbstractStore
    {
        private Builder _builder;

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder());
        }

        protected override IScriptSerializer CreateSerializer()
        {
            return new Serializer(this);
        }

        public class Builder : Store.Builder<Store, Store.Builder>
        {
            public Builder()
                : base(new Store())
            {
            }

            public Builder(Store model)
                : base(model)
            {
            }

            public static implicit operator Store.Builder(Store model)
            {
                return model.ToBuilder();
            }
        }

        public new abstract class Builder<TModel, TBuilder> : AbstractStore.Builder<TModel, TBuilder>
            where TModel : Store
            where TBuilder : Store.Builder<TModel, TBuilder>
        {
            public Builder(TModel model)
                : base(model)
            {
            }
        }

        public class Serializer : Store.Serializer<Store, Store.Serializer>
        {
            public Serializer()
                : base(null)
            {
            }

            public Serializer(Store model)
                : base(model)
            {
            }
        }

        public new abstract class Serializer<TModel, TSerializer> : AbstractStore.Serializer<TModel, TSerializer>
            where TModel : Store
            where TSerializer : Store.Serializer<TModel, TSerializer>
        {
            public Serializer(TModel model)
                : base(model)
            {
            }

            protected override void Serialize(TModel model, ScriptWriter writer)
            {
                throw new NotImplementedException();
            }
        }
    }
}