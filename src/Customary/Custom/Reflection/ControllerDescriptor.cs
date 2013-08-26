using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Reflection
{
    using Custom.Controllers;

    public class ControllerDescriptor
    {
        private readonly RequestContext _requestContext;
        private string _controllerName;
        private Type _controllerType;
        private Stack<string> _stack;

        public ControllerDescriptor(RequestContext requestContext, string controllerName)
        {
            _requestContext = requestContext;
            _controllerName = controllerName;

            _controllerType = typeof(BusinessController);
            _controllerName = "Business";

            var segments = requestContext.HttpContext.Request.Path.Split('/');
            _stack = new Stack<string>(segments);

            _requestContext.RouteData.Values["controller"] = _controllerName;
            _requestContext.RouteData.Values["action"] = "Default";
        }

        public string ControllerName
        {
            get { return _controllerName; }
        }

        public Type ControllerType
        {
            get { return _controllerType; }
        }

        public RequestContext RequestContext
        {
            get { return _requestContext; }
        }
    }
}