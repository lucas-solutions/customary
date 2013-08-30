using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace System.Web.Mvc
{
    public static class RazorExtensions
    {
        public static HelperResult List<T>(this IEnumerable<T> items, Func<T, HelperResult> template)
        {
            return new HelperResult(writer =>
            {
                foreach (var item in items)
                {
                    template(item).WriteTo(writer);
                }
            });
        }

        public static HelperResult NotNull(this object[] list, Func<HelperResult> template)
        {
            if (list.Any(o => o != null))
                return null;

            return new HelperResult(writer =>
            {
                template().WriteTo(writer);
            });
        }

        public static HelperResult NotLast<T>(this List<T> items, int index, Func<T, HelperResult> template)
        {
            if (items == null || index == items.Count - 1)
                return null;

            return new HelperResult(writer =>
            {
                foreach (var item in items)
                {
                    template(item).WriteTo(writer);
                }
            });
        }

        public static HelperResult Last<T>(this List<T> items, int index, Func<T, HelperResult> template)
        {
            if (items != null && index < items.Count - 1)
                return null;

            return new HelperResult(writer =>
            {
                foreach (var item in items)
                {
                    template(item).WriteTo(writer);
                }
            });
        }
    }
}