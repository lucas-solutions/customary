﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Web
{
    [Obsolete]
    public static class RequestContextExtensions
    {
        public static RequestDescriptor Describe(this RequestContext requestContext, string controllerName)
        {
            return RequestDescriptorFactory.Create(requestContext, controllerName);
        }
    }
}