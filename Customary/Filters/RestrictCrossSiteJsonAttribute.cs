using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Filters
{
    public class RestrictCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var site = System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName();
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", site);
            base.OnActionExecuting(filterContext);
        }
    }
}