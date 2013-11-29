using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.Web.UI;
    using System.Xml.Serialization;

    [System.ComponentModel.Description("")]
    public class ContainerListeners : AbstractComponentListeners
    {
        private ComponentListener add;
        private ComponentListener afterLayout;
        private ComponentListener beforeAdd;
        private ComponentListener beforeRemove;
        private ComponentListener remove;

        [System.ComponentModel.NotifyParentProperty(true), ListenerArgument(0, "item", typeof(AbstractContainer), "this"), System.ComponentModel.Description("Fires after any AbstractComponent is added or inserted into the content Container."), ListenerArgument(1, "component", typeof(AbstractComponent), "The component that was added"), ListenerArgument(2, "index", typeof(int), "The index at which the component was added to the container's items collection"), System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter)), ConfigOption("add", typeof(ListenerJsonConverter)), System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty)]
        public virtual ComponentListener Add
        {
            get
            {
                return (this.add ?? (this.add = new ComponentListener()));
            }
        }

        [ListenerArgument(0, "item", typeof(AbstractContainer), "this"), ConfigOption("afterlayout", typeof(ListenerJsonConverter)), System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty), System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description("Fires when the components in this container are arranged by the associated layout manager."), System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter)), ListenerArgument(1, "layout", typeof(object), "The ContainerLayout implementation for this container")]
        public virtual ComponentListener AfterLayout
        {
            get
            {
                return (this.afterLayout ?? (this.afterLayout = new ComponentListener()));
            }
        }

        [ConfigOption("beforeadd", typeof(ListenerJsonConverter)), ListenerArgument(2, "index", typeof(int), "The index at which the component was added to the container's items collection"), System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter)), ListenerArgument(0, "item", typeof(AbstractContainer), "this"), System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty), System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description("Fires before any AbstractComponent is added or inserted into the content Container. A handler can return false to cancel the add."), ListenerArgument(1, "component", typeof(AbstractComponent), "The component that was added")]
        public virtual ComponentListener BeforeAdd
        {
            get
            {
                return (this.beforeAdd ?? (this.beforeAdd = new ComponentListener()));
            }
        }

        [ListenerArgument(0, "item", typeof(AbstractContainer), "this"), ConfigOption("beforeremove", typeof(ListenerJsonConverter)), System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty), System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description("Fires before any AbstractComponent is removed from the content Container. A handler can return false to cancel the remove."), ListenerArgument(1, "component", typeof(AbstractComponent), "The component being removed"), System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
        public virtual ComponentListener BeforeRemove
        {
            get
            {
                return (this.beforeRemove ?? (this.beforeRemove = new ComponentListener()));
            }
        }

        [JsonIgnore, System.ComponentModel.Browsable(false), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), XmlIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection configOptions = base.ConfigOptions;
                configOptions.Add("add", new ConfigOption("add", new SerializationOptions("add", typeof(ListenerJsonConverter)), null, this.Add));
                configOptions.Add("afterLayout", new ConfigOption("afterLayout", new SerializationOptions("afterlayout", typeof(ListenerJsonConverter)), null, this.AfterLayout));
                configOptions.Add("beforeAdd", new ConfigOption("beforeAdd", new SerializationOptions("beforeadd", typeof(ListenerJsonConverter)), null, this.BeforeAdd));
                configOptions.Add("beforeRemove", new ConfigOption("beforeRemove", new SerializationOptions("beforeremove", typeof(ListenerJsonConverter)), null, this.BeforeRemove));
                configOptions.Add("remove", new ConfigOption("remove", new SerializationOptions("remove", typeof(ListenerJsonConverter)), null, this.Remove));
                return configOptions;
            }
        }

        [System.ComponentModel.NotifyParentProperty(true), System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty), System.ComponentModel.Description("Fires after any AbstractComponent is removed from the content Container."), ListenerArgument(1, "component", typeof(AbstractComponent), "The component that was removed"), System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter)), ConfigOption("remove", typeof(ListenerJsonConverter)), ListenerArgument(0, "item", typeof(AbstractContainer), "this")]
        public virtual ComponentListener Remove
        {
            get
            {
                return (this.remove ?? (this.remove = new ComponentListener()));
            }
        }
    }
}