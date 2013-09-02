using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Extensions
{
    using Newtonsoft.Json.Linq;

    public static class JObjectExtensions
    {
        public static object Get(this JObject instance, string name)
        {
            var index = name.IndexOf('.');
            var key = index < 0 ? name : name.Substring(0, index);

            JToken token;
            if (!instance.TryGetValue(key, out token) || token == null)
                return null;

            if (index < 0)
                return token;

            name = name.Substring(index + 1);

            if (token is JObject)
                return Get(token as JObject, name);

            throw new NotImplementedException();
        }

        public static object Invoke(this JObject instance, string key, object[] args)
        {
            Delegate method = instance.Get(key) as Delegate;
            if (method == null)
                return null;

            return method.DynamicInvoke(args);
        }

        public static void Set(this JObject instance, string key, object value)
        {
            instance[key] = JToken.FromObject(value);
        }
    }
}
