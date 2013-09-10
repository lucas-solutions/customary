using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Utilities
{
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public static class ObjectUtils
    {
        public static object Apply(object to, object from)
        {
            return Apply(to, from, true);
        }

        public static object Apply(object to, object from, bool ignoreDefaultValues)
        {
            object obj2 = null;
            object defaultValue = null;
            foreach (PropertyInfo info2 in from.GetType().GetProperties())
            {
                if (info2.CanRead)
                {
                    obj2 = info2.GetValue(from, null);
                    if (ignoreDefaultValues)
                    {
                        defaultValue = ReflectionUtils.GetDefaultValue(info2);
                        if ((obj2 != null) && obj2.Equals(defaultValue))
                        {
                            continue;
                        }
                    }
                    if (obj2 != null)
                    {
                        PropertyInfo property = to.GetType().GetProperty(info2.Name, BindingFlags.Public | BindingFlags.Instance);
                        if (((property != null) && property.CanWrite) && ((property != null) && property.GetType().Equals(info2.GetType())))
                        {
                            property.SetValue(to, obj2, null);
                        }
                    }
                }
            }
            return to;
        }

        public static T If<T>(this T value, Func<bool> test, T valueIfTrue, T valueIfFalse)
        {
            if (!test())
            {
                return valueIfFalse;
            }
            return valueIfTrue;
        }

        public static T IfNot<T>(this T value, Func<bool> test, T valueIfTrue, T valueIfFalse)
        {
            if (test())
            {
                return valueIfFalse;
            }
            return valueIfTrue;
        }

        public static T IfNull<T>(this T value, T valueIfNull)
        {
            return value.If<T>(() => value.IsNull(), valueIfNull, value);
        }

        public static bool IsNull(this object instance)
        {
            return (instance == null);
        }
    }
}