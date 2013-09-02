using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc.Async;
using System.Web.Routing;
using System.Web.SessionState;

namespace Custom.Handlers
{
    using Custom.Models;

    internal class MetadataHandler : IHttpHandler
    {
        private readonly RequestReflection _reflection;

        public MetadataHandler(RequestReflection reflection)
        {
            _reflection = reflection;
        }

        bool IHttpHandler.IsReusable
        {
            get { return false; }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            context.RewritePath(_reflection.RewritePath, true);
        }
    }
}
