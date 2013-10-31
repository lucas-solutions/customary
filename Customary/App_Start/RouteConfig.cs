using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Custom
{
    using Custom.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: Global.StoreRouteName,
                url: "{type}/{action}",
                defaults: new
                {
                    controller = "Store",
                    type = Guid.Empty,
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    id = new GuidConstraint(true),
                    action = new CrudConstraint()
                }
            );

            routes.MapRoute(
                name: Global.StoreDetailRouteName,
                url: "{type}/{id}/{action}",
                defaults: new
                {
                    controller = "Store",
                    type = Guid.Empty,
                    id = Guid.Empty,
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    id = new GuidConstraint(true),
                    type = new GuidConstraint(true),
                    action = new CrudConstraint()
                }
            );

            routes.MapRoute(
                name: "Ext",
                url: "App/{controller}/{action}.js"
            );

            routes.MapRoute(
                name: "Custom_JS",
                url: "Custom/{controller}/{action}.js"
            );

            routes.MapRoute(
                name: "JavaScript",
                url: "{controller}/{action}.js"
            );
            /*
            routes.MapRoute(
                name: "Data",
                url: "Data/{type}/{action}/{id}",
                defaults: new { controller = "Data", action = "Index", type = UrlParameter.Optional, id = UrlParameter.Optional }
            );*/

            // most important
            routes.MapRoute(
                name: Global.DataStoreRouteName,
                url: "Data/{type}/{action}/{id}",
                defaults: new
                {
                    controller = "Store",
                    type = Guid.Empty,
                    id = Guid.Empty,
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    id = new GuidConstraint(),
                    action = new CrudConstraint()
                }
            );

            routes.MapRoute(
                name: Global.DataRouteName,
                url: "Data/{controller}/{id}/{action}",
                defaults: new
                {
                    controller = "Data",
                    id = Guid.Empty,
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    id = new GuidConstraint(),
                    action = new CrudConstraint()
                }
            );

            routes.MapRoute(
                name: Global.DataGroupRouteName,
                url: "Data/{area}/{controller}/{id}/{action}",
                defaults: new
                {
                    controller = "Data",
                    id = Guid.Empty,
                    action = UrlParameter.Optional,
                },
                constraints: new
                {
                    id = new GuidConstraint(),
                    action = new CrudConstraint()
                }
            );

            routes.MapRoute(
                name: Global.DataGreedyRouteName,
                url: "Data/{@path}",
                defaults: new
                {
                    controller = "Data",
                }
            );

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new
               {
                   controller = "Home",
                   action = "Index",
                   id = UrlParameter.Optional
               },
               constraints: new
               {
                   id = new GuidConstraint()
               }
            );

            routes.MapRoute(
                name: "Greedy",
                url: "{controller}/{area}/{*greedy}"
            );
        }
    }
}