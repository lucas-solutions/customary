using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation.Utilities
{
    public static class EnumerableUtils
    {
        public static int Each<T>(this int instance, Action<int> action)
        {
            for (int i = 0; i < instance; i++)
            {
                action(i);
            }
            return instance;
        }

        public static IEnumerable<T> Each<T>(this IEnumerable<T> instance, Action<T> action)
        {
            foreach (T local in instance)
            {
                action(local);
            }
            return instance;
        }
    }
}