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

            #region Scripts/Ext/custom/{action}

            routes.MapRoute(
                name: Global.Routes.ExtRouteName,
                url: "Scripts/Ext/custom/{action}.js",
                defaults: new
                {
                    controller = "Ext"
                },
                namespaces: new[]
                {
                   "Custom.Controllers"
                }
            );

            #endregion

            #region - Data -

            // ExtController

            #region Scripts/Ext/custom/{area}/{action}

            routes.MapRoute(
                name: Global.Routes.ExtAreaRouteName,
                url: "Scripts/Ext/custom/{area}/{action}.js",
                defaults: new
                {
                    controller = "Ext"
                },
                namespaces: new[]
                {
                   "Custom.Areas.Data.Controllers"
                }
            );

            #endregion

            // AreaController

            #region Data/Store/Metadata/Area/{id}/{action}

            routes.MapRoute(
                name: Global.Routes.AreaItemRouteName,
                url: "Data/Store/Metadata/Area/{id}/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Area",
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    id = new GuidConstraint(true),
                    action = new CrudConstraint()
                }
            );

            #endregion

            #region Data/Store/Metadata/Area/{action}

            routes.MapRoute(
                name: Global.Routes.AreaSetRouteName,
                url: "Data/Store/Metadata/Area/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Area",
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    action = new CrudConstraint()
                }
            );

            #endregion

            // EnumController

            #region Data/Store/Metadata/Type/Enum/{id}/{action}

            routes.MapRoute(
                name: Global.Routes.EnumItemRouteName,
                url: "Data/Store/Metadata/Type/Enum/{id}/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Enum",
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    id = new GuidConstraint(true),
                    action = new CrudConstraint()
                }
            );

            #endregion

            #region Data/Store/Metadata/Type/Enum/{action}

            routes.MapRoute(
                name: Global.Routes.EnumSetRouteName,
                url: "Data/Store/Metadata/Type/Enum/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Enum",
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    action = new CrudConstraint()
                }
            );

            #endregion

            // EntityController

            #region Data/Store/Metadata/Type/Model/{model}/Entities/{id}/Invoke/{fn}

            routes.MapRoute(
                name: Global.Routes.ModelItemEntityInvokeRouteName,
                url: "Data/Store/Metadata/Type/Model/{model}/Entities/{id}/Invoke/{fn}",
                defaults: new
                {
                    area = "Data",
                    controller = "Entity",
                    action = "Invoke",
                },
                constraints: new
                {
                    model = new GuidConstraint(true),
                    id = new GuidConstraint(true)
                }
            );

            #endregion

            #region Data/Store/Metadata/Type/Model/{model}/Entities/{id}/{action}

            routes.MapRoute(
                name: Global.Routes.ModelItemEntityItemRouteName,
                url: "Data/Store/Metadata/Type/Model/{model}/Entities/{id}/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Entity",
                    action = UrlParameter.Optional,
                },
                constraints: new
                {
                    model = new GuidConstraint(true),
                    id = new GuidConstraint(true),
                    action = new CrudConstraint()
                }
            );

            #endregion

            #region Data/Store/Metadata/Type/Model/{model}/Entities/{action}

            routes.MapRoute(
                name: Global.Routes.ModelItemEntitySetRouteName,
                url: "Data/Store/Metadata/Type/Model/{model}/Entities/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Entity",
                    action = UrlParameter.Optional,
                },
                constraints: new
                {
                    model = new GuidConstraint(true),
                    action = new CrudConstraint()
                }
            );

            #endregion

            // ModelController

            #region Data/Store/Metadata/Type/Model/{model}/Invoke/{fn}

            routes.MapRoute(
                name: Global.Routes.ModelItemInvokeRouteName,
                url: "Data/Store/Metadata/Type/Model/{model}/Invoke/{fn}",
                defaults: new
                {
                    area = "Data",
                    controller = "Model",
                    action = "Invoke"
                },
                constraints: new
                {
                    action = new CrudConstraint()
                }
            );

            #endregion

            #region Data/Store/Metadata/Type/Model/{id}/{action}

            routes.MapRoute(
                name: Global.Routes.ModelItemRouteName,
                url: "Data/Store/Metadata/Type/Model/{id}/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Model",
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    id = new GuidConstraint(true),
                    action = new CrudConstraint()
                }
            );

            #endregion

            #region Data/Store/Metadata/Type/Model/{action}

            routes.MapRoute(
                name: Global.Routes.ModelSetRouteName,
                url: "Data/Store/Metadata/Type/Model/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Model",
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    action = new CrudConstraint()
                }
            );

            #endregion

            // ValueController

            #region Data/Store/Metadata/Type/Value/{id}/{action}

            routes.MapRoute(
                name: Global.Routes.ValueItemRouteName,
                url: "Data/Store/Metadata/Type/Value/{id}/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Value",
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    id = new GuidConstraint(true),
                    action = new CrudConstraint()
                }
            );

            #endregion

            #region Data/Store/Metadata/Type/Value/{action}

            routes.MapRoute(
                name: Global.Routes.ValueSetRouteName,
                url: "Data/Store/Metadata/Type/Value/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Value",
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    action = new CrudConstraint()
                }
            );

            #endregion

            // TypeController

            #region Data/Store/Metadata/Type/{category}/{id}/{action}

            routes.MapRoute(
                name: Global.Routes.TypeItemRouteName,
                url: "Data/Store/Metadata/Type/{category}/{id}/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Type",
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    category = new TypeCategoryConstraint(true),
                    id = new GuidConstraint(true),
                    action = new CrudConstraint()
                }
            );

            #endregion

            #region Data/Store/Metadata/Type/{category}/{action}

            routes.MapRoute(
                name: Global.Routes.TypeSetRouteName,
                url: "Data/Store/Metadata/Type/{category}/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Type",
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    category = new TypeCategoryConstraint(true),
                    action = new CrudConstraint()
                }
            );

            #endregion

            // StoreController

            #region Data/Store/{store}/{*keyPrefix}/{id}/{action}

            routes.MapGreedyRoute(
                name: Global.Routes.StoreItemRouteName,
                url: "Data/Store/{store}/{*keyPrefix}/{id}/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Store",
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    id = new GuidConstraint(true),
                    action = new CrudConstraint()
                }
            );

            #endregion

            #region Data/Store/{store}/{*keyPrefix}/{action}

            routes.MapGreedyRoute(
                name: Global.Routes.StoreSetRouteName,
                url: "Data/Store/{store}/{*keyPrefix}/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Store",
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    action = new CrudConstraint()
                }
            );

            #endregion

            // DirectoryController

            #region Data/Directory/{*path}

            routes.MapRoute(
                name: Global.Routes.DataDirectoryRouteName,
                url: "Data/Directory/{*name}",
                defaults: new
                {
                    area = "Data",
                    controller = "Directory",
                    action = "Default"
                }
            );

            #endregion

            // NameController

            #region Data/{*name}/{id}/Invoke/{fn}

            routes.MapGreedyRoute(
                name: Global.Routes.DataEntityInvokeRouteName,
                url: "Data/{*name}/{id}/Invoke/{fn}",
                defaults: new
                {
                    area = "Data",
                    controller = "Name",
                    action = "Invoke"
                },
                constraints: new
                {
                    id = new GuidConstraint(true)
                }
            );

            #endregion

            #region Data/{*name}/$metadata

            routes.MapGreedyRoute(
                name: Global.Routes.DataNameMetadataRouteName,
                url: "Data/{*name}/$metadata",
                defaults: new
                {
                    area = "Data",
                    controller = "Name",
                    action = "Metadata"
                }
            );

            #endregion

            #region Data/{*name}/{id}/{action}

            routes.MapGreedyRoute(
                name: Global.Routes.DataEntityRouteName,
                url: "Data/{*name}/{id}/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Name",
                    action = UrlParameter.Optional
                },
                constraints: new
                {
                    id = new GuidConstraint(true),
                    action = new CrudConstraint()
                }
            );

            #endregion

            #region Data/{*name}/Invoke/{fn}

            routes.MapGreedyRoute(
                name: Global.Routes.DataTypeInvokeRouteName,
                url: "Data/{*name}/Invoke/{fn}",
                defaults: new
                {
                    area = "Data",
                    controller = "Name",
                    action = "Invoke",
                    id = Guid.Empty
                }
            );

            #endregion

            #region Data/{*name}/{action}

            routes.MapGreedyRoute(
                name: Global.Routes.DataTypeRouteName,
                url: "Data/{*name}/{action}",
                defaults: new
                {
                    area = "Data",
                    controller = "Name",
                    action = UrlParameter.Optional,
                    id = Guid.Empty
                },
                constraints: new
                {
                    action = new CrudConstraint()
                }
            );

            #endregion

            #region data.{domain}/{*path}/{id}

            routes.MapDomainRoute(
                name: Global.Routes.DataDomainRouteName,
                domain: "data.customary.com",
                url: "{*path}/{id}",
                defaults: new
                {
                    area = "Data",
                    controller = "Name",
                    action = "Default",
                    id = Guid.Empty
                },
                constraints: new
                {
                    id = new GuidConstraint()
                }
            );

            #endregion

            #endregion - Data -

            #region - Site -
            #endregion

            #region - File -
            #endregion

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

            // generic controllers

            #region {area}/{controller}/{id}/{action}

            routes.MapRoute(
               name: "Default_Area_Data",
               url: "{area}/{controller}/{id}/{action}",
               defaults: new
               {
                   action = UrlParameter.Optional
               },
               constraints: new
               {
                   id = new GuidConstraint(true)
               }
            );

            #endregion

            #region {controller}/{id}/{action}

            routes.MapRoute(
               name: "Default_Data",
               url: "{controller}/{id}/{action}",
               defaults: new
               {
                   action = UrlParameter.Optional
               },
               constraints: new
               {
                   id = new GuidConstraint(true)
               }
            );

            #endregion

            #region {area}/{controller}/{action}/{id}

            routes.MapRoute(
                name: "Default_Area",
                url: "{area}/{controller}/{action}/{id}",
                defaults: new
                {
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );

            #endregion

            #region {controller}/{action}/{id}

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new
               {
                   controller = "Home",
                   action = "Index",
                   id = UrlParameter.Optional
               }
            );

            #endregion

            // PageController

            #region {*path}

            routes.MapRoute(
                name: Global.Routes.DefaultPathRouteName,
                url: "{*path}",
                defaults: new
                {
                    controller = "Page",
                    action = "Default"
                }
            );

            #endregion
        }
    }
}