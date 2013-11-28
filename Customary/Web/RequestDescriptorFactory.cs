using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Web
{
    [Obsolete]
    public class RequestDescriptorFactory
    {
        static readonly string[] EmptySubdmain = new string[0];

        static readonly Dictionary<string, Func<RequestContext, string, RequestDescriptor>> _constructors = new Dictionary<string, Func<RequestContext, string, RequestDescriptor>>()
        {
            { "call", (RequestContext requestContext, string controllerName) => { return new CallRequestDescriptor(requestContext, controllerName); } },
            { "data", (RequestContext requestContext, string controllerName) => { return new DataRequestDescriptor(requestContext, controllerName); } },
            { "drop", (RequestContext requestContext, string controllerName) => { return new DropRequestDescriptor(requestContext, controllerName); } },
            { "edit", (RequestContext requestContext, string controllerName) => { return new EditRequestDescriptor(requestContext, controllerName); } },
            { "rss", (RequestContext requestContext, string controllerName) => { return new RssRequestDescriptor(requestContext, controllerName); } },
            { "site", (RequestContext requestContext, string controllerName) => { return new SiteRequestDescriptor(requestContext, controllerName); } },
            { "view", (RequestContext requestContext, string controllerName) => { return new ViewRequestDescriptor(requestContext, controllerName); } }
        };

        public static RequestDescriptor Create(RequestContext requestContext, string controllerName)
        {
            var url = requestContext.HttpContext.Request.Url;

            var subdomain = GetSubdomain(url);

            Func<RequestContext, string, RequestDescriptor> constuctorFn;

            if (_constructors.TryGetValue(string.Join(".", subdomain.Reverse()).ToLower(), out constuctorFn))
                return constuctorFn(requestContext, controllerName);

            return new RequestDescriptor(requestContext, controllerName);
        }

        public static string[] GetSubdomain(Uri uri)
        {
            if (uri.HostNameType != UriHostNameType.Dns)
                return EmptySubdmain;

            var host = uri.Host.Split('.');

            if (host.Length < 3)
                return EmptySubdmain;

            int skip = 0, take = host.Length - 2;

            if (string.Equals("www", host[0], StringComparison.InvariantCultureIgnoreCase))
            {
                skip++;
                take--;
            }

            return host.Skip(skip).Take(take).Reverse().ToArray();
        }
    }
}