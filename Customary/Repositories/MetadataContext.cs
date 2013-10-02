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
            var store = new EmbeddableDocumentStore
            {
                ConnectionStringName = ConnectionStringName
            };

            store.Conventions.SaveEnumsAsIntegers = true;

            return store;
        }

        public QueryResult QueryType(string fullname)
        {
            var split = fullname.Split('.');
            var ns = string.Join(".", split.Take(split.Length - 1));
            var name = split.LastOrDefault();

            var indexQuery = new IndexQuery
            {
                Query = string.Format("Name: {0} Namespace: {1}", name, ns)
            };

            return Store.DatabaseCommands.Query(Indexes.MetadaTypeIndexCreationTask.Name, indexQuery, null);
        }

        protected override void InitializeDocumentStore(IDocumentStore store)
        {
            base.InitializeDocumentStore(store);

            var indexCreationTask = new Indexes.MetadaTypeIndexCreationTask();
            //store.DatabaseCommands.PutIndex(indexCreationTask.IndexName, indexCreationTask.CreateIndexDefinition());
            indexCreationTask.Execute(store);

            //store.Conventions.RegisterIdConvention<Metadata.TypeDescriptor>(((dbname, commands, type) => "Type/" + commands.NextIdentityFor("Type")));

            /*store.Conventions.RegisterIdConvention<Metadata.TypeDescriptor>(((dbname, commands, type) => "Type/" + type.ID.ToString("N")));
            store.Conventions.RegisterIdConvention<Metadata.PrimitiveDescriptor>(((dbname, commands, type) => "Type/" + type.ID.ToString("N")));
            store.Conventions.RegisterIdConvention<Metadata.ObjectDescriptor>(((dbname, commands, type) => "Type/" + type.ID.ToString("N")));
            store.Conventions.RegisterIdConvention<Metadata.EnumDescriptor>(((dbname, commands, type) => "Type/" + type.ID.ToString("N")));
            store.Conventions.RegisterIdConvention<Metadata.UnitDescriptor>(((dbname, commands, type) => "Type/" + type.ID.ToString("N")));
            store.Conventions.RegisterIdConvention<Metadata.EntityDescriptor>(((dbname, commands, type) => "Type/" + type.ID.ToString("N")));

            store.Conventions.FindTypeTagName = type =>
                {
                    return type.IsSubclassOf(typeof(Metadata.TypeDescriptor))
                        ? "Type"//DocumentConvention.DefaultTypeTagName(typeof(TypeDescriptor))
                        : DocumentConvention.DefaultTypeTagName(type);
                };*/

        }
    }
}