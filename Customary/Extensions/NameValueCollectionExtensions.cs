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

        /// <summary>
        /// Returns the absolute URL version of a given relative URL.
        /// If the provided url is absolute it is returned. If not, 
        /// the curren application URL is used as the base URL.
        /// </summary>
        /// <param name="relative">The input URL</param>
        /// <returns>The absolute URL</returns>
        private string ConvertToAbsoluteUrl(string relative)
        {
            Uri url;
            if (!Uri.TryCreate(relative, UriKind.RelativeOrAbsolute, out url))
                return null;

            if (url.IsAbsoluteUri)
                return url.ToString();

            var request = HttpContext.Current.Request;
            var absolute = new Uri(request.Url.GetLeftPart(UriPartial.Scheme | UriPartial.Authority) + request.ApplicationPath + '/' + url.ToString());

            return absolute.ToString();
        }
    }
}