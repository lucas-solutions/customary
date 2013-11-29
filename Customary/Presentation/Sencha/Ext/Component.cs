using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    [Ext(Name = "Ext.Component", XType = "component")]
    public abstract partial class Component : Ext.AbstractComponent
    {
        public static implicit operator Ext.util.Floating(Ext.Component model)
        {
            return model.Mixins.Get<Ext.util.Floating>();
        }

        /// <summary>
        /// True to use overflow:'auto' on the components layout element and show scroll bars automatically when necessary, false to clip any overflowing content.
        /// </summary>
        [DefaultValue(false)]
        public bool AutoScroll
        {
            get;
            set;
        }

        /// <summary>
        /// Specify as true to make a floating Component draggable using the Component's encapsulating element as the drag handle.
        /// </summary>
        [DefaultValue(false)]
        public bool Draggable
        {
            get;
            set;
        }

        /// <summary>
        /// Specify as true to float the Component outside of the document flow using CSS absolute positioning.
        /// </summary>
        [DefaultValue(false)]
        public bool Floating
        {
            get;
            set;
        }

        /// <summary>
        /// Specifies that if an immediate sibling Splitter is moved, the Component on the other side is resized, and this Component maintains its configured flex value.
        /// </summary>
        [DefaultValue(false)]
        public bool MaintainFlex
        {
            get;
            set;
        }

        /// <summary>
        /// Specify as true to apply a Resizer to this Component after rendering.
        /// </summary>
        [DefaultValue(false)]
        public bool Resizable
        {
            get;
            set;
        }

        /// <summary>
        /// A valid Ext.resizer.Resizer handles config string. Only applies when resizable = true.
        /// </summary>
        [DefaultValue("all")]
        public string ResizeHandles
        {
            get;
            set;
        }

        /// <summary>
        /// True to automatically call toFront when the show method is called on an already visible, floating component.
        /// </summary>
        [DefaultValue(true)]
        public bool ToFrontOnShow
        {
            get;
            set;
        }
    }
}