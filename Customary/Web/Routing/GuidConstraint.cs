using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Custom.Web.Routing
{
    public class GuidConstraint : IRouteConstraint
    {
        private readonly bool _optional;

        public GuidConstraint()
            : this(false)
        {
        }

        public GuidConstraint(bool required)
        {
            _optional = !required;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey(parameterName))
                return _optional;

            var parameterValue = values[parameterName];

            if (Guid.Empty.Equals(parameterValue) || 
                RouteParameter.Optional.Equals(parameterValue) || 
                UrlParameter.Optional.Equals(parameterValue))
                return _optional;

            string stringValue = parameterValue as string;

            if (string.IsNullOrEmpty(stringValue))
                return _optional;

            Guid guidValue;

            if (!Guid.TryParse(stringValue, out guidValue))
                return false;

            return true; 
        }
    }
}