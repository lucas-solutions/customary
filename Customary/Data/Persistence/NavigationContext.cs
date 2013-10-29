using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Data.Persistence
{
    using Custom.Web.Mvc;
    using Raven.Client;
    using Raven.Client.Embedded;
    
    public class NavigationContext : DocumentContext
    {
        public override string ConnectionStringName
        {
            get { return "Navigation"; }
        }

        protected override IDocumentStore CreateDocumentStore()
        {
            return new EmbeddableDocumentStore
            {
                ConnectionStringName = ConnectionStringName
            };
        }
    }
}