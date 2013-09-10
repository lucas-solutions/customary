using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.container
{
    /// <summary>
    /// A specialized content Container representing the viewable application area (the browser viewport).
    /// </summary>
    public partial class Viewport : Ext.container.Container
    {
        private Builder _builder;

        /// <summary>
        /// 
        /// </summary>
        public bool AllowDomMove
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string ApplyTo
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool AutoHeight
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool AutoWidth
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DeferHeight
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public override int? Height
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool HideParent
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool MonitorResize
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public override string RenderTo
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public override int? Width
        {
            get;
            set;
        }

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder());
        }
    }
}