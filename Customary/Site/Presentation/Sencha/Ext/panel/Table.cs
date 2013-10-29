using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.panel
{
    /// <summary>
    /// TablePanel is the basis of both TreePanel and GridPanel.
    /// - a Selection Model
    /// - a View
    /// - a Store
    /// - Scrollers
    /// - Ext.grid.header.Container
    /// </summary>
    public partial class Table : Ext.panel.Panel
    {
        private Ext.grid.column.ColumnCollection _columns;
        private Ext.grid.feature.FeatureCollection _features;

        /// <summary>
        /// An array of column definition objects which define all columns that appear in this grid.
        /// </summary>
        public Ext.grid.column.ColumnCollection Columns
        {
            get { return _columns ?? (_columns = new grid.column.ColumnCollection()); }
        }

        /// <summary>
        /// Defaults to true to enable deferred row rendering.
        /// </summary>
        [DefaultValue(true)]
        public bool DeferRowRender
        {
            get;
            set;
        }

        /// <summary>
        /// False to disable column hiding within this grid.
        /// </summary>
        [DefaultValue(true)]
        public bool EnableColumnHide
        {
            get;
            set;
        }

        /// <summary>
        /// False to disable column dragging within this grid.
        /// </summary>
        [DefaultValue(true)]
        public bool EnableColumnMove
        {
            get;
            set;
        }

        /// <summary>
        /// False to disable column resizing within this grid.
        /// </summary>
        [DefaultValue(true)]
        public bool EnableColumnResize
        {
            get;
            set;
        }

        /// <summary>
        /// True to enable locking support for this grid.
        /// </summary>
        [DefaultValue(false)]
        public bool EnableLocking
        {
            get;
            set;
        }

        /// <summary>
        /// An array of grid Features to be added to this grid.
        /// </summary>
        public Ext.grid.feature.FeatureCollection Features
        {
            get { return _features ?? (_features = new grid.feature.FeatureCollection()); }
        }

        /// <summary>
        /// True to force the columns to fit into the available width.
        /// </summary>
        [DefaultValue(false)]
        public bool ForceFit
        {
            get;
            set;
        }

        /// <summary>
        /// True to hide column headers.
        /// </summary>
        [DefaultValue(false)]
        public bool HideHeaders
        {
            get;
            set;
        }

        /// <summary>
        /// Important: In order for child items to be correctly sized and positioned, typically a layout manager must be specified through the layout configuration option.
        /// The sizing and positioning of child items is the responsibility of the Container's layout manager which creates and manages the type of layout you have in mind. For example:
        /// If the layout configuration is not explicitly specified for a general purpose container (e.g. Container or Panel) the default layout manager will be used which does nothing but render child components sequentially into the Container (no sizing or positioning will be performed in this situation).
        /// Layout may be specified as either as an Object or as a String
        /// </summary>
        [DefaultValue(LayoutTypes.fit)]
        public ScriptField<Ext.panel.Layout> Layout
        {
            get;
            set;
        }

        /// <summary>
        /// True to enable 'MULTI' selection mode on selection model.
        /// </summary>
        [DefaultValue(false)]
        public bool MultiSelect
        {
            get;
            set;
        }

        /// <summary>
        /// Scrollers configuration. Valid values are 'both', 'horizontal' or 'vertical'. True implies 'both'. False implies 'none'.
        /// </summary>
        [DefaultValue(ScrollDirections.both)]
        public ScrollDirections Scroll
        {
            get;
            set;
        }

        /// <summary>
        /// Number of pixels to scroll when scrolling with mousewheel.
        /// </summary>
        [DefaultValue(40)]
        public byte ScrollDelta
        {
            get;
            set;
        }

        /// <summary>
        /// A selection model instance or config object.
        /// </summary>
        public Ext.selection.Model SelModel
        {
            get;
            set;
        }

        /// <summary>
        /// An xtype of selection model to use.
        /// </summary>
        [DefaultValue("rowmodel")]
        public virtual string SelType
        {
            get;
            set;
        }

        /// <summary>
        /// True to enable 'SIMPLE' selection mode on selection model.
        /// </summary>
        [DefaultValue(false)]
        public bool SimpleSelect
        {
            get;
            set;
        }

        /// <summary>
        /// False to disable column sorting via clicking the header and via the Sorting menu items.
        /// </summary>
        public bool SortableColumns
        {
            get;
            set;
        }

        /// <summary>
        /// The Store the grid should use as its data source.
        /// </summary>
        [Required]
        public ScriptField<Ext.data.Store> Store
        {
            get;
            set;
        }

        /// <summary>
        /// The Ext.view.Table used by the grid.
        /// </summary>
        public Ext.view.Table View
        {
            get;
            set;
        }

        /// <summary>
        /// A config object that will be applied to the grid's UI view.
        /// </summary>
        public dynamic ViewConfig
        {
            get;
            set;
        }

        /// <summary>
        /// An xtype of view to use. This is automatically set to 'gridview' by Grid and to 'treeview' by Tree.
        /// </summary>
        public virtual string ViewType
        {
            get;
            set;
        }
    }
}