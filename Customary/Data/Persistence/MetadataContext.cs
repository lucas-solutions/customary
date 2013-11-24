using System.Linq;

namespace Custom.Data.Persistence
{
    using Custom.Data.Metadata;
    using global::Raven.Abstractions;
    using global::Raven.Abstractions.Data;
    using global::Raven.Client;
    using global::Raven.Client.Embedded;
    using global::Raven.Imports.Newtonsoft.Json;
    using global::Raven.Imports.Newtonsoft.Json.Serialization;

    public class MetadataContext : DocumentContext
    {
        private readonly object _lock = new object();

        public MetadataContext()
            : base("Metadata")
        {
        }

        protected override IDocumentStore CreateDocumentStore()
        {
            var store = new EmbeddableDocumentStore
            {
                ConnectionStringName = Name
            };

            return store;
        }

        protected override void InitializeDocumentStore(IDocumentStore store)
        {
            base.InitializeDocumentStore(store);

            var indexCreationTask = new Indexes.MetadaTypeIndexCreationTask();
            
            indexCreationTask.Execute(store);
        }
    }
}