using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Models
{
    using Custom.Extensions;
    using Newtonsoft.Json.Linq;
    

    public class JsonObject : DynamicObject<JObject>
    {
        public static implicit operator JsonObject(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);

            string json = null;
            using (var reader = new StreamReader(stream))
            {
               
                json = reader.ReadToEnd().Trim();
            }
            return !string.IsNullOrEmpty(json) && json.StartsWith("{") ? (JsonObject)json : null;
        }

        public static implicit operator string(JsonObject obj)
        {
            return obj._value.ToString();
        }

        public static implicit operator JsonObject(string json)
        {
            return new JsonObject(JObject.Parse(json));
        }

        public static implicit operator JObject(JsonObject obj)
        {
            return obj._value;
        }

        public static implicit operator JsonObject(JObject obj)
        {
            return new JsonObject(obj);
        }

        public JsonObject()
            : this(new JObject(), NullDefaults)
        {
        }

        public JsonObject(JObject value)
            : this(value, NullDefaults)
        {
        }

        public JsonObject(Func<string, object> defaults)
            : this(new JObject(), defaults)
        {
        }

        public JsonObject(JObject value, Func<string, object> defaults)
            : base(value, JObjectExtensions.Get, JObjectExtensions.Set, defaults, JObjectExtensions.Invoke)
        {
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
