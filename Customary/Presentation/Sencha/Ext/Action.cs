using System.ComponentModel;

namespace Custom.Presentation.Sencha.Ext
{
    /// <summary>
    /// An Action is a piece of reusable functionality that can be abstracted out of any particular component so that it can be usefully shared among multiple components. Actions let you share handlers, configuration options and UI updates across any components that support the Action interface (primarily Ext.toolbar.Toolbar, Ext.button.Button and Ext.menu.Menu components).
    /// Use a single Action instance as the config object for any number of UI Components which share the same configuration. The Action not only supplies the configuration, but allows all Components based upon it to have a common set of methods called at once through a single call to the Action.
    /// </summary>
    public class Action : Ext.Base
    {
        private Builder _builder;

        /// <summary>
        /// True to disable all components configured by this Action, false to enable them.
        /// </summary>
        [DefaultValue(false)]
        public bool Disabled
        {
            get;
            set;
        }

        /// <summary>
        /// The function that will be invoked by each component tied to this Action when the component's primary event is triggered.
        /// </summary>
        public ScriptFunction Handler
        {
            get;
            set;
        }

        /// <summary>
        /// True to hide all components configured by this Action, false to show them.
        /// </summary>
        [DefaultValue(false)]
        public bool Hidden
        {
            get;
            set;
        }

        /// <summary>
        /// The CSS class selector that specifies a background image to be used as the header icon for all components configured by this Action.
        /// </summary>
        [DefaultValue("")]
        public string IconCls
        {
            get;
            set;
        }

        /// <summary>
        /// See Ext.Component.itemId.
        /// </summary>
        public string ItemId
        {
            get;
            set;
        }

        /// <summary>
        /// The scope (this reference) in which the handler is executed. Defaults to the browser window.
        /// </summary>
        public string Scope
        {
            get;
            set;
        }

        /// <summary>
        /// The text to set for all components configured by this Action.
        /// </summary>
        [DefaultValue("")]
        public string Text
        {
            get;
            set;
        }

        public Builder ToBuilder()
        {
            return _builder ?? (_builder = new Builder(this));
        }

        public class Builder : Builder<Action, Builder>
        {
            public Builder(Action model)
                : base(model)
            {
            }

            /// <summary>
            /// True to disable all components configured by this Action, false to enable them.
            /// </summary>
            [DefaultValue(false)]
            public Builder Disabled(bool value)
            {
                ToModel().Disabled = value;
                return this;
            }

            /// <summary>
            /// The function that will be invoked by each component tied to this Action when the component's primary event is triggered.
            /// </summary>
            public Builder Handler(ScriptFunction value)
            {
                ToModel().Handler = value;
                return this;
            }

            /// <summary>
            /// True to hide all components configured by this Action, false to show them.
            /// </summary>
            [DefaultValue(false)]
            public Builder Hidden(bool value)
            {
                ToModel().Hidden = value;
                return this;
            }

            /// <summary>
            /// The CSS class selector that specifies a background image to be used as the header icon for all components configured by this Action.
            /// </summary>
            [DefaultValue("")]
            public Builder IconCls(string value)
            {
                ToModel().IconCls = value;
                return this;
            }

            /// <summary>
            /// See Ext.Component.itemId.
            /// </summary>
            public Builder ItemId(string value)
            {
                ToModel().ItemId = value;
                return this;
            }

            /// <summary>
            /// The scope (this reference) in which the handler is executed. Defaults to the browser window.
            /// </summary>
            public Builder Scope(string value)
            {
                ToModel().Scope = value;
                return this;
            }

            /// <summary>
            /// The text to set for all components configured by this Action.
            /// </summary>
            [DefaultValue("")]
            public Builder Text(string value)
            {
                ToModel().Text = value;
                return this;
            }
        }
    }
}