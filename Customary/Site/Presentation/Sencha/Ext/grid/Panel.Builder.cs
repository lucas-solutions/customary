using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.grid
{
    partial class Panel
    {
        private Builder _builder;

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder(this));
        }

        public sealed class Builder : Builder<Ext.grid.Panel, Ext.grid.Panel.Builder>
        {
            public Builder()
                : this(new Ext.grid.Panel())
            {
            }

            public Builder(Ext.grid.Panel model)
                : base(model)
            {
            }
        }

        public new abstract class Builder<TModel, TBuilder> : Ext.panel.Table.Builder<TModel, TBuilder>
            where TModel : Panel
            where TBuilder : Panel.Builder<TModel, TBuilder>
        {
            protected Builder(TModel model)
                : base(model)
            {
            }

            public Builder<TModel, TBuilder> Columns(Ext.grid.column.Column column)
            {
                ToModel().Columns.Items.Add(column);
                return this;
            }

            public Builder<TModel, TBuilder> Columns(Action<Ext.grid.column.ColumnCollection> columns)
            {
                return this;
            }
        }
    }
}