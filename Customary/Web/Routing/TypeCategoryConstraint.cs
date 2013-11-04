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
    using Custom.Data;

    public class TypeCategoryConstraint : IRouteConstraint
    {
        private readonly bool _optional;

        public TypeCategoryConstraint()
            : this(false)
        {
        }

        public TypeCategoryConstraint(bool required)
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

            TypeCategories category;
            if (!System.Enum.TryParse<TypeCategories>(stringValue, true, out category))
                return false;

            return true;
        }
    }
}