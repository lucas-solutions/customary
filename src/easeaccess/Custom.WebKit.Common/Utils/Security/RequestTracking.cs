using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Custom.Utils.Security
{
    internal class RequestTracking
    {
        private string _user;
        private string _address;
        private RouteData _routeData;

        public RequestTracking(string user, string address, RouteData routeData)
        {
            _routeData = routeData;
        }
    }
}
