using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Models
{
    public class LookupResult
    {
        private readonly string _routeName;
        private readonly RouteValueDictionary _routeValues;

        public new LookupResult(string routeName)
        {
            _routeName = routeName;
            _routeValues = new RouteValueDictionary();
        }

        public string RouteName
        {
            get { return _routeName; }
        }

        public RouteValueDictionary RouteValues
        {
            get { return _routeValues; }
        }
    }
}