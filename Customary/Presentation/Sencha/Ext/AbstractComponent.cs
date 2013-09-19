using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    public abstract partial class AbstractComponent : Ext.Class
    {
        public static implicit operator Ext.util.Animate(Ext.AbstractComponent model)
        {
            return model.Mixins.Get<Ext.util.Animate>();
        }

        public static implicit operator Ext.util.Observable(Ext.AbstractComponent model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }

        /// <summary>
        /// A tag name or DomHelper spec used to create the Element which will encapsulate this Component.
        /// </summary>
        public string AutoEl
        {
            get;
            set;
        }

        /// <summary>
        /// This config is intended mainly for non-floating Components which may or may not be shown.
        /// </summary>
        [DefaultValue(false)]
        public bool AutoRender
        {
            get;
            set;
        }

        /// <summary>
        /// True to automatically show the component upon creation. This config option may only be used for floating components or components that use autoRender.
        /// </summary>
        [DefaultValue(false)]
        public bool AutoShow
        {
            get;
            set;
        }

        /// <summary>
        /// The base CSS class to apply to this components's element.
        /// </summary>
        [DefaultValue("x-component")]
        public string BaseCls
        {
            get;
            set;
        }

        /// <summary>
        /// Specifies the border for this component.
        /// </summary>
        public CssRect Border
        {
            get;
            set;
        }

        /// <summary>
        /// An array describing the child elements of the Component. Each member of the array is an object with these properties:
        /// name - The property name on the Component for the child element.
        /// itemId - The id to combine with the Component's id that is the id of the child element.
        /// id - The id of the child element.
        /// If the array member is a string, it is equivalent to { name: m, itemId: m }
        /// </summary>
        public object[] ChildEls
        {
            get;
            set;
        }

        /// <summary>
        /// An optional extra CSS class that will be added to this component's Element. This can be useful for adding customized styles to the component or any of its children using standard CSS rules.
        /// </summary>
        [DefaultValue("")]
        public string Cls
        {
            get;
            set;
        }

        /// <summary>
        /// CSS Class to be added to a components root level element to give distinction to it via styling.
        /// </summary>
        public string ComponentCls
        {
            get;
            set;
        }

        /// <summary>
        /// The sizing and positioning of a Component's internal Elements is the responsibility of the Component's layout manager which sizes a Component's internal structure in response to the Component being sized.
        /// Generally, developers will not use this configuration as all provided Components which need their internal elements sizing (Such as input fields) come with their own componentLayout managers.
        /// The default layout manager will be used on instances of the base Ext.Component class which simply sizes the Component's encapsulating element to the height and width specified in the setSize method.
        /// </summary>
        public string ComponentLayout
        {
            get;
            set;
        }

        /// <summary>
        /// Specify an existing HTML element, or the id of an existing HTML element to use as the content for this component.
        /// </summary>
        public string ContentEl
        {
            get;
            set;
        }

        /// <summary>
        /// The initial set of data to apply to the tpl to update the content area of the Component.
        /// </summary>
        public object Data
        {
            get;
            set;
        }

        /// <summary>
        /// True to disable the component.
        /// </summary>
        [DefaultValue(false)]
        public string Disabled 
        {
            get;
            set;
        }

        /// <summary>
        /// CSS class to add when the Component is disabled. Defaults to 'x-item-disabled'.
        /// </summary>
        [DefaultValue("x-item-disabled")]
        public string DisabledCls
        {
            get;
            set;
        }

        /// <summary>
        /// Allows the component to be dragged.
        /// </summary>
        [DefaultValue(false)]
        public bool Draggable
        {
            get;
            set;
        }

        /// <summary>
        /// Create the Component as a floating and use absolute positioning.
        /// </summary>
        [DefaultValue(false)]
        public bool Floating
        {
            get;
            set;
        }

        /// <summary>
        /// Specify as true to have the Component inject framing elements within the Component at render time to provide a graphical rounded frame around the Component content.
        /// This is only necessary when running on outdated, or non standard-compliant browsers such as Microsoft's Internet Explorer prior to version 9 which do not support rounded corners natively.
        /// The extra space taken up by this framing is available from the read only property frameSize.
        /// </summary>
        [DefaultValue(false)]
        public bool Frame
        {
            get;
            set;
        }

        /// <summary>
        /// The height of this component in pixels.
        /// </summary>
        public virtual int? Height
        {
            get;
            set;
        }

        /// <summary>
        /// True to hide the component.
        /// </summary>
        [DefaultValue(false)]
        public bool Hidden
        {
            get;
            set;
        }

        /// <summary>
        /// A String which specifies how this Component's encapsulating DOM element will be hidden. Values may be:
        /// 'display' : The Component will be hidden using the display: none style.
        /// 'visibility' : The Component will be hidden using the visibility: hidden style.
        /// 'offsets' : The Component will be hidden by absolutely positioning it out of the visible area of the document. This is useful when a hidden Component must maintain measurable dimensions. Hiding using display results in a Component having zero dimensions.
        /// </summary>
        [DefaultValue("display")]
        public string HideMode
        {
            get;
            set;
        }

        /// <summary>
        /// An HTML fragment, or a DomHelper specification to use as the layout element content. The HTML content is added after the component is rendered, so the document will not contain this HTML at the time the render event is fired. This content is inserted into the body before any configured contentEl is appended.
        /// </summary>
        [DefaultValue("")]
        public string Html
        {
            get;
            set;
        }

        /// <summary>
        /// The unique id of this component instance.
        /// </summary>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// An itemId can be used as an alternative way to get a reference to a component when no object reference is available. Instead of using an id with Ext.getCmp, use itemId with Ext.container.Container.getComponent which will retrieve itemId's or id's. Since itemId's are an index to the container's internal MixedCollection, the itemId is scoped locally to the container -- avoiding potential conflicts with Ext.ComponentManager which requires a unique id.
        /// </summary>
        public string ItemId
        {
            get;
            set;
        }

        /// <summary>
        /// A configuration object or an instance of a Ext.ComponentLoader to load remote content for this Component.
        /// </summary>
        public object Loader
        {
            get;
            set;
        }

        /// <summary>
        /// Specifies the margin for this component. The margin can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
        /// </summary>
        public CssRect Margin
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum value in pixels which this Component will set its height to.
        /// Warning: This will override any size management applied by layout managers.
        /// </summary>
        public int? MaxHeight
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum value in pixels which this Component will set its width to.
        /// Warning: This will override any size management applied by layout managers.
        /// </summary>
        public int? MaxWidth
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum value in pixels which this Component will set its height to.
        /// Warning: This will override any size management applied by layout managers.
        /// </summary>
        public int? MinHeight
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum value in pixels which this Component will set its width to.
        /// Warning: This will override any size management applied by layout managers.
        /// </summary>
        public int? MinWidth
        {
            get;
            set;
        }

        /// <summary>
        /// An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. This can be useful for adding customized 'active' or 'hover' styles to the component or any of its children using standard CSS rules.
        /// </summary>
        [DefaultValue("")]
        public string OverCls
        {
            get;
            set;
        }

        /// <summary>
        /// Specifies the padding for this component. The padding can be a single numeric value to apply to all sides or it can be a CSS style specification for each style, for example: '10 5 3 10'.
        /// </summary>
        public CssRect Padding
        {
            get;
            set;
        }

        /// <summary>
        /// An object or array of objects that will provide custom functionality for this component. The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.Component. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself. Each plugin can then call methods or respond to events on the component as needed to provide its functionality.
        /// </summary>
        public object[] Plugins
        {
            get;
            set;
        }

        /// <summary>
        /// The data used by renderTpl in addition to the following property values of the component:
        /// id
        /// ui
        /// uiCls
        /// baseCls
        /// componentCls
        /// frame
        /// See renderSelectors and childEls for usage examples.
        /// </summary>
        public object RenderData
        {
            get;
            set;
        }

        /// <summary>
        /// An object containing properties specifying DomQuery selectors which identify child elements created by the render process.
        /// After the Component's internal structure is rendered according to the renderTpl, this object is iterated through, and the found Elements are added as properties to the Component using the renderSelector property name.
        /// </summary>
        public object RenderSelectors
        {
            get;
            set;
        }

        /// <summary>
        /// Specify the id of the element, a DOM element or an existing Element that this component will be rendered into.
        /// </summary>
        public virtual string RenderTo
        {
            get;
            set;
        }

        /// <summary>
        /// An XTemplate used to create the internal structure inside this Component's encapsulating Element.
        /// </summary>
        public string RenderTpl
        {
            get;
            set;
        }

        /// <summary>
        /// A custom style specification to be applied to this component's Element. Should be a valid argument to Ext.Element.applyStyles.
        /// </summary>
        public string Style
        {
            get;
            set;
        }

        /// <summary>
        /// The class that is added to the content target when you set styleHtmlContent to true.
        /// </summary>
        [DefaultValue("x-html")]
        public string StyleHtmlCls
        {
            get;
            set;
        }

        /// <summary>
        /// True to automatically style the html inside the content target of this component (body for panels).
        /// </summary>
        [DefaultValue(false)]
        public bool StyleHtmlContent
        {
            get;
            set;
        }

        /// <summary>
        /// An Ext.Template, Ext.XTemplate or an array of strings to form an Ext.XTemplate. Used in conjunction with the data and tplWriteMode configurations.
        /// </summary>
        public string Tpl
        {
            get;
            set;
        }

        /// <summary>
        /// The Ext.(X)Template method to use when updating the content area of the Component.
        /// </summary>
        public string TplWriteMode
        {
            get;
            set;
        }

        /// <summary>
        /// A set style for a component. Can be a string or an Array of multiple strings (UIs)
        /// </summary>
        [DefaultValue("default")]
        public string Ui
        {
            get;
            set;
        }

        /// <summary>
        /// The width of this component in pixels.
        /// </summary>
        public virtual int? Width
        {
            get;
            set;
        }

        /// <summary>
        /// The xtype configuration option can be used to optimize Component creation and rendering. It serves as a shortcut to the full componet name. For example, the component Ext.button.Button has an xtype of button.
        /// </summary>
        public string XType
        {
            get;
            set;
        }
    }
}