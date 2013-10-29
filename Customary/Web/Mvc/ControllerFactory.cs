using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Custom.Web.Mvc
{
    public class ControllerFactory : DefaultControllerFactory
    {
        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            if (requestContext.RouteData.Route == RouteTable.Routes[Global.StoreRouteName] ||
                requestContext.RouteData.Route == RouteTable.Routes[Global.StoreDetailRouteName])
            {
                var action = requestContext.RouteData.Values["action"] as string;
                var method = requestContext.HttpContext.Request.HttpMethod.ToUpperInvariant();

                HttpVerbs verb;
                if (!System.Enum.TryParse<HttpVerbs>(requestContext.HttpContext.Request.HttpMethod, true, out verb))
                    verb = HttpVerbs.Get;

                var crudAction = CrudActions.Read;

                if (string.IsNullOrEmpty(action))
                    switch (verb)
                    {
                        case HttpVerbs.Delete:
                            crudAction = CrudActions.Delete;
                            break;

                        case HttpVerbs.Get:
                            crudAction = CrudActions.Read;
                            break;

                        case HttpVerbs.Head:
                            break;

                        case HttpVerbs.Options:
                            break;

                        case HttpVerbs.Patch:
                            crudAction = CrudActions.Update;
                            requestContext.RouteData.Values["patch"] = true;
                            break;

                        case HttpVerbs.Post:
                            crudAction = CrudActions.Create;
                            break;

                        case HttpVerbs.Put:
                            crudAction = CrudActions.Update;
                            break;

                        default:
                            return null;
                    }
                else if (!System.Enum.TryParse<CrudActions>(action, true, out crudAction))
                    Debug.Assert(false);

                requestContext.RouteData.Values["action"] = crudAction.ToString();

                if (string.Equals("PATCH", method, StringComparison.OrdinalIgnoreCase))
                    requestContext.RouteData.Values["patch"] = true;
                else if (string.Equals("PUT", method, StringComparison.OrdinalIgnoreCase))
                    if (requestContext.RouteData.Values["patch"] == null || requestContext.RouteData.Values["patch"].GetType() != typeof(bool))
                        requestContext.RouteData.Values["patch"] = true;

                var controllerType = base.GetControllerType(requestContext, controllerName);

                if (controllerType == null)
                    controllerType = typeof(Custom.Controllers.DataController);

                return controllerType;
            }

            if (requestContext.RouteData.Route == RouteTable.Routes[Global.DataRouteName] ||
                requestContext.RouteData.Route == RouteTable.Routes[Global.DataGroupRouteName])
            {
                var action = requestContext.RouteData.Values["action"] as string;
                var method = requestContext.HttpContext.Request.HttpMethod.ToUpperInvariant();

                HttpVerbs verb;
                if (!System.Enum.TryParse<HttpVerbs>(requestContext.HttpContext.Request.HttpMethod, true, out verb))
                    verb = HttpVerbs.Get;

                var crudAction = CrudActions.Read;

                if (string.IsNullOrEmpty(action))
                    switch (verb)
                    {
                        case HttpVerbs.Delete:
                            crudAction = CrudActions.Delete;
                            break;

                        case HttpVerbs.Get:
                            crudAction = CrudActions.Read;
                            break;

                        case HttpVerbs.Head:
                            break;

                        case HttpVerbs.Options:
                            break;

                        case HttpVerbs.Patch:
                            crudAction = CrudActions.Update;
                            requestContext.RouteData.Values["patch"] = true;
                            break;

                        case HttpVerbs.Post:
                            crudAction = CrudActions.Create;
                            break;

                        case HttpVerbs.Put:
                            crudAction = CrudActions.Update;
                            break;

                        default:
                            return null;
                    }
                else if (!System.Enum.TryParse<CrudActions>(action, true, out crudAction))
                    Debug.Assert(false);

                requestContext.RouteData.Values["action"] = crudAction.ToString();

                if (string.Equals("PATCH", method, StringComparison.OrdinalIgnoreCase))
                    requestContext.RouteData.Values["patch"] = true;
                else if (string.Equals("PUT", method, StringComparison.OrdinalIgnoreCase))
                    if (requestContext.RouteData.Values["patch"] == null || requestContext.RouteData.Values["patch"].GetType() != typeof(bool))
                        requestContext.RouteData.Values["patch"] = true;

                var controllerType = base.GetControllerType(requestContext, controllerName);

                if (controllerType == null)
                    controllerType = typeof(Custom.Controllers.DataController);

                return controllerType;
            }

            RequestDescriptor descriptor;

            if (requestContext.RouteData.Route == RouteTable.Routes[Global.DataGreedyRouteName])
                descriptor = DataRequestDescriptor.Parse(requestContext.HttpContext.Request.Url.AbsolutePath.Split('/').Skip(1).ToArray());
            else
            {
                descriptor = requestContext.Describe(controllerName);
            }

            if (descriptor != null && descriptor.ControllerType != null)
            {
                requestContext.RouteData.Values["controller"] = descriptor.ControllerName;
                requestContext.RouteData.Values["action"] = descriptor.Action;

                if (descriptor.Area != null)
                    requestContext.RouteData.Values["area"] = descriptor.Area;

                return descriptor.ControllerType;
            }

            return base.GetControllerType(requestContext, controllerName);
        }
    }
}