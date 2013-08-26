using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Custom
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            ControllerBuilder.Current.SetControllerFactory(typeof(Custom.Controllers.ControllerFactory));

            var app_data = new System.IO.DirectoryInfo(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Seeds"));
            foreach (var file in app_data.GetFiles("business*.js"))
            {
                Documents.Business.Import(file.FullName);
            }

            foreach (var file in app_data.GetFiles("globalization*.js"))
            {
                Documents.Globalization.Import(file.FullName);
            }
        }
    }
}