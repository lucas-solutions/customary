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
    using Custom.Extensions;
    using Custom.Models;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_AuthenticateRequest(object sender, System.EventArgs e)
        {
            string url = HttpContext.Current.Request.FilePath;

            if (url.EndsWith("ext.axd"))
            {
                HttpContext.Current.SkipAuthorization = true;
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BinderConfig.RegisterBinders(ModelBinders.Binders);
            AuthConfig.RegisterAuth();

            var appRepo = new Repositories.DocumentRepository<App>();
            var configPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/localhost.js");
            if (System.IO.File.Exists(configPath))
            {
                using (var config = System.IO.File.OpenText(configPath))
                {
                    var app = appRepo.Save(config.ReadToEnd());
                }
            }
        }
    }
}