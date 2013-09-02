using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Custom.Utils.Security
{
    public class RequestPolicy : IHttpHandler
    {
        private int _responseStatusCode;

        private RequestPolicy()
        {
            _responseStatusCode = 403;
        }

        public int ResponseStatusCode
        {
            get { return _responseStatusCode; }
            set { _responseStatusCode = value; }
        }

        #region - IHttpHandler implementation -

        /// <summary>
        ///  Gets a value indicating whether another request can use the RequestPolicy instance.
        /// </summary>
        bool IHttpHandler.IsReusable
        {
            get { throw new NotImplementedException(); }
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
            /*if (_customHandler != null)
                _customHandler.ProcessRequest(context);
            else*/
            {
                context.Response.StatusCode = ResponseStatusCode;
                context.Response.End();
            }
        }

        #endregion - IHttpHandler implementation -
    }
}
