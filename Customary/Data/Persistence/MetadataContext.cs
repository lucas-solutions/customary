using System.Linq;

namespace Custom.Data.Persistence
{
    using Custom.Data.Metadata;
    using Raven.Abstractions;
    using Raven.Abstractions.Data;
    using Raven.Client;
    using Raven.Client.Embedded;
    using Raven.Imports.Newtonsoft.Json;
    using Raven.Imports.Newtonsoft.Json.Serialization;

    public class MetadataContext : DocumentContext
    {
        private readonly object _lock = new object();
        

        public override string ConnectionStringName
        {
            get { return "Metadata"; }
        }

        protected override IDocumentStore CreateDocumentStore()
        {
            var store = new EmbeddableDocumentStore
            {
                ConnectionStringName = ConnectionStringName
            };

            store.Conventions.SaveEnumsAsIntegers = true;

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