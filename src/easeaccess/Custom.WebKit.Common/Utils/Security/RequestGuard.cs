using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace Custom.Utils.Security
{
    public class RequestGuard : IHttpHandler
    {
        private RouteCollection _routeCollection;

        /*
       private static readonly object _singletonLock = new object();

       /// <summary>
       /// Singleton implementation.
       /// Always returns the same instance.
       /// </summary>
       public static RequestGuard Singleton
       {
           get
           {
               if (_singleton != null)
                   return _singleton;

               lock (_singletonLock)
               {
                   if (_singleton == null)
                   {
                       _singleton = new RequestGuard(new DictionaryCacheProvider());
                   }
               }

               return _singleton;
           }
       }*/

        public RequestGuard()
        {
            _routeCollection = new RouteCollection();
        }

        public void Stop(string url, string address, bool user, RequestPolicy policy)
        {
            var filter = new RequestFilter(address, user, policy);
            
            if (url != null)
            {
                var route = new Route(url, filter);
                _routeCollection.Add(route);
            }
        }

        #region - IHttpHandler implementation -

        /// <summary>
        ///  Gets a value indicating whether another request can use the RequestPolicy instance.
        /// </summary>
        bool IHttpHandler.IsReusable
        {
            get { return true; }
        }

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements
        /// the System.Web.IHttpHandler interface.
        /// </summary>
        /// <param name="context">
        ///  An System.Web.HttpContext object that provides references to the intrinsic
        ///  server objects (for example, Request, Response, Session, and Server) used
        ///  to service HTTP requests.
        /// </param>
        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            var httpContext = new HttpContextWrapper(context);
            var httpRequest = context.Request;
            var url = httpRequest.Path;
            var route = new Route(url, null);

            route.GetRouteData(httpContext);
        }

        #endregion - IHttpHandler implementation -
    }
}
