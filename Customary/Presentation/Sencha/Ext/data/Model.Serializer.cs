using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    partial class Model
    {
        private Serializer _serializer;

        public Serializer ToSerializer()
        {
            return _serializer ?? (_serializer = new Serializer(this));
        }

        protected override IScriptSerializer CreateSerializer()
        {
            return new Serializer(this);
        }

        public class Serializer : Model.Serializer<Model, Model.Serializer>
        {
            public Serializer()
                : this(new Model())
            {
            }

            internal Serializer(Model model)
                : base(model)
            {
                model._serializer = this;
            }
        }

        public new abstract class Serializer<TModel, TSerializer> : Base.Serializer<TModel, TSerializer>
            where TModel : Model
            where TSerializer : Model.Serializer<TModel, TSerializer>
        {
            public Serializer(TModel model)
                : base(model)
            {
            }

            protected override void Serialize(TModel model, ScriptWriter writer)
            {
                Write(writer);
            }

            private void Proxy(ScriptWriter writer)
            {
                var proxy = ToModel().Proxy;
                writer.Write("proxy: ");
                if (proxy == null)
                    writer.Write("null");
                IScriptable scriptable = proxy.Model;
                if (scriptable != null)
                    scriptable.Script(writer);
                else if (string.IsNullOrEmpty(proxy.Name))
                    writer.Write("null");
                else
                {
                    writer.Write('\'');
                    writer.Write(proxy.Name);
                    writer.Write('\'');
                }
            }

            public void Write(ScriptWriter writer)
            {
                var model = ToModel();
                writer.Write("Ext.regModel('" + model.Name + "', {");
                writer.WriteLine();
                Write(writer, model.Fields.Items);
                if (model.Associations != null && model.Associations.Count > 0)
                {
                    writer.Write(',');
                    writer.WriteLine();
                    Write(writer, model.Associations.Items);
                }
                if (model.Validations != null && model.Validations.Count > 0)
                {
                    writer.Write(',');
                    writer.WriteLine();
                    Write(writer, model.Validations.Items);
                }
                var proxy = model.Proxy;
                if (proxy != null)
                {
                    writer.Write(',');
                    writer.WriteLine();
                    Proxy(writer);
                }
                writer.WriteLine();
                writer.Write("});");
                writer.WriteLine();
            }

            private static void Write(ScriptWriter writer, IEnumerable<Field> list)
            {
                var enu = list.GetEnumerator();
                var any = enu.MoveNext();

                writer.Write("fields: [");
                writer.WriteLine();

                while (any)
                {
                    IScriptable scriptable = enu.Current;
                    scriptable.Script(writer);

                    if ((any = enu.MoveNext()))
                    {
                        writer.Write(',');
                    }

                    writer.WriteLine();
                }

                writer.Write("]");
            }

            private static void Write(ScriptWriter writer, IEnumerable<Association> list)
            {
                var enu = list.GetEnumerator();
                var any = enu.MoveNext();

                writer.Write("associations: [");
                writer.WriteLine();

                while (any)
                {
                    enu.Current.WriteTo(writer);

                    if ((any = enu.MoveNext()))
                    {
                        writer.Write(',');
                    }

                    writer.WriteLine();
                }

                writer.Write("]");

            }

            private static void Write(ScriptWriter writer, IEnumerable<Validation> list)
            {
                var enu = list.GetEnumerator();
                var any = enu.MoveNext();

                writer.Write("validations: [");
                writer.WriteLine();

                while (any)
                {
                    enu.Current.WriteTo(writer);

                    if ((any = enu.MoveNext()))
                    {
                        writer.Write(',');
                    }

                    writer.WriteLine();
                }

                writer.Write("]");
            }
        }
    }
}