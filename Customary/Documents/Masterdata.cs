using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Documents
{
    using Raven.Client;
    using Raven.Client.Embedded;

    public class Masterdata : DocumentStoreHolder
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