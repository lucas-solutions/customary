using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Custom.Navigation
{
    public class ControllerFactory : DefaultControllerFactory
    {
        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            var controllerType = base.GetControllerType(requestContext, controllerName);

            if (controllerType == null)
            {
                var descriptor = Repositories.NavigationContext.Describe(requestContext, controllerName);

                controllerType = descriptor.ControllerType;
            }

            return controllerType;
        }
    }
}