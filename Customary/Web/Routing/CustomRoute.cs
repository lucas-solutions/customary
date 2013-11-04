using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Custom.Web.Routing
{
    public class CustomRoute : System.Web.Routing.RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var url = httpContext.Request.Headers["HOST"];
            var uri = new Uri(url);

            string[] subdomain = new string[0];

            if (uri.HostNameType == UriHostNameType.Dns)
            {
                var host = uri.Host.Split('.');
                if (host.Length > 2)
                {
                    int skip = 0, take = host.Length - 1;

                    if (string.Equals("www", host[0], StringComparison.InvariantCultureIgnoreCase))
                    {
                        skip++;
                        take--;
                    }

                    subdomain = host.Skip(skip).Take(take).ToArray();
                }
            }

            if (subdomain.Length.Equals(0))
                return null;

            var routeData = new RouteData(this, new MvcRouteHandler());

            var controller = string.Concat(subdomain.Reverse());

            routeData.Values.Add("controller", controller);

            switch (controller)
            {
                case "data":
                    routeData.Values.Add("action", "Index");
                    break;

                default:
                    routeData.Values.Add("controller", "Home");
                    routeData.Values.Add("action", "Index");
                    break;
            }

            return routeData;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
}