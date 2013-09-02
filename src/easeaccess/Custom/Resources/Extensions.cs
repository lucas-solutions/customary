using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    public static class Extensions
    {
        

        public static string Stringify(this Guid guid)
        {
            return guid.ToString().ToString();
        }

        public static int Each<T>(this IEnumerable<T> collection, Action<T> action)
        {
            var count = 0;
            foreach (var item in collection)
            {
                action(item);
            }
            return count;
        }
    }
}