using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Custom.Presentation.Sencha.Ext
{
    public struct Mixin
    {
        public string Owner;
        public string Class;
        public object Instance;
    }

    public class Mixins : Dictionary<string, Mixin>
    {
        public T Get<T>(string owner = null)
            where T : class, new()
        {
            var type = typeof(T);
            var name = type.Name;
            
            Mixin mixin;
            if (TryGetValue(name, out mixin) && mixin.Instance != null && mixin.Instance is T)
                return mixin as T;

            var instance = new T();
            
            Add(name, new Mixin
            {
                Owner = owner ?? new StackFrame(1).GetMethod().DeclaringType.Name,
                Class = type.ClassName(),
                Instance = instance
            });

            return instance;
        }
    }
}