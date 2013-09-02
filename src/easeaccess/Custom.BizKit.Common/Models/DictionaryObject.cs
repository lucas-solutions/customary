using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Models
{
    using Custom.Extensions;
    
    using Dictionary = Dictionary<string, object>;

    public class DictionaryObject : DynamicObject<Dictionary>
    {
        public static implicit operator DictionaryObject(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);

            string json = null;
            using (var reader = new StreamReader(stream))
            {

                json = reader.ReadToEnd().Trim();
            }
            return !string.IsNullOrEmpty(json) && json.StartsWith("{") ? (DictionaryObject)json : null;
        }

        public static implicit operator DictionaryObject(string json)
        {
            var dic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary>(json);
            return new DictionaryObject(dic);
        }

        public DictionaryObject()
            : this(new Dictionary(), NullDefaults)
        {
        }

        public DictionaryObject(Dictionary value)
            : this(value, NullDefaults)
        {
        }

        public DictionaryObject(Func<string, object> defaults)
            : this(new Dictionary(), defaults)
        {
        }

        public DictionaryObject(Dictionary value, Func<string, object> defaults)
            : base(value, DictionaryExtensions.Get, DictionaryExtensions.Set, defaults, DictionaryExtensions.Invoke)
        {
        }
    }
}
