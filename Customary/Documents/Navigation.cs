using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Documents
{
    using Custom.Routing;
    using Raven.Client;
    using Raven.Client.Embedded;
    
    public class Navigation : DocumentStoreHolder
    {
        public override string ConnectionStringName
        {
            get { return "NavigationStore"; }
        }

        protected override IDocumentStore CreateDocumentStore()
        {
            return new EmbeddableDocumentStore
            {
                ConnectionStringName = ConnectionStringName
            };
        }

        public static ControllerDescriptor Describe(RequestContext requestContext, string controllerName)
        {
            return new ControllerDescriptor(requestContext, controllerName);
        }
    }
}