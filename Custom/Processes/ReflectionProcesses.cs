using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Processes
{
    using Custom.Objects;
    using Custom.Reflection;
    using Raven.Client;
    
    public static class ReflectionProcesses
    {
        [ThreadStatic]
        private static IDocumentSession _session;
        private static IDocumentStore _store;

        public static IDocumentSession Session
        {
            get { return _session ?? (_session = Store.OpenSession()); }
        }

        private static IDocumentStore Store
        {
            get { return _store ?? (_store = DocumentStoreHolder.Store); }
        }

        public static TypeDescriptor Describe(string name)
        {
            var id = "Type/" + name;
            var descriptor = System.Web.HttpContext.Current.Items[id] as TypeDescriptor;
            if (descriptor == null)
            {
                descriptor = Session.Load<TypeDescriptor>(id);
                System.Web.HttpContext.Current.Items[id] = descriptor;
            }
            return descriptor;
        }

        public static ControllerDescriptor Describe(RequestContext requestContext, string controllerName)
        {
            return new ControllerDescriptor(requestContext, controllerName);
        }

        public static void RegisterIdConventions()
        {
            Store.Conventions.DocumentKeyGenerator = (dbname, commands, entity) => Store.Conventions.GetTypeTagName(entity.GetType()) + "/";
            Store.Conventions.RegisterIdConvention<TypeDescriptor>((dbname, commands, type) => "Type/" + type.Name);
        }
    }
}