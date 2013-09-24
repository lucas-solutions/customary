using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom
{
    public static class TypeExtensions
    {
        public static bool Is(this Type type, Type test)
        {
            if (type == null || test == null)
                return false;

            if (test.IsAssignableFrom(type))
                return true;

            if (type.IsSubclassOf(test))
                return true;

            return false;
        }
    }
}