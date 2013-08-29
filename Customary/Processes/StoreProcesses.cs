using System;
using System.Collections.Generic;

namespace Custom.Processes
{
    using Custom.Reflection;
    using Newtonsoft.Json;
    using Raven.Client;
    using Raven.Json.Linq;

    public static class StoreProcesses
    {
        [ThreadStatic]
        private static IDocumentSession _session;
        private static IDocumentStore _store;

        public static IDocumentSession Session
        {
            get { return _session ?? (_session = Store.OpenSession()); }
        }

        private static IDocumentStore Store
        {
            get { return _store ?? (_store = DocumentStoreHolder.Store); }
        }

        public static List<MemberDescriptor> Types;
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
                    var json = root.Value<RavenJArray>("Type").ToString();
                    Types = JsonConvert.DeserializeObject<List<MemberDescriptor>>(json, new MemberConverter());
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