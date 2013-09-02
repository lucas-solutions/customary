using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Models
{
    using Custom.Extensions;
    using ConcurrentDictionary = ConcurrentDictionary<string, object>;

    public class ConcurrentDictionaryObject : DynamicObject<ConcurrentDictionary>
    {
        public ConcurrentDictionaryObject()
            : this(new ConcurrentDictionary(), NullDefaults)
        {
        }

        public ConcurrentDictionaryObject(ConcurrentDictionary value)
            : this(value, NullDefaults)
        {
        }

        public ConcurrentDictionaryObject(Func<string, object> defaults)
            : this(new ConcurrentDictionary(), defaults)
        {
        }

        public ConcurrentDictionaryObject(ConcurrentDictionary value, Func<string, object> defaults)
            : base(value, ConcurrentDictionaryExtensions.Get, ConcurrentDictionaryExtensions.Set, defaults, ConcurrentDictionaryExtensions.Invoke)
        {
        }
    }
}
