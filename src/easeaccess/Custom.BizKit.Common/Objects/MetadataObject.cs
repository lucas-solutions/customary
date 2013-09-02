using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Objects
{
    using Newtonsoft.Json.Linq;

    public class MetadataObject
    {
        protected static void Set(JObject json, string name, JObject value)
        {
            if (value != null)
            {
                json.Add(name, value);
            }
        }

        protected static void Set<T>(JObject json, string name, T value)
            where T : class
        {
            if (value != null)
            {
                json.Add(name, new JObject(value));
            }
        }

        protected static void Set<T>(JObject json, string name, T? nullable)
            where T : struct
        {
            if (nullable.HasValue)
            {
                json.Add(name, new JValue(nullable.Value));
            }
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name ?? base.ToString();
        }
    }
}
