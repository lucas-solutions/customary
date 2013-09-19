using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    /// <summary>
    /// Handles class creation throughout the framework. This is a low level factory that is used by Ext.ClassManager and generally should not be used directly. If you choose to use Ext.Class you will lose out on the namespace, aliasing and depency loading features made available by Ext.ClassManager. The only time you would use Ext.Class directly is to create an anonymous class.
    /// </summary>
    public abstract class Class : Ext.Base
    {
        private List<string> _alias;
        private Mixins _mixins;
        private Requires _requires;

        /// <summary>
        /// List of short aliases for class names. Most useful for defining xtypes for widgets.
        /// </summary>
        public List<string> Alias
        {
            get { return _alias ?? (_alias = new List<string>()); }
        }

        /// <summary>
        /// Defines alternate names for this class.
        /// </summary>
        public List<string> /*String/String[]*/ AlternateClassName
        {
            get;
            set;
        }

        /// <summary>
        /// List of configuration options with their default values, for which automatically accessor methods are generated.
        /// </summary>
        public object Config
        {
            get;
            set;
        }

        /// <summary>
        /// The parent class that this class extends.
        /// </summary>
        public string Extend
        {
            get;
            set;
        }

        /// <summary>
        /// List of inheritable static methods for this class. Otherwise just like statics but subclasses inherit these methods.
        /// </summary>
        public List<string> InheritableStatics
        {
            get;
            set;
        }

        public Mixins Mixins
        {
            get { return _mixins ?? (_mixins = new Mixins()); }
        }

        /// <summary>
        /// Defines an override applied to a class.
        /// </summary>
        public string Override
        {
            get;
            set;
        }

        /// <summary>
        /// List of classes that have to be loaded before instantiating this class.
        /// </summary>
        public Requires Requires
        {
            get { return _requires ?? (_requires = new Requires()); }
        }


        /// <summary>
        /// When set to true, the class will be instantiated as singleton.
        /// </summary>
        public bool Singleton
        {
            get;
            set;
        }

        /// <summary>
        /// List of static methods for this class.
        /// </summary>
        public Dictionary<string, ScriptFunction> Statics
        {
            get;
            set;
        }

        /// <summary>
        /// List of classes to load together with this class. These aren't neccessarily loaded before this class is instantiated.
        /// </summary>
        public List<string> Uses
        {
            get;
            set;
        }

        public new abstract class Builder<TModel, TBuilder> : Ext.Base.Builder<TModel, TBuilder>
            where TModel : Class
            where TBuilder : Builder<TModel, TBuilder>
        {
            private string _define;
            private List<object> _resources;

            protected List<object> Resources
            {
                get { return _resources ?? (_resources = new List<object>()); }
            }

            public Builder(TModel model)
                : base(model)
            {
                Property(o => o.Extend, (lines, parent) =>
                {
                    if (!string.IsNullOrEmpty(_define))
                        lines.Append('\'' + (parent ?? ToModel().GetType().ClassName()) + '\'');
                });

                Property(o => o.Mixins, (lines, mixins) =>
                {
                    // don't render
                    return;

                    var type = _define ?? ToModel().GetType().ClassName();
                    if (mixins != null && mixins.Count > 0)
                    {
                        lines.Append('{');
                        foreach (var item in mixins)
                        {
                            var name = item.Key;
                            var mixin = item.Value;
                            if (type.Equals(mixin.Owner))
                            {
                                lines.Add(name.CamelCase() + ": \'" + mixin.Class + "\'", INDENT);
                            }
                        }
                        lines.Add('}');
                    }
                });

                Property(o => o.Requires, (lines, requires) =>
                {
                    // don't render
                    return;

                    var type = _define ?? ToModel().GetType().ClassName();
                    if (requires != null && requires.Count > 0)
                    {
                        lines.Append('[');
                        foreach (var require in requires)
                        {
                            if (type.Equals(require.Owner))
                            {
                                lines.Add('\'' + require.Class + '\'', INDENT);
                            }
                        }
                        lines.Add(']');
                    }
                });
            }

            public TBuilder Create()
            {
                _define = null;
                return (TBuilder)this;
            }

            public TBuilder Define(string name)
            {
                _define = name;
                return (TBuilder)this;
            }

            public TBuilder Extend(string value)
            {
                ToModel().Extend = value;
                return (TBuilder)this;
            }

            public TBuilder Resource(object resource)
            {
                Resources.Add(resource);
                return (TBuilder)this;
            }

            public override void Render(List<string> lines)
            {
                if (string.IsNullOrEmpty(_define))
                    RenderCreate(lines);
                else
                    RenderDefine(lines, _define);
            }

            protected virtual void RenderCreate(List<string> lines)
            {
                var block = new List<string>();
                base.Render(block);

                lines.Add("Ext.create(\"" + ToModel().GetType().ClassName() + "\", ");
                lines.Append(block, string.Empty);
                lines.Append(");");
            }

            protected virtual void RenderDefine(List<string> lines, string name)
            {
                var block = new List<string>();
                base.Render(block);

                lines.Add("Ext.define(\"" + name + "\", function {");

                RenderResources(lines);

                lines.Add();
                lines.Add(INDENT + "return ");
                lines.Append(block, INDENT);
                lines.Append(';');
                lines.Add("});");
            }

            protected virtual void RenderResources(List<string> lines)
            {
                if (_resources != null && _resources.Count > 0)
                {
                    var block = new List<string>();
                    foreach (var resource in _resources)
                    {
                        if (RenderValue(resource, block))
                        {
                            lines.Add();
                            lines.Add(block, INDENT);
                            if (!lines.EndsWith(';'))
                                lines.Append(';');
                            block.Clear();
                        }
                    }
                }
            }
        }
    }
}