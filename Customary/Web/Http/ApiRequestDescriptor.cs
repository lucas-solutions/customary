using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Web.Http
{
    public class ApiRequestDescriptor : RequestDescriptor
    {
        public ApiRequestDescriptor(RequestContext requestContext, string controllerName)
            : base(requestContext, controllerName)
        {
        }
    }
}