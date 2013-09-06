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
    using Custom.Diagnostics;
    using Custom.Metadata;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private ILogger Logger
        {
            get { return Global.Logger; }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //Loggly.LogglyConfiguration.Configure(c => c.AuthenticateWith("", ""));

            Logger.Log("Application_Start");

            var perfCounterMgr = new DiagnosticsManager();
            /*perfCounterMgr.Create(Server.MapPath("~/bin"), "*.dll");
            Application[DiagnosticsManager.PerformanceCounterManagerApplicationKey] = perfCounterMgr;*/

            ControllerBuilder.Current.SetControllerFactory(typeof(Navigation.ControllerFactory));

            var metadataSeeds = new System.IO.DirectoryInfo(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Seeds/Metadata")).GetFiles("*.js").ToArray();
            foreach (var file in metadataSeeds)
            {
                Global.Metadata.Import(file.FullName);
            }

            /*var globalizationSeeds = new System.IO.DirectoryInfo(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Seeds/Globalization")).GetFiles("*.js").ToArray();
            foreach (var file in globalizationSeeds)
            {
                Repositories.GlobalizationContext.Import(file.FullName);
            }*/
        }
    }
}