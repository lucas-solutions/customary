using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.panel
{
    partial class Table
    {
        public new abstract class Builder<TModel, TBuilder> : Panel.Builder<TModel, TBuilder>
            where TModel : Table
            where TBuilder : Table.Builder<TModel, TBuilder>
        {
            public Builder(TModel model)
                : base(model)
            {
            }

            /// <summary>
            /// An array of column definition objects which define all columns that appear in this grid.
            /// </summary>
            public TBuilder Columns(Action<Ext.grid.column.ColumnCollection> setter)
            {
                setter(ToModel().Columns);
                return (TBuilder)this;
            }

            /// <summary>
            /// Defaults to true to enable deferred row rendering.
            /// </summary>
            public TBuilder DeferRowRender(bool value)
            {
                ToModel().DeferRowRender = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// False to disable column hiding within this grid.
            /// </summary>
            public TBuilder EnableColumnHide(bool value)
            {
                ToModel().EnableColumnHide = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// False to disable column dragging within this grid.
            /// </summary>
            public TBuilder EnableColumnMove(bool value)
            {
                ToModel().EnableColumnMove = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// False to disable column resizing within this grid.
            /// </summary>
            public TBuilder EnableColumnResize(bool value)
            {
                ToModel().EnableColumnHide = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// True to enable locking support for this grid.
            /// </summary>
            public TBuilder EnableLocking(bool value)
            {
                ToModel().EnableLocking = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// An array of grid Features to be added to this grid.
            /// </summary>
            public TBuilder Features(Action<Ext.grid.feature.FeatureCollection> setter)
            {
                setter(ToModel().Features);
                return (TBuilder)this;
            }

            /// <summary>
            /// True to force the columns to fit into the available width.
            /// </summary>
            public TBuilder ForceFit(bool value)
            {
                ToModel().ForceFit = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// True to hide column headers.
            /// </summary>
            public TBuilder HideHeaders(bool value)
            {
                ToModel().HideHeaders = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// Important: In order for child items to be correctly sized and positioned, typically a layout manager must be specified through the layout configuration option.
            /// The sizing and positioning of child items is the responsibility of the Container's layout manager which creates and manages the type of layout you have in mind. For example:
            /// If the layout configuration is not explicitly specified for a general purpose container (e.g. Container or Panel) the default layout manager will be used which does nothing but render child components sequentially into the Container (no sizing or positioning will be performed in this situation).
            /// Layout may be specified as either as an Object or as a String
            /// </summary>
            public TBuilder Layout(ScriptField<Ext.panel.Layout> value)
            {
                ToModel().Layout = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// True to enable 'MULTI' selection mode on selection model.
            /// </summary>
            public TBuilder MultiSelect(bool value)
            {
                ToModel().MultiSelect = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// Scrollers configuration. Valid values are 'both', 'horizontal' or 'vertical'. True implies 'both'. False implies 'none'.
            /// </summary>
            public TBuilder Scroll(ScrollDirections value)
            {
                ToModel().Scroll = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// Number of pixels to scroll when scrolling with mousewheel.
            /// </summary>
            public TBuilder ScrollDelta(byte value)
            {
                ToModel().ScrollDelta = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// A selection model instance or config object.
            /// </summary>
            public TBuilder SelModel(Ext.selection.Model value)
            {
                ToModel().SelModel = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// An xtype of selection model to use.
            /// </summary>
            public TBuilder SelType(string value)
            {
                ToModel().SelType = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// True to enable 'SIMPLE' selection mode on selection model.
            /// </summary>
            public TBuilder SimpleSelect(bool value)
            {
                ToModel().SimpleSelect = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// False to disable column sorting via clicking the header and via the Sorting menu items.
            /// </summary>
            public TBuilder SortableColumns(bool value)
            {
                ToModel().SortableColumns = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// The Store the grid should use as its data source.
            /// </summary>
            public TBuilder Store(ScriptField<Ext.data.Store> value)
            {
                ToModel().Store = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// The Ext.view.Table used by the grid.
            /// </summary>
            public TBuilder View(Ext.view.Table value)
            {
                ToModel().View = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// A config object that will be applied to the grid's UI view.
            /// </summary>
            public TBuilder ViewConfig(dynamic value)
            {
                ToModel().ViewConfig = value;
                return (TBuilder)this;
            }

            /// <summary>
            /// An xtype of view to use.
            /// </summary>
            public TBuilder ViewType(string value)
            {
                ToModel().ViewType = value;
                return (TBuilder)this;
            }
        }
    }
}