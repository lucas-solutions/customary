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
    //using Custom.Resources;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        const string SessionKey = "Custom.Resources.Session";

        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
            var message = error.Message;

            if (string.IsNullOrWhiteSpace(message))
                return;

            /*var session = (Session)Context.Items[SessionKey];

            if (session == null)
            {
                session = new Session(Context);
                Context.Items[SessionKey] = session;
            }

            if (session.Resources.Count > 0)
            {
                Context.ClearError();

                var resource = session.Resources.Dequeue();

                Response.RedirectToRoute(resource.RouteName, resource.RouteValues);
            }*/
        }

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
            foreach (var file in app_data.GetFiles("*.js"))
            {
                Objects.DocumentStoreHolder.Import(file.FullName);
            }
        }
    }
}