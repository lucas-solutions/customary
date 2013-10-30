using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence
{
    using Custom.Controllers;
    using Custom.Data.Metadata;
    using Custom.Data.Serialization;
    using Newtonsoft.Json;
    using Raven.Client;
    using Raven.Client.Embedded;
    using Raven.Json.Linq;

    public class GlobalizationContext : DocumentContext
    {
        public GlobalizationContext()
            : base("Globalization")
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

        public static bool Import(string fileName)
        {
            var file = new System.IO.FileInfo(fileName);

            if (!file.Exists)
                return false;

            using (var stream = file.OpenRead())
            {
                var root = RavenJObject.TryLoad(stream);
                var converter = new TypeConverter();

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