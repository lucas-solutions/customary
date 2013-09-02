using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace Custom.Handlers
{
    using Custom.Models;

    public class MetadataRouteHandler : IRouteHandler
    {
        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {  
            var reflection = (RequestReflection)requestContext.HttpContext;

            return reflection.IsMatch ? new MetadataHandler(reflection) : null;
        }
    }
}
