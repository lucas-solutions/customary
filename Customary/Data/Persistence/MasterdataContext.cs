using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence
{
    using Custom.Data.Metadata;
    using Raven.Client;
    using Raven.Client.Embedded;

    public class MasterdataContext : DocumentContext
    {
        public override string ConnectionStringName
        {
            get { return "Masterdata"; }
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