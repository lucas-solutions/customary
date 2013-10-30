using System.Configuration;

namespace Custom.Data.Persistence.Repositories
{
    using Raven.Client;
    using Raven.Client.Embedded;

    public class EmbeddableDocumentContext : DocumentContext
    {
        public EmbeddableDocumentContext(string name)
            : base(name)
        {
        }

        protected override IDocumentStore CreateDocumentStore()
        {
            var store = new EmbeddableDocumentStore();

            var settings = ConfigurationManager.ConnectionStrings[Name];

            if (settings != null)
            {
                store.ConnectionStringName = Name;
            }
            else
            {
                store.DataDirectory = "/App_Data/" + Name;
            }

            return store;
        }
    }
}