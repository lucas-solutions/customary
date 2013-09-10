using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    partial class Field
    {
        public class Serializer : Field.Serializer<Field, Field.Serializer>
        {
            public Serializer()
                : base()
            {
            }

            public Serializer(Field model)
                : base(model)
            {
            }
        }

        public new abstract class Serializer<TModel, TSerializer> : Base.Serializer<TModel, TSerializer>
            where TModel : Field
            where TSerializer : Field.Serializer<TModel, TSerializer>
        {
            public Serializer()
                : base(null)
            {
            }

            public Serializer(TModel model)
                : base(model)
            {
            }

            protected override void Serialize(TModel model, ScriptWriter writer)
            {
                if (model.Convert != null)
                {
                    writer.WriteLine("{");
                    writer.WriteLine("name: '" + model.Name + "'");
                    writer.WriteLine("type: '" + model.Type + "'");
                    writer.WriteLine("convert: ");
                    model.Convert(writer, model);
                    writer.Write("}");
                }
                else if (model.Type != "string")
                {
                    writer.Write("{ name: '" + model.Name + "', type: '" + model.Type + "' }");
                }
                else
                {
                    writer.Write("'" + model.Name + "'");
                }
            }
        }
    }
}