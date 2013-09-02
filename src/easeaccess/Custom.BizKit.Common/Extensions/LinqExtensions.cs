using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Extensions
{
    public static class LinqExtensions
    {
        public static void NotNull<T>(this T arg, Action<T> action)
        {
            if (arg != null)
            {
                action(arg);
            }
        }

        public static void NotNull<T>(this T arg, Action<object> action)
        {
            if (arg != null)
            {
                action(arg);
            }
        }

        public static void Each<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }

        public static void Each<T, R>(this IEnumerable<T> collection, Func<T, R> fn)
        {
            foreach (var item in collection)
            {
                fn(item);
            }
        }
    }
}
