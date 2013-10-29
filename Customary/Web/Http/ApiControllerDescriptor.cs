using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Custom.Web.Http
{
    public class ApiControllerDescriptor : HttpControllerDescriptor
    {
        public ApiControllerDescriptor()
            : base()
        {
        }
        
        public ApiControllerDescriptor(HttpConfiguration configuration, string controllerName, Type controllerType)
            : base(configuration, controllerName, controllerType)
        {
        }
    }
}