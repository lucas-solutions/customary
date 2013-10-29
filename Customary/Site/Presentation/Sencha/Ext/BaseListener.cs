using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using System.Xml.Serialization;

    [System.ComponentModel.Description("")]
    public class BaseListener : BaseItem
    {
        private System.Collections.Generic.List<string> argumentList;

        [System.ComponentModel.Description("")]
        public void ClearListenerConfig()
        {
            base.State.Set("Scope", null);
            base.State.Set("Buffer", null);
            base.State.Set("Delay", null);
            base.State.Set("Single", null);
            base.State.Set("Delegate", null);
            base.State.Set("Normalized", null);
            base.State.Set("PreventDefault", null);
            base.State.Set("StopEvent", null);
            base.State.Set("StopPropagation", null);
        }

        [System.ComponentModel.Description("")]
        public HandlerConfig GetListenerConfig()
        {
            return new HandlerConfig { Scope = (this.Scope == "this") ? null : this.Scope, Buffer = this.Buffer, Delay = this.Delay, Single = this.Single, Delegate = (this.Delegate == "") ? null : this.Delegate, Normalized = this.Normalized, PreventDefault = this.PreventDefault, StopEvent = this.StopEvent, StopPropagation = this.StopPropagation };
        }

        internal void SetArgumentList(System.Reflection.PropertyInfo property)
        {
            System.Collections.Generic.List<ListenerArgumentAttribute> list = new System.Collections.Generic.List<ListenerArgumentAttribute>();
            object[] customAttributes = property.GetCustomAttributes(typeof(ListenerArgumentAttribute), false);
            for (int i = 0; i < customAttributes.Length; i = (int)(i + 1))
            {
                ListenerArgumentAttribute attribute = (ListenerArgumentAttribute)customAttributes[i];
                list.Add(attribute);
            }
            list.Sort(new ListenerArgumentAttributeComparer());
            System.Collections.Generic.List<string> list2 = new System.Collections.Generic.List<string>();
            foreach (ListenerArgumentAttribute attribute2 in list)
            {
                list2.Add(attribute2.Name);
            }
            this.argumentList = list2;
        }

        [System.ComponentModel.Description("List of Arguments passed to event handler.")]
        internal System.Collections.Generic.List<string> ArgumentList
        {
            get
            {
                if (this.argumentList == null)
                {
                    this.argumentList = new System.Collections.Generic.List<string>();
                }
                return this.argumentList;
            }
        }

        [System.ComponentModel.DefaultValue(0), ConfigOption, System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description("Causes the handler to be scheduled to run in an Ext.util.DelayedTask delayed by the specified number of milliseconds. If the event fires again within that time, the original handler is not invoked, but the new handler is scheduled in its place.")]
        public virtual int Buffer
        {
            get
            {
                return base.State.Get<int>("Buffer", 0);
            }
            set
            {
                base.State.Set("Buffer", (int)value);
            }
        }

        [XmlIgnore, System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), System.ComponentModel.Browsable(false), JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection configOptions = base.ConfigOptions;
                configOptions.Add("scope", new ConfigOption("scope", new SerializationOptions(JsonMode.Raw), "this", this.Scope));
                configOptions.Add("delegate", new ConfigOption("delegate", null, "", this.Delegate));
                configOptions.Add("stopEvent", new ConfigOption("stopEvent", null, false, (bool)this.StopEvent));
                configOptions.Add("preventDefault", new ConfigOption("preventDefault", null, false, (bool)this.PreventDefault));
                configOptions.Add("stopPropagation", new ConfigOption("stopPropagation", null, false, (bool)this.StopPropagation));
                configOptions.Add("normalized", new ConfigOption("normalized", null, false, (bool)this.Normalized));
                configOptions.Add("delay", new ConfigOption("delay", null, 0, (int)this.Delay));
                configOptions.Add("single", new ConfigOption("single", null, false, (bool)this.Single));
                configOptions.Add("buffer", new ConfigOption("buffer", null, 0, (int)this.Buffer));
                return configOptions;
            }
        }

        [System.ComponentModel.DefaultValue(0), System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description("The number of milliseconds to delay the invocation of the handler after the event fires."), ConfigOption]
        public virtual int Delay
        {
            get
            {
                return base.State.Get<int>("Delay", 0);
            }
            set
            {
                base.State.Set("Delay", (int)value);
            }
        }

        [ConfigOption, System.ComponentModel.DefaultValue(""), System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description("A simple selector to filter the target or look for a descendant of the target")]
        public virtual string Delegate
        {
            get
            {
                return base.State.Get<string>("Delegate", "");
            }
            set
            {
                base.State.Set("Delegate", value);
            }
        }

        public virtual bool HasOwnDelay
        {
            get
            {
                return (bool)(base.State.Get<int>("Delay", -2147483648) != -2147483648);
            }
        }

        [System.ComponentModel.DefaultValue(false), ConfigOption, System.ComponentModel.Description("False to pass a browser event to the handler function instead of an Ext.EventObject."), System.ComponentModel.NotifyParentProperty(true)]
        public virtual bool Normalized
        {
            get
            {
                return base.State.Get<bool>("Normalized", false);
            }
            set
            {
                base.State.Set("Normalized", (bool)value);
            }
        }

        [System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.DefaultValue(false), ConfigOption, System.ComponentModel.Description("True to prevent the default action.")]
        public virtual bool PreventDefault
        {
            get
            {
                return base.State.Get<bool>("PreventDefault", false);
            }
            set
            {
                base.State.Set("PreventDefault", (bool)value);
            }
        }

        [System.ComponentModel.DefaultValue("this"), ConfigOption(JsonMode.Raw), System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description("The scope in which to execute the handler function. The handler function's 'this' context.")]
        public virtual string Scope
        {
            get
            {
                return base.State.Get<string>("Scope", "this");
            }
            set
            {
                base.State.Set("Scope", value);
            }
        }

        [ConfigOption, System.ComponentModel.Description("True to add a handler to handle just the next firing of the event, and then remove itself."), System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.DefaultValue(false)]
        public virtual bool Single
        {
            get
            {
                return base.State.Get<bool>("Single", false);
            }
            set
            {
                base.State.Set("Single", (bool)value);
            }
        }

        [System.ComponentModel.DefaultValue(false), ConfigOption, System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description("True to stop the event. That is stop propagation, and prevent the default action.")]
        public virtual bool StopEvent
        {
            get
            {
                return base.State.Get<bool>("StopEvent", false);
            }
            set
            {
                base.State.Set("StopEvent", (bool)value);
            }
        }

        [ConfigOption, System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description("True to prevent event propagation."), System.ComponentModel.DefaultValue(false)]
        public virtual bool StopPropagation
        {
            get
            {
                return base.State.Get<bool>("StopPropagation", false);
            }
            set
            {
                base.State.Set("StopPropagation", (bool)value);
            }
        }

        [System.ComponentModel.Description("")]
        public class ListenerArgumentAttributeComparer : System.Collections.Generic.IComparer<ListenerArgumentAttribute>
        {
            [System.ComponentModel.Description("")]
            public int Compare(ListenerArgumentAttribute obj1, ListenerArgumentAttribute obj2)
            {
                return ((int)obj1.Index).CompareTo(obj2.Index);
            }
        }
    }
}