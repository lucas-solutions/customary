using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Custom.Web.Routing
{
    public class CrudConstraint : IRouteConstraint
    {
        private readonly bool _optional;

        public CrudConstraint()
            : this(false)
        {
        }

        public CrudConstraint(bool required)
        {
            _optional = !required;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey(parameterName))
                return _optional;

            var parameterValue = values[parameterName];

            if (parameterValue == RouteParameter.Optional || parameterValue == UrlParameter.Optional)
                return _optional;

            string stringValue = parameterValue as string;

            if (string.IsNullOrEmpty(stringValue))
                return _optional;

            CrudActions action;
            if (!System.Enum.TryParse<CrudActions>(stringValue, true, out action))
                return false;

            var httpMethod = new HttpMethod(httpContext.Request.HttpMethod);

            switch (action)
            {
                case CrudActions.Create:
                    return (httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Options);

                case CrudActions.Read:
                    return (httpMethod == HttpMethod.Get);

                case CrudActions.Update:
                    return httpMethod == HttpMethod.Put || httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Options;

                case CrudActions.Delete:
                    return (httpMethod == HttpMethod.Delete || httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Get || httpMethod == HttpMethod.Options);
            }

            return false;
        }
    }
}