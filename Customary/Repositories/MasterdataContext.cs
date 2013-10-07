using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Repositories
{
    using Custom.Metadata;
    using Raven.Client;
    using Raven.Client.Embedded;

    public class MasterdataContext : DocumentContext
    {
        public override string ConnectionStringName
        {
            get { return "MasterdataStore"; }
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