using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    partial class Base
    {
        public new abstract class Builder<TScript, TBuilder> : ScriptObject.Builder<TScript, TBuilder>
            where TScript : Base
            where TBuilder : Base.Builder<TScript, TBuilder>
        {
            private bool _define;
            private List<object> _resources;
            
            protected List<object> Resources
            {
                get { return _resources ?? (_resources = new List<object>()); }
            }

            public Builder(TScript model)
                : base(model)
            {
            }

            public TBuilder Create()
            {
                _define = false;
                return (TBuilder)this;
            }

            public TBuilder Define()
            {
                _define = true;
                return (TBuilder)this;
            }

            public TBuilder Extend(string value)
            {
                ToModel().Extend = value;
                return (TBuilder)this;
            }

            public TBuilder Name(string value)
            {
                ToModel().Name = value;
                return (TBuilder)this;
            }

            public TBuilder Resource(object resource)
            {
                Resources.Add(resource);
                return (TBuilder)this;
            }

            public override void Render(List<string> lines)
            {
                if (_define)
                    RenderDefine(lines);
                else
                    RenderCreate(lines);
            }

            protected virtual void RenderCreate(List<string> lines)
            {
                var block = new List<string>();
                base.Render(block);

                lines.Add("Ext.create(\"" + ToModel().Name + "\", ");
                lines.Append(block, string.Empty);
                lines.Append(");");
            }

            protected virtual void RenderDefine(List<string> lines)
            {
                var block = new List<string>();
                base.Render(block);

                lines.Add("Ext.define(\"" + ToModel().Name + "\", function {");

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
                            lines.AddRange(block);
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