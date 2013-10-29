using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    using Utilities;
    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Web;
    using System.Web.UI;
    using System.Xml.Serialization;

    [System.ComponentModel.DefaultProperty("Handler"), System.ComponentModel.ToolboxItem(false), System.ComponentModel.TypeConverter(typeof(ListenerConverter))]
    public class ComponentListener : BaseListener
    {
        [System.ComponentModel.Description("")]
        public virtual void Clear()
        {
            this.Fn = this.Handler = this.Scope = (string)(this.Delegate = "");
            this.Single = this.Normalized = this.StopPropagation = this.PreventDefault = (bool)(this.StopEvent = false);
            this.Delay = (int)(this.Buffer = 0);
        }

        [System.ComponentModel.Description("")]
        public override string ToString()
        {
            return this.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        [System.ComponentModel.Description("")]
        public string ToString(System.Globalization.CultureInfo culture)
        {
            return System.ComponentModel.TypeDescriptor.GetConverter(base.GetType()).ConvertToString(null, culture, this);
        }

        [System.ComponentModel.DefaultValue((string)null), ConfigOption("argumentsList", JsonMode.AlwaysArray), System.ComponentModel.Description(""), System.ComponentModel.NotifyParentProperty(true)]
        protected virtual System.Collections.Generic.List<string> ArgumentsListProxy
        {
            get
            {
                if (!this.BroadcastOnBus.IsNotEmpty())
                {
                    return null;
                }
                return base.ArgumentList;
            }
        }

        [System.ComponentModel.Description("True to initiate a postback."), ConfigOption, System.ComponentModel.DefaultValue(false), System.ComponentModel.NotifyParentProperty(true)]
        public virtual bool AutoPostBack
        {
            get
            {
                return base.State.Get<bool>("AutoPostBack", false);
            }
            set
            {
                base.State.Set("AutoPostBack", (bool)value);
            }
        }

        [System.ComponentModel.DefaultValue(""), System.ComponentModel.NotifyParentProperty(true), ConfigOption, System.ComponentModel.Description("")]
        public virtual string BroadcastOnBus
        {
            get
            {
                return base.State.Get<string>("BroadcastOnBus", "");
            }
            set
            {
                base.State.Set("BroadcastOnBus", value);
            }
        }

        [System.ComponentModel.Category("Behavior"), System.ComponentModel.Description("Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs."), System.ComponentModel.DefaultValue(false)]
        public virtual bool CausesValidation
        {
            get
            {
                return base.State.Get<bool>("CausesValidation", false);
            }
            set
            {
                base.State.Set("CausesValidation", (bool)value);
            }
        }

        [XmlIgnore, System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), JsonIgnore, System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), System.ComponentModel.Browsable(false)]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection configOptions = base.ConfigOptions;
                configOptions.Add("autoPostBack", new ConfigOption("autoPostBack", null, false, (bool)this.AutoPostBack));
                configOptions.Add("fnInternal", new ConfigOption("fnInternal", new SerializationOptions("fn", JsonMode.Raw), "", this.FnInternal));
                configOptions.Add("broadcastOnBus", new ConfigOption("broadcastOnBus", null, "", this.BroadcastOnBus));
                configOptions.Add("argumentsListProxy", new ConfigOption("argumentsListProxy", new SerializationOptions("argumentsList", JsonMode.AlwaysArray), null, this.ArgumentsListProxy));
                return configOptions;
            }
        }

        [System.ComponentModel.Category("Behavior"), System.ComponentModel.DefaultValue(""), System.ComponentModel.Description("PostBackEvent Argument")]
        public virtual string EventArgument
        {
            get
            {
                return base.State.Get<string>("EventArgument", "");
            }
            set
            {
                base.ViewState.set_Item("EventArgument", value);
            }
        }

        [System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.DefaultValue(""), System.ComponentModel.Description("The raw JavaScript function to be called when this Listener fires.")]
        public virtual string Fn
        {
            get
            {
                return base.State.Get<string>("Fn", "");
            }
            set
            {
                base.State.Set("Fn", value);
            }
        }

        /*[System.ComponentModel.Description(""), System.ComponentModel.DefaultValue(""), ConfigOption("fn", JsonMode.Raw)]
        protected internal virtual string FnInternal
        {
            get
            {
                string handler = this.Handler;
                if (this.Fn.IsEmpty() && (handler.IsNotEmpty() || this.AutoPostBack))
                {
                    if (handler.IsEmpty() && this.AutoPostBack)
                    {
                        return "function({0}){{{1}}}".FormatWith(((object[])new object[] { "", this.PostBackFunction }));
                    }
                    string script = TokenUtils.ParseTokens(handler, base.Owner);
                    if (this.AutoPostBack)
                    {
                        string str3 = script.Trim().EndsWith(";") ? ((string)"") : ((string)";");
                        script = script + str3 + this.PostBackFunction;
                    }
                    if (TokenUtils.IsRawToken(script))
                    {
                        string str4 = TokenUtils.ReplaceRawToken(script);
                        if (!str4.StartsWith("Ext."))
                        {
                            return str4;
                        }
                    }
                    return string.Format("function({0}){{{1}}}", ((System.Collections.IEnumerable)base.ArgumentList).Join(), TokenUtils.ReplaceRawToken(script));
                }
                if (!this.Fn.IsEmpty())
                {
                    return TokenUtils.ReplaceRawToken(TokenUtils.ParseTokens(this.Fn, base.Owner));
                }
                return "";
            }
        }*/

        [System.ComponentModel.DefaultValue(""), System.ComponentModel.Description("The JavaScript logic to be called when this Listener fires. The Handler will be automatically wrapped in a proper function(){} template and passed the correct arguments for this event."), System.ComponentModel.NotifyParentProperty(true)]
        public virtual string Handler
        {
            get
            {
                return base.State.Get<string>("Handler", "");
            }
            set
            {
                base.State.Set("Handler", value);
            }
        }

        [System.ComponentModel.Description("Are all the properties still set with their default values, except .Fn or .Handler."), System.ComponentModel.Browsable(false), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual bool IsAlmostDefault
        {
            get
            {
                return (bool)((((this.Fn.IsNotEmpty() || this.Handler.IsNotEmpty()) || (this.AutoPostBack || this.BroadcastOnBus.IsNotEmpty())) && (((this.Delegate.IsEmpty() && !this.StopEvent) && (!this.PreventDefault && !this.StopPropagation)) && ((!this.Normalized && this.Scope.IsEmpty()) && ((this.Delay == 0) && !this.Single)))) && ((bool)(this.Buffer == 0)));
            }
        }

        [System.ComponentModel.Description("")]
        public override bool IsDefault
        {
            get
            {
                return (bool)(((this.Fn.IsEmpty() && this.Handler.IsEmpty()) && !this.AutoPostBack) && this.BroadcastOnBus.IsEmpty());
            }
        }

        /*[System.ComponentModel.Description(""), Meta, System.ComponentModel.DefaultValue("")]
        public virtual string PostBackEvent
        {
            get
            {
                return base.State.Get<string>("PostBackEvent", "");
            }
            set
            {
                base.State.Set("PostBackEvent", value);
            }
        }*/

        /*[System.ComponentModel.Description("")]
        protected virtual string PostBackFunction
        {
            get
            {
                string eventArgument = this.EventArgument;
                if ((System.Web.HttpContext.Current == null) || !(System.Web.HttpContext.Current.CurrentHandler is System.Web.UI.Page))
                {
                    return "";
                }
                System.Web.UI.Page currentHandler = (System.Web.UI.Page)System.Web.HttpContext.Current.CurrentHandler;
                if (this.CausesValidation)
                {
                    System.Web.UI.PostBackOptions options = new System.Web.UI.PostBackOptions(base.Owner, eventArgument);
                    options.set_ValidationGroup(this.ValidationGroup);
                    options.set_AutoPostBack(this.AutoPostBack);
                    options.set_PerformValidation(this.CausesValidation);
                    return currentHandler.ClientScript.GetPostBackEventReference(options, false).ConcatWith(";");
                }
                return currentHandler.ClientScript.GetPostBackEventReference(base.Owner, eventArgument).ConcatWith(";");
            }
        }*/

        /*[System.ComponentModel.Description("Gets or Sets the Controls ValidationGroup"), System.ComponentModel.DefaultValue(""), System.ComponentModel.Category("Behavior")]
        public virtual string ValidationGroup
        {
            get
            {
                return base.State.Get<string>("ValidationGroup", "");
            }
            set
            {
                base.ViewState.set_Item("ValidationGroup", value);
            }
        }*/
    }
}