using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    public static class ServiceExtensions
    {
        public static ServiceDefinition Save(this ServiceDefinition method)
        {
            var session = Global.Metadata.Session;
            session.Store(method);
            return method;
        }
    }
}