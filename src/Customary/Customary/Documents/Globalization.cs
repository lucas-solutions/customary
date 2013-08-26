using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Documents
{
    using Custom.Controllers;
    using Custom.Reflection;
    using Custom.Serialization;
    using Newtonsoft.Json;
    using Raven.Client;
    using Raven.Client.Embedded;
    using Raven.Json.Linq;

    public class Globalization
    {
        public const string ConnectionStringName = "BusinessStore";

        private static readonly object _lock = new object();

        [ThreadStatic]
        private static IDocumentSession _session;

        private static IDocumentStore _store;

        public static IDocumentSession Session
        {
            get { return _session ?? (_session = Store.OpenSession()); }
        }

        public static IDocumentStore Store
        {
            get
            {
                var store = _store;

                // return without locking if already exist
                if (store != null)
                    return store;

                // lock and check again
                lock (_lock)
                {
                    // create new instance if doesn't exist
                    store = _store ?? (_store = new EmbeddableDocumentStore()
                    {
                        ConnectionStringName = Business.ConnectionStringName
                    });

                    //instance.Conventions.IdentityPartsSeparator = "-";

                    // initialize store
                    store.Initialize();

                    // save store instance
                    _store = store;
                }

                return store;
            }
        }

        public void SaveChanges()
        {
            var session = _session;

            if (session != null)
            {
                _session = null;

                session.SaveChanges();
            }
        }

        public static bool Import(string fileName)
        {
            var file = new System.IO.FileInfo(fileName);

            if (!file.Exists)
                return false;

            using (var stream = file.OpenRead())
            {
                var root = RavenJObject.TryLoad(stream);
                var converter = new MemberConverter();

                try
                {
                    /*var json = root.Value<RavenJArray>("Type").ToString();
                    var types = JsonConvert.DeserializeObject<List<MemberDescriptor>>(json, new MemberConverter());
                    foreach (var t in types)
                    {
                        Session.Store(t);
                    }*/
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                }
                /*
                 foreach (var typesJArray in root.Value<RavenJArray>("Types"))
                 {
                     foreach (var typeJObject in typesJArray.Values<RavenJObject>())
                     {
                         var descriptor = converter
                     }
                 }*/
            }

            return true;
        }
    }
}