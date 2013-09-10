using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data.proxy
{
    partial class Proxy
    {
        public class Serializer : Proxy.Serializer<Proxy, Proxy.Serializer>
        {
            public Serializer()
                : base(null)
            {
            }

            public Serializer(Proxy model)
                : base(model)
            {
            }
        }

        public new abstract class Serializer<TModel, TSerializer> : Base.Serializer<TModel, TSerializer>
            where TModel : Proxy
            where TSerializer : Proxy.Serializer<TModel, TSerializer>
        {
            public Serializer(TModel model)
                : base(model)
            {
            }

            protected override void Serialize(TModel model, ScriptWriter writer)
            {
                writer.Write("{");
                writer.WriteLine();
                writer.Write("type: " + model.Type);
                writer.Write(',');
                writer.WriteLine();
                writer.Write("url: " + model.Url);

                if (model.Reader != null)
                {
                    var sriptable = model.Reader as IScriptable;
                    if (sriptable != null && !sriptable.IsEmpty)
                    {
                        writer.Write("reader: ");
                        sriptable.Script(writer);
                    }
                }

                if (model.Writer != null)
                {
                    var sriptable = model.Writer as IScriptable;
                    if (sriptable != null && !sriptable.IsEmpty)
                    {
                        writer.Write("writer: ");
                        sriptable.Script(writer);
                    }
                }

                writer.WriteLine();
                writer.Write("}");
            }
        }
    }
}