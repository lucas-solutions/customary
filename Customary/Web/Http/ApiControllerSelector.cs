using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Custom.Web.Http
{
    public class ApiControllerSelector : DefaultHttpControllerSelector//IHttpControllerSelector
    {
        public ApiControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
        }

        public override IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            return base.GetControllerMapping();
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            return base.SelectController(request);
        }
    }
}