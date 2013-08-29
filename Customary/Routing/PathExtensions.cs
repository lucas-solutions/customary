using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Routing
{
    public static class PathExtensions
    {
        public static PathDescriptor Save(this PathDescriptor path)
        {
            var session = Global.Navigation.Session;
            session.Store(path);
            return path;
        }
    }
}