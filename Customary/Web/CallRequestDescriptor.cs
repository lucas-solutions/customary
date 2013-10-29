using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Web
{
    public class CallRequestDescriptor : RequestDescriptor
    {
        public CallRequestDescriptor(RequestContext requestContext, string controllerName)
            : base(requestContext, controllerName)
        {
        }

        protected override void Initialize()
        {
        }
    }
}