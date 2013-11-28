using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Web
{
    [Obsolete]
    public class SiteRequestDescriptor : RequestDescriptor
    {
        public SiteRequestDescriptor(RequestContext requestContext, string controllerName)
            : base(requestContext, controllerName)
        {
            /*var lookup = Global.Navigation.Lookup(requestContext.HttpContext.Request.Url);

            if (lookup != null)
            {
                requestContext.RouteData.Values["controller"] = ControllerName;
                requestContext.RouteData.Values["action"] = "Default";
            }*/
        }
    }
}