using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public class JField<TModel> : JObject<TModel>, IScriptable
        where TModel : class
    {
        Serializer _serializer;

        public JField()
        {
        }

        public void Assign(JObject<TModel> other)
        {
            Name = other.Name;
            Model = other.Model;
        }

        IScriptSerializer IScriptable.ToSerializer()
        {
            return ToSerializer();
        }

        public Serializer ToSerializer()
        {
            return  _serializer ?? (_serializer = new Serializer(this));
        }

        public class Serializer : Serializer<JField<TModel>, Serializer>
        {
            public Serializer(JField<TModel> field)
                : base(field)
            {
            }
        }

        public abstract class Serializer<TField, TSerializer> : IScriptSerializer
            where TField : JField<TModel>
            where TSerializer : Serializer<TField, TSerializer>
        {
            private readonly TField _field;

            protected Serializer(TField field)
            {
                _field = field;
            }

            public string[] Render()
            {
                //var name = Name ?? string.Empty;
                //var scriptable = Model as IScriptable;
                //if (scriptable != null)
                //    scriptable.Script(writer);
                //else
                //    writer.Write("'" + name + "'");
                return null;
            }

            public void Serialize(TextWriter writer)
            {
                throw new NotImplementedException();
            }
        }
    }
}