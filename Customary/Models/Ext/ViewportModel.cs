using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models.Ext
{
    using Ext = Custom.Presentation.Sencha.Ext;
    /// <summary>
    /// Ext.container.Viewport view model.
    /// </summary>
    public class ViewportModel
    {
        public bool Define
        {
            get;
            set;
        }

        public Ext.container.Viewport Object
        {
            get;
            set;
        }

        public int Options
        {
            get;
            set;
        }
    }
}