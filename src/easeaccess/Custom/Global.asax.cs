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
    using Custom.Documents;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        const string SessionKey = "Custom.Resources.Session";
        const string MetadataKey = "Custom.Metadata";

        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
            var message = error.Message;

            if (string.IsNullOrWhiteSpace(message))
                return;

            Component component = null;
            var lookup = (Lookup)Context.Items[SessionKey];

            if (lookup == null)
            {
                lookup = new Lookup(Context);
                using (var master = new Master())
                {
                    component = master.Lookup(lookup);
                }
            }

            lookup.Next();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            var master = new Resources.Master();
            var app_data = new System.IO.DirectoryInfo(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Seeds"));
            foreach (var file in app_data.GetFiles("*.js"))
            {
                master.Import(file.FullName);
            }
        }
    }
}