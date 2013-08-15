﻿using System;
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

            //Loggly.LogglyConfiguration.Configure(c => c.AuthenticateWith("", ""));

            var logger = new Custom.Diagnostics.LogglyLogger("21e21e20-67cc-49ec-b817-a5e09e81780c");
            logger.Log("Application_Start");

            var perfCounterMgr = new DiagnosticsManager();
            perfCounterMgr.Create(Server.MapPath("~/bin"), "*.dll");
            Application[DiagnosticsManager.PerformanceCounterManagerApplicationKey] = perfCounterMgr;
        }
    }
}