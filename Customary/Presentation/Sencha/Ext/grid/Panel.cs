using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.grid
{
    /// <summary>
    /// Grids are an excellent way of showing large amounts of tabular data on the client side. Essentially a supercharged <table>, GridPanel makes it easy to fetch, sort and filter large amounts of data.
    /// 
    /// Grids are composed of two main pieces - a Store full of data and a set of columns to render.
    /// </summary>
    [Ext("Ext.grid.Panel")]
    public class Panel : Ext.panel.Table
    {
        /// <summary>
        /// Adds column line styling.
        /// </summary>
        [DefaultValue(false)]
        public bool ColumnLines
        {
            get;
            set;
        }

        /// <summary>
        /// An xtype of view to use.
        /// </summary>
        [DefaultValue("gridview")]
        public override string ViewType
        {
            get;
            set;
        }

        public new class Builder<TModel, TBuilder> : Ext.panel.Table.Builder<TModel, TBuilder>
            where TModel : Panel
            where TBuilder : Panel.Builder<TModel, TBuilder>
        {
            public Builder(TModel model)
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