using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Documents
{
    using Raven.Client;
    using Raven.Client.Embedded;

    public class DocumentStoreHolder
    {
        public static string ConnectionStringName = "RavenDB";
        private static readonly object _lock = new object();
        private static IDocumentStore _instance;

        public static IDocumentStore Store
        {
            get
            {
                var instance = _instance;

                // return without locking if already exist
                if (instance != null)
                    return instance;

                // lock and check again
                lock (_lock)
                {
                    // create new instance if doesn't exist
                    instance = _instance ?? (_instance = new EmbeddableDocumentStore()
                    {
                        ConnectionStringName = DocumentStoreHolder.ConnectionStringName
                    });

                    //instance.Conventions.IdentityPartsSeparator = "-";

                    // initialize store
                    instance.Initialize();

                    // save store instance
                    _instance = instance;
                }

                return instance;
            }
        }
    }
}
