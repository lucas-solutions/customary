using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.tree
{
    /// <summary>
    /// Grids are an excellent way of showing large amounts of tabular data on the client side. Essentially a supercharged <table>, GridPanel makes it easy to fetch, sort and filter large amounts of data.
    /// Grids are composed of two main pieces - a Store full of data and a set of columns to render.
    /// </summary>
    public class Panel : Ext.panel.Table
    {
        /// <summary>
        /// True to enable animated expand/collapse.
        /// </summary>
        [DefaultValue(false)]
        public bool Animate 
        {
            get;
            set;
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
        /// The field inside the model that will be used as the node's text.
        /// </summary>
        [DefaultValue("text")]
        public string DisplayField
        {
            get;
            set;
        }

        /// <summary>
        /// True to automatically prepend a leaf sorter to the store.
        /// </summary>
        [DefaultValue(false)]
        public bool FolderSort
        {
            get;
            set;
        }

        /// <summary>
        /// True to hide the headers.
        /// </summary>
        [DefaultValue(false)]
        public bool HideHeaders
        {
            get;
            set;
        }

        /// <summary>
        /// False to disable tree lines.
        /// </summary>
        [DefaultValue(true)]
        public bool Lines
        {
            get;
            set;
        }

        /// <summary>
        /// Allows you to not specify a store on this TreePanel.
        /// </summary>
        public Ext.data.NodeInterface Root 
        {
            get;
            set;
        }

        /// <summary>
        /// False to hide the root node.
        /// </summary>
        [DefaultValue(true)]
        public bool RootVisible
        {
            get;
            set;
        }

        /// <summary>
        /// An xtype of selection model to use. Defaults to 'rowmodel'. This is used to create selection model if just a config object or nothing at all given in selModel config.
        /// </summary>
        [DefaultValue("treemodel")]
        public override string SelType 
        {
            get;
            set;
        }

        /// <summary>
        /// True if only 1 node per branch may be expanded.
        /// </summary>
        [DefaultValue(false)]
        public bool SingleExpand
        {
            get;
            set;
        }

        /// <summary>
        /// True to use Vista-style arrows in the tree.
        /// </summary>
        [DefaultValue(false)]
        public bool UseArrows
        {
            get;
            set;
        }

        /// <summary>
        /// An xtype of view to use.
        /// </summary>
        [DefaultValue("treeview")]
        public override string ViewType
        {
            get;
            set;
        }
    }
}