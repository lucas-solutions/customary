using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Documents
{
    using Custom.Controllers;
    using Custom.Metadata;
    using Custom.Serialization;
    using Newtonsoft.Json;
    using Raven.Client;
    using Raven.Client.Embedded;
    using Raven.Json.Linq;

    public class Business : DocumentStoreHolder
    {
        public override string ConnectionStringName
        {
            get { return "BusinessStore"; }
        }

        protected override IDocumentStore CreateDocumentStore()
        {
            return new EmbeddableDocumentStore
            {
                ConnectionStringName = ConnectionStringName
            };
        }

        public bool Import(string fileName)
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
                    var types = JsonConvert.DeserializeObject<List<MemberDescriptor>>(json, new MemberConverter());
                    foreach (var t in types)
                    {
                        Session.Store(t);
                    }
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

        public BusinessLookup Lookup(Uri url)
        {
            var lookup = new BusinessLookup(url);

            var name = lookup.Path.Pop();

            if (lookup.Path.Count > 0)
            {
                var segment = name;
                name = lookup.Path.Pop();

                if ("Applications".Equals(segment, StringComparison.InvariantCultureIgnoreCase))
                {
                    var application = Session.Advanced.LuceneQuery<RavenJObject>("ByHost").WhereStartsWith("Id", "Applications/").Where("Host: '" + name + "'").FirstOrDefault();
                }

                lookup.Path.Push(name);
                name = segment;
            }

            lookup.Path.Push(name);

            /*var resource = Application(Masterdata.SiteName);

            if (resource != null)
                return Value(resource.Lookup(lookup), resource);*/

            return lookup;
        }
    }
}