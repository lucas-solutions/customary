using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.ModelBinding.Binders;
using System.Web.Http.ModelBinding;

namespace Custom
{
    using Custom.Web.Http;
    using Custom.Web.Routing;
    

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // http://stackoverflow.com/questions/11886197/what-is-the-equivalent-of-defaultcontrollerfactory-in-asp-net-web-api
            // http://www.asp.net/web-api/overview/web-api-routing-and-actions/routing-and-action-selection

            config.Services.Replace(typeof(IHttpControllerActivator), new ApiControllerActivator());
            config.Services.Replace(typeof(IHttpControllerSelector), new ApiControllerSelector(config));

            var provider = new SimpleModelBinderProvider(typeof(Custom.Web.CrudActions), new Custom.Binders.CrudBinder());

            config.Services.Insert(typeof(ModelBinderProvider), 0, provider);


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{crud}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    crud = RouteParameter.Optional
                },
                constraints: new
                {
                    id = new GuidConstraint(),
                    crud = new CrudConstraint()
                }
            );

            config.Routes.MapHttpRoute(
                name: "AreaApi",
                routeTemplate: "api/{area}/{controller}/{id}/{crud}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    crud = RouteParameter.Optional
                },
                constraints: new
                {
                    id = new GuidConstraint(),
                    crud = new CrudConstraint()
                }   
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}