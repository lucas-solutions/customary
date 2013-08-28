using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Custom.Controllers
{
    using Custom.Processes;

    public class ControllerFactory : DefaultControllerFactory
    {
        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            var controllerType = base.GetControllerType(requestContext, controllerName);

            if (controllerType == null)
            {
                var descriptor = ReflectionProcesses.Describe(requestContext, controllerName);

                controllerType = descriptor.ControllerType;
            }

            return controllerType;
        }
    }
}