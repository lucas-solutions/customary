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
    using Custom.Extensions;
    using Custom.Models;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        /*protected void Application_Error(object sender, EventArgs e)
        {
            var error = Context.Server.GetLastError();
            var ex = error.GetBaseException();

            if (ex is HttpException)
            {
                var code = ((HttpException)(ex)).GetHttpCode();
                switch (code)
                {
                    case 404:
                        var reflection = (Utils.RequestReflection)Context;
                        reflection.Redirect();
                        break;
                }
            }

            // Code that runs when an unhandled error occurs
            //Server.Transfer("~/DefaultError.aspx");
        }*/

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BinderConfig.RegisterBinders(ModelBinders.Binders);
            AuthConfig.RegisterAuth();

            RequestReflection.Ingnore("Scripts");

            //var appRepo = new Repositories.DocumentRepository<Models.App>();
            var app_data = new System.IO.DirectoryInfo(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data"));
            foreach (var file in app_data.GetFiles("*.js"))
            {
                DocumentStoreHolder.Store.Import(file.FullName);
            }
        }
    }
}