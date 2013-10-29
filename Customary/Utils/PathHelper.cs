using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Utils
{
    public static class PathHelper
    {
        /// <summary>
        /// Retrieves the subdomain from the specified URL.
        ///</summary>
        ///<param name="url">The URL from which to retrieve the subdomain.</param>
        ///<returns>The subdomain if it exist, otherwise null.</returns>
        public static string GetSubDomain(Uri url)
        {
            if (url.HostNameType == UriHostNameType.Dns)
            {
                string host = url.Host;
                if (host.Split('.').Length > 2)
                {
                    int lastIndex = host.LastIndexOf(".");
                    int index = host.LastIndexOf(".", lastIndex - 1);
                    return host.Substring(0, index);
                }
            }

            return null;
        }

        /// <summary>
        /// Tries to get the physiccal path from a relative or virutal path. If the path is absolute or it is an absolute url that can't be mapped to the current application url.
        /// </summary>
        /// <param name="path">path to test and convert to physical path</param>
        /// <param name="fullPath">The physical path to a resource</param>
        /// <returns>True if it was able to return a valid physical path</returns>
        public static bool TryGetFullPath(string path, out string fullPath)
        {
            if (path == null)
            {
                fullPath = null;
                return false;
            }

            if (System.IO.Path.IsPathRooted(path))
            {
                fullPath = System.IO.Path.GetFullPath(path);

                if (System.IO.File.Exists(fullPath))
                    return true;

                // Try to recover from possible error where path is relative to
                // the application root and not to the system root.
                // File.Exists returns False in Active Directory environment
                string physicalPath;
                if (TryMapPath(path, out physicalPath) && System.IO.File.Exists(physicalPath))
                    fullPath = physicalPath;

                return true;
            }

            Uri relativeUri;
            if (!TryMakeRelativeUri(path, out relativeUri))
            {
                fullPath = null;
                return false;
            }

            if (TryMapPath(relativeUri.ToString(), out fullPath))
                return true;

            fullPath = null;
            return false;
        }

        public static bool TryMakeRelativeUri(string path, out Uri uri)
        {
            if (!Uri.TryCreate(path, UriKind.RelativeOrAbsolute, out uri) && uri.IsAbsoluteUri)
            {
                uri = null;
                return false;
            }

            if (!uri.IsAbsoluteUri)
                return true;

            var request = System.Web.HttpContext.Current.Request;
            var appPath = request.Url.GetLeftPart(UriPartial.Scheme | UriPartial.Authority) + request.ApplicationPath;
            var appUri = new Uri(appPath, UriKind.Absolute);

            /*if (!appUri.IsBaseOf(uri))
                return false;*/

            uri = appUri.MakeRelativeUri(uri);

            return !uri.IsAbsoluteUri;
        }

        public static bool TryMapPath(string path, out string physicalPath)
        {
            string virtualPath;

            path = (path ?? string.Empty).Replace("\\", "/");

            if (path.StartsWith("~/"))
                virtualPath = path;
            else if (path.StartsWith("/"))
                virtualPath = "~" + path;
            else
                virtualPath = "~/" + path;

            bool succeeded = true;
            try
            {
                physicalPath = System.Web.Hosting.HostingEnvironment.MapPath(virtualPath);
            }
            catch (Exception)
            {
                physicalPath = null;
                succeeded = false;
            }
            return succeeded;
        }
    }
}