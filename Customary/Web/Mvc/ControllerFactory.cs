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
            var controllerType = base.GetControllerType(requestContext, controllerName);

            var areaName = requestContext.RouteData.Values["area"] as string;
            var actionName = requestContext.RouteData.Values["action"] as string;
            var httpMethod = requestContext.HttpContext.Request.HttpMethod.ToUpperInvariant();

            HttpVerbs httpVerb;
            if (!System.Enum.TryParse<HttpVerbs>(requestContext.HttpContext.Request.HttpMethod, true, out httpVerb))
                httpVerb = HttpVerbs.Get;

            switch (areaName)
            {
                case "Data":
                    {
                        CrudActions crudAction;

                        if (string.IsNullOrEmpty(actionName) || !System.Enum.TryParse<CrudActions>(actionName, true, out crudAction))
                            switch (httpVerb)
                            {
                                case HttpVerbs.Delete:
                                    crudAction = CrudActions.Delete;
                                    break;

                                case HttpVerbs.Get:
                                    crudAction = CrudActions.Select;
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

                                case HttpVerbs.Options:
                                    requestContext.RouteData.Values["action"] = "Options";
                                    return controllerType;

                                default:
                                    crudAction = CrudActions.Default;
                                    break;
                            }

                        switch (crudAction)
                        {
                            case CrudActions.Update:
                                // fix patch
                                var patchValue = requestContext.RouteData.Values["patch"];
                                if (patchValue == null || patchValue.GetType() != typeof(bool))
                                    requestContext.RouteData.Values["patch"] = true;
                                break;
                        }

                        if (actionName == null)
                        {
                            actionName = System.Enum.GetName(typeof(CrudActions), crudAction);

                            requestContext.RouteData.Values["action"] = actionName;
                        }
                    }
                    break;
            }

            return controllerType;
        }
    }
}