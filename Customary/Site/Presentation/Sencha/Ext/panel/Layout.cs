using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Sencha.Ext.panel
{
    public class Layout : ScriptObject
    {
        private Builder _builder;

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

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder(this));
        }

        public class Builder : ScriptObject.Builder<Layout, Builder>
        {
            public Builder(Layout model)
                : base(model)
            {
            }
        }
    }
}