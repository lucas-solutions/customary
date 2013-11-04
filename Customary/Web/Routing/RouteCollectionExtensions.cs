using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace Custom.Web.Routing
{
    using Custom.Web.Mvc;

    public static class RouteCollectionExtensions
    {
        private static RouteValueDictionary CreateRouteValueDictionary(object values)
        {
            IDictionary<string, object> dictionary = values as IDictionary<string, object>;
            if (dictionary != null)
            {
                return new RouteValueDictionary(dictionary);
            }
            return new RouteValueDictionary(values);
        }

        private static RouteCollection FilterRouteCollectionByArea(RouteCollection routes, string areaName, out bool usingAreas)
        {
            if (areaName == null)
            {
                areaName = string.Empty;
            }
            usingAreas = false;
            RouteCollection routes2 = new RouteCollection
            {
                AppendTrailingSlash = routes.AppendTrailingSlash,
                LowercaseUrls = routes.LowercaseUrls,
                RouteExistingFiles = routes.RouteExistingFiles
            };
            using (routes.GetReadLock())
            {
                foreach (RouteBase base2 in routes)
                {
                    string a = AreaHelpers.GetAreaName(base2) ?? string.Empty;
                    usingAreas |= a.Length > 0;
                    if (string.Equals(a, areaName, StringComparison.OrdinalIgnoreCase))
                    {
                        routes2.Add(base2);
                    }
                }
            }
            if (!usingAreas)
            {
                return routes;
            }
            return routes2;
        }

        public static VirtualPathData GetVirtualPathForArea(this RouteCollection routes, RequestContext requestContext, RouteValueDictionary values)
        {
            return routes.GetVirtualPathForArea(requestContext, null, values);
        }

        public static VirtualPathData GetVirtualPathForArea(this RouteCollection routes, RequestContext requestContext, string name, RouteValueDictionary values)
        {
            bool flag;
            return routes.GetVirtualPathForArea(requestContext, name, values, out flag);
        }

        internal static VirtualPathData GetVirtualPathForArea(this RouteCollection routes, RequestContext requestContext, string name, RouteValueDictionary values, out bool usingAreas)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }
            if (!string.IsNullOrEmpty(name))
            {
                usingAreas = false;
                return routes.GetVirtualPath(requestContext, name, values);
            }
            string areaName = null;
            if (values != null)
            {
                object obj2;
                if (values.TryGetValue("area", out obj2))
                {
                    areaName = obj2 as string;
                }
                else if (requestContext != null)
                {
                    areaName = AreaHelpers.GetAreaName(requestContext.RouteData);
                }
            }
            RouteValueDictionary dictionary = values;
            RouteCollection routes2 = FilterRouteCollectionByArea(routes, areaName, out usingAreas);
            if (usingAreas)
            {
                dictionary = new RouteValueDictionary(values);
                dictionary.Remove("area");
            }
            return routes2.GetVirtualPath(requestContext, dictionary);
        }

        public static void IgnoreRoute(this RouteCollection routes, string url)
        {
            routes.IgnoreRoute(url, null);
        }

        public static void IgnoreRoute(this RouteCollection routes, string url, object constraints)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }
            IgnoreRouteInternal item = new IgnoreRouteInternal(url)
            {
                Constraints = new RouteValueDictionary(constraints)
            };
            routes.Add(item);
        }

        private sealed class IgnoreRouteInternal : Route
        {
            public IgnoreRouteInternal(string url)
                : base(url, new StopRoutingHandler())
            {
            }

            public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary routeValues)
            {
                return null;
            }
        }

        #region - GreedyRoute -

        public static Route MapGreedyRoute(this RouteCollection routes, string name, string url)
        {
            return routes.MapGreedyRoute(name, url, null, null);
        }

        public static Route MapGreedyRoute(this RouteCollection routes, string name, string url, object defaults)
        {
            return routes.MapGreedyRoute(name, url, defaults, null);
        }

        public static Route MapGreedyRoute(this RouteCollection routes, string name, string url, string[] namespaces)
        {
            return routes.MapGreedyRoute(name, url, null, null, namespaces);
        }

        public static Route MapGreedyRoute(this RouteCollection routes, string name, string url, object defaults, object constraints)
        {
            return routes.MapGreedyRoute(name, url, defaults, constraints, null);
        }

        public static Route MapGreedyRoute(this RouteCollection routes, string name, string url, object defaults, string[] namespaces)
        {
            return routes.MapGreedyRoute(name, url, defaults, null, namespaces);
        }

        public static Route MapGreedyRoute(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }
            Route item = new GreedyRoute(url, new MvcRouteHandler())
            {
                Defaults = CreateRouteValueDictionary(defaults),
                Constraints = CreateRouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary()
            };
            if ((namespaces != null) && (namespaces.Length > 0))
            {
                item.DataTokens["Namespaces"] = namespaces;
            }
            routes.Add(name, item);
            return item;
        }

        #endregion

        #region - DomainRoute -

        public static Route MapDomainRoute(this RouteCollection routes, string name, string domain, string url)
        {
            return routes.MapDomainRoute(name, url, null, null);
        }

        public static Route MapDomainRoute(this RouteCollection routes, string name, string domain, string url, object defaults)
        {
            return routes.MapDomainRoute(name, domain, url, defaults, null);
        }

        public static Route MapDomainRoute(this RouteCollection routes, string name, string domain, string url, string[] namespaces)
        {
            return routes.MapDomainRoute(name, domain, url, null, null, namespaces);
        }

        public static Route MapDomainRoute(this RouteCollection routes, string name, string domain, string url, object defaults, object constraints)
        {
            return routes.MapDomainRoute(name, domain, url, defaults, constraints, null);
        }

        public static Route MapDomainRoute(this RouteCollection routes, string name, string domain, string url, object defaults, string[] namespaces)
        {
            return routes.MapDomainRoute(name, domain, url, defaults, null, namespaces);
        }

        public static Route MapDomainRoute(this RouteCollection routes, string name, string domain, string url, object defaults, object constraints, string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }
            Route item = new DomainRoute(domain, url, new MvcRouteHandler())
            {
                Defaults = CreateRouteValueDictionary(defaults),
                Constraints = CreateRouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary()
            };
            if ((namespaces != null) && (namespaces.Length > 0))
            {
                item.DataTokens["Namespaces"] = namespaces;
            }
            routes.Add(name, item);
            return item;
        }

        #endregion
    }
}