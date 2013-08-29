using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    public static class MethodExtensions
    {
        public static MethodDescriptor Save(this MethodDescriptor method)
        {
            var session = Global.Metadata.Session;
            session.Store(method);
            return method;
        }
    }
}