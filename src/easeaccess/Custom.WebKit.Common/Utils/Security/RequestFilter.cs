using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace Custom.Utils.Security
{
    internal class RequestFilter : IRouteHandler
    {
        private readonly bool _user;
        private readonly Uri _uriBase;
        private readonly byte[] _ipMask;
        private readonly RequestPolicy _policy;

        public RequestFilter(string address, bool user, RequestPolicy policy)
        {
            _user = user;
            _ipMask = IpParser.Parse(address);
            _uriBase = _ipMask == null ? UriParser.Parse(address) : null;
            _policy = policy;
        }

        public RequestPolicy Policy
        {
            get { return _policy; }
        }

        public bool User
        {
            get { return _user; }
        }

        private string Ip
        {
            get
            {
                if (_ipMask == null)
                    return null;

                var ip = _ipMask.Length > 0 ? string.Join(".", _ipMask) : "*";

                for (var i = _ipMask.Length; i < 3; i++)
                    ip = ip + ".*";

                return ip;
            }
        }

        private string Url
        {
            get
            {
                return _uriBase != null ? _uriBase.ToString() : null;
            }
        }

        public bool Test(string user, string address)
        {
            return false;
        }

        public RequestTracking Track(string user, string address, RouteData routeData)
        {
            RequestTracking tracking = null;

            tracking = new RequestTracking(user, address, routeData);

            return tracking;
        }

        #region - IRouteHandler implementation -

        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            var routeData = requestContext.RouteData;
            var httpContext = requestContext.HttpContext;
            var httpRequest = httpContext.Request;
            var userAddress = httpRequest.UserHostAddress;
            var principal = System.Threading.Thread.CurrentPrincipal;
            var userIdentity = principal.Identity;
            //var windowIdentity = WindowsIdentity.GetCurrent();
            var userName = userIdentity.Name;

            RequestTracking tracking;
            if (Test(userName, userAddress))
            {
                tracking = Track(userName, userAddress, routeData);
                //_policy.Test(tracking);
            }

            return null;
        }

        #endregion - IRouteHandler implementation -

        public override string ToString()
        {
            return string.Format("{0}:{1}:{3}", Ip ?? Url, _user ? "*" : "", _policy);
        }
    }
}
