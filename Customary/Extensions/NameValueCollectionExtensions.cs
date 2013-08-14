using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Custom
{
    public static class NameValueCollectionExtensions
    {
        public static bool TryGetQueryNameValue(this NameValueCollection collection, ref string name, out string value)
        {
            var queryKey = name.ToLower();
            var foundKey = collection.AllKeys.Where(o => o.Trim().ToLower() == queryKey).FirstOrDefault();
            if (foundKey != null)
            {
                name = foundKey.Trim();
                value = collection[foundKey];
                return true;
            }
            value = null;
            return false;
        }
    }
}