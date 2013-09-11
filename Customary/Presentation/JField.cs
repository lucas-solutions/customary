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
        public JField()
        {
        }

        public void Assign(JObject<TModel> other)
        {
            Name = other.Name;
            Model = other.Model;
        }

        string[] IScriptable.Script
        {
            get { return Render(); }
        }

        private string[] Render()
        {
            //var name = Name ?? string.Empty;
            //var scriptable = Model as IScriptable;
            //if (scriptable != null)
            //    scriptable.Script(writer);
            //else
            //    writer.Write("'" + name + "'");
            return null;
        }

        IScriptSerializer IScriptable.ToSerializer()
        {
            return ToSerializer();
        }

        public Serializer ToSerializer()
        {
            return null;// _serializer ?? (_serializer = new Serializer(this));
        }

        void IScriptable.WriteTo(TextWriter writer)
        {
            writer.Write(Render());
        }

        public class Serializer : IScriptSerializer
        {
            public TSerializer Cast<TSerializer>() where TSerializer : class, IScriptSerializer
            {
                throw new NotImplementedException();
            }

            public void Serialize(TextWriter writer)
            {
                throw new NotImplementedException();
            }
        }
    }
}