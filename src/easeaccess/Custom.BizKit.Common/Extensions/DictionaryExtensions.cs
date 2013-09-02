using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Extensions
{
    using Dictionary = Dictionary<string, object>;

    public static class DictionaryExtensions
    {
        public static object Get(this Dictionary instance, string name)
        {
            var index = name.IndexOf('.');
            var key = index < 0 ? name : name.Substring(0, index);

            object value;
            if (!instance.TryGetValue(key, out value) || value == null)
                return null;

            if (index < 0)
                return value;

            name = name.Substring(index + 1);

            if (value is Dictionary)
                return Get(value as Dictionary, name);

            throw new NotImplementedException();
        }

        public static object Invoke(this Dictionary instance, string key, object[] args)
        {
            Delegate method = instance.Get(key) as Delegate;
            if (method == null)
                return null;

            return method.DynamicInvoke(args);
        }

        public static void Set(this Dictionary instance, string key, object value)
        {
            instance[key] = value;
        }
    }
}
