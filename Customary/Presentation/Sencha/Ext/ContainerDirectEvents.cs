using System.Xml.Serialization;

namespace Custom.Presentation.Sencha.Ext
{
    using Newtonsoft.Json;

    [System.ComponentModel.Description("")]
    public class ContainerDirectEvents : AbstractComponentDirectEvents
    {
        private ComponentDirectEvent add;
        private ComponentDirectEvent afterLayout;
        private ComponentDirectEvent beforeAdd;
        private ComponentDirectEvent beforeRemove;
        private ComponentDirectEvent remove;

        public ContainerDirectEvents()
        {
        }

        public ContainerDirectEvents(Observable parent)
        {
            this.Parent = parent;
        }

        [ConfigOption("add", typeof(DirectEventJsonConverter)), ListenerArgument(1, "component", typeof(AbstractComponent), "The component that was added"), ListenerArgument(2, "index", typeof(int), "The index at which the component was added to the container's items collection"), System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter)), ListenerArgument(0, "item", typeof(AbstractContainer), "this"), System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty), System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description("Fires after any AbstractComponent is added or inserted into the content Container.")]
        public virtual ComponentDirectEvent Add
        {
            get
            {
                return (this.add ?? (this.add = new ComponentDirectEvent(this)));
            }
        }

        [ListenerArgument(0, "item", typeof(AbstractContainer), "this"), ListenerArgument(1, "layout", typeof(object), "The ContainerLayout implementation for this container"), System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter)), ConfigOption("afterlayout", typeof(DirectEventJsonConverter)), System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty), System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description("Fires when the components in this container are arranged by the associated layout manager.")]
        public virtual ComponentDirectEvent AfterLayout
        {
            get
            {
                return (this.afterLayout ?? (this.afterLayout = new ComponentDirectEvent(this)));
            }
        }

        [System.ComponentModel.NotifyParentProperty(true), ListenerArgument(1, "component", typeof(AbstractComponent), "The component that was added"), ListenerArgument(2, "index", typeof(int), "The index at which the component was added to the container's items collection"), System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter)), ConfigOption("beforeadd", typeof(DirectEventJsonConverter)), System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty), ListenerArgument(0, "item", typeof(AbstractContainer), "this"), System.ComponentModel.Description("Fires before any AbstractComponent is added or inserted into the content Container. A handler can return false to cancel the add.")]
        public virtual ComponentDirectEvent BeforeAdd
        {
            get
            {
                return (this.beforeAdd ?? (this.beforeAdd = new ComponentDirectEvent(this)));
            }
        }

        [ListenerArgument(0, "item", typeof(AbstractContainer), "this"), ListenerArgument(1, "component", typeof(AbstractComponent), "The component being removed"), System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter)), ConfigOption("beforeremove", typeof(DirectEventJsonConverter)), System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty), System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description("Fires before any AbstractComponent is removed from the content Container. A handler can return false to cancel the remove.")]
        public virtual ComponentDirectEvent BeforeRemove
        {
            get
            {
                return (this.beforeRemove ?? (this.beforeRemove = new ComponentDirectEvent(this)));
            }
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), System.ComponentModel.Browsable(false), XmlIgnore, JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection configOptions = base.ConfigOptions;
                configOptions.Add("add", new ConfigOption("add", new SerializationOptions("add", typeof(DirectEventJsonConverter)), null, this.Add));
                configOptions.Add("afterLayout", new ConfigOption("afterLayout", new SerializationOptions("afterlayout", typeof(DirectEventJsonConverter)), null, this.AfterLayout));
                configOptions.Add("beforeAdd", new ConfigOption("beforeAdd", new SerializationOptions("beforeadd", typeof(DirectEventJsonConverter)), null, this.BeforeAdd));
                configOptions.Add("beforeRemove", new ConfigOption("beforeRemove", new SerializationOptions("beforeremove", typeof(DirectEventJsonConverter)), null, this.BeforeRemove));
                configOptions.Add("remove", new ConfigOption("remove", new SerializationOptions("remove", typeof(DirectEventJsonConverter)), null, this.Remove));
                return configOptions;
            }
        }

        [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter)), ListenerArgument(1, "component", typeof(AbstractComponent), "The component that was removed"), ListenerArgument(0, "item", typeof(AbstractContainer), "this"), ConfigOption("remove", typeof(DirectEventJsonConverter)), System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty), System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description("Fires after any AbstractComponent is removed from the content Container.")]
        public virtual ComponentDirectEvent Remove
        {
            get
            {
                return (this.remove ?? (this.remove = new ComponentDirectEvent(this)));
            }
        }
    }
}