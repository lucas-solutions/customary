using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Data.Persistence
{
    using Custom.Web.Mvc;
    using global::Raven.Client;
    using global::Raven.Client.Embedded;
    
    public class NavigationContext : DocumentContext
    {
        public NavigationContext()
            : base("Navigation")
        {
        }

        protected override IDocumentStore CreateDocumentStore()
        {
            return new EmbeddableDocumentStore
            {
                ConnectionStringName = Name
            };
        }
    }
}