using System.Linq;

namespace Custom.Repositories
{
    using Custom.Metadata;
    using Raven.Abstractions;
    using Raven.Abstractions.Data;
    using Raven.Client;
    using Raven.Client.Embedded;
    using Raven.Imports.Newtonsoft.Json;
    using Raven.Imports.Newtonsoft.Json.Serialization;

    public class MetadataContext : DocumentContext
    {
        private readonly object _lock = new object();
        private Directory _directory;

        public Directory Directory
        {
            get
            {
                var directory = _directory;

                if (directory == null)
                {
                    lock (_lock)
                    {
                        directory = _directory ?? (_directory = Metadata.Directory.Load(Global.Metadata.Store));
                    }
                }

                return directory;
            }
            set
            {
                _directory = value;
            }
        }

        public override string ConnectionStringName
        {
            get { return "MetadataStore"; }
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