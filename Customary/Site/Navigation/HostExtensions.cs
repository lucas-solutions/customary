using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Navigation
{
    public static class HostExtensions
    {
        public static HostDescriptor Save(this HostDescriptor host)
        {
            var session = Global.Navigation.Session;
            session.Store(host);
            return host;
        }
    }
}