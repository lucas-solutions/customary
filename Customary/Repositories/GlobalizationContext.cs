using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Repositories
{
    using Custom.Controllers;
    using Custom.Metadata;
    using Custom.Serialization;
    using Newtonsoft.Json;
    using Raven.Client;
    using Raven.Client.Embedded;
    using Raven.Json.Linq;

    public class GlobalizationContext
    {
        public string ConnectionStringName { get { return "GlobalizationStore"; } }

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