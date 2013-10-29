using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Custom.Site.Navigation
{
    public static class PathExtensions
    {
        public static PathDescriptor Save(this PathDescriptor path)
        {
            var parent = path.Parent;

            if (parent != null)
            {
                parent = Save(parent);
                var entity = parent.Children.SingleOrDefault(o => o.Name == path.Name);
                if (entity != null)
                {
                }
                else
                {
                }
                return path;
            }
            else
            {
                var host = path as HostDescriptor;
                Debug.Assert(host != null);
                return HostExtensions.Save(host);
            }
        }
    }
}