using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.panel
{
    public class Layout
    {
        public static implicit operator Layout(LayoutTypes type)
        {
            return new Layout { Type = type };
        }

        public string Align
        {
            get;
            set;
        }

        /// <summary>
        /// The layout type to be used for this container. If not specified, a default Ext.layout.container.Auto will be created and used.
        /// </summary>
        public LayoutTypes Type
        {
            get;
            set;
        }
    }
}