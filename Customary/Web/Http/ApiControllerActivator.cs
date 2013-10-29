using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Custom.Web.Http
{
    public class ApiControllerActivator : DefaultHttpControllerActivator //IHttpControllerActivator
    {
        /*public override IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return base.Create(request, controllerDescriptor, controllerType);
        }*/
    }
}