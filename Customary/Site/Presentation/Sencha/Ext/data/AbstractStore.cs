using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.data
{
    public abstract class AbstractStore : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.data.AbstractStore model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }

        public static implicit operator Ext.util.Sortable(Ext.data.AbstractStore model)
        {
            return model.Mixins.Get<Ext.util.Sortable>();
        }

        public new abstract class Builder<TModel, TBuilder> : Base.Builder<TModel, TBuilder>
            where TModel : AbstractStore
            where TBuilder : AbstractStore.Builder<TModel, TBuilder>
        {
            public Builder(TModel model)
                : base(model)
            {
            }
        }
    }
}