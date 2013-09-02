using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Extensions
{
    using ConcurrentDictionary = ConcurrentDictionary<string, object>;

    public static class ConcurrentDictionaryExtensions
    {
        public static object Get(this ConcurrentDictionary instance, string name)
        {
            var index = name.IndexOf('.');
            var key = index < 0 ? name : name.Substring(0, index);
            
            object value;
            if (!instance.TryGetValue(key, out value) || value == null)
                return null;

            if (index < 0)
                return value;

            name = name.Substring(index + 1);
            
            if (value is ConcurrentDictionary)
                return Get(value as ConcurrentDictionary, name);

            throw new NotImplementedException();
        }

        public static object Invoke(this ConcurrentDictionary instance, string key, object[] args)
        {
            var method = instance.Get(key) as Delegate;
            
            if (method == null)
                return null;

            return method.DynamicInvoke(args);
        }

        public static void Set(this ConcurrentDictionary instance, string name, object value)
        {
            var index = name.IndexOf('.');
            var key = index < 0 ? name : name.Substring(0, index);

            if (index < 0)
            {
                instance.AddOrUpdate(key, value, (string n, object o) =>
                {
                    return value;
                });
            }
            else
            {
                var container = instance.Get(key) as ConcurrentDictionary;
                if (container == null)
                {
                    container = new ConcurrentDictionary();
                    instance.TryUpdate(key, container, container);
                }
                container.Set(name.Substring(index + 1), value);
            }
        }
    }
}
