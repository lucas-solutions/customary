using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Documents
{
    using Custom.Metadata;
    using Raven.Client;
    using Raven.Client.Embedded;

    public class Metadata : DocumentStoreHolder
    {
        public override string ConnectionStringName
        {
            get { return "MetadataStore"; }
        }

        public IQueryable<TypeDescriptor> Types
        {
            get { return Session.Query<TypeDescriptor>(); }
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