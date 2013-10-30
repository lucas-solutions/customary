using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.grid
{
    using Custom.Data.Metadata;

    /// <summary>
    /// Grids are an excellent way of showing large amounts of tabular data on the client side. Essentially a supercharged <table>, GridPanel makes it easy to fetch, sort and filter large amounts of data.
    /// 
    /// Grids are composed of two main pieces - a Store full of data and a set of columns to render.
    /// </summary>
    [Ext("Ext.grid.Panel")]
    public partial class Panel : Ext.panel.Table
    {
        public Panel()
        {
        }

        public Panel(ModelDefinition descriptor)
        {
        }

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
    }
}