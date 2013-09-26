using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom
{
    using Raven.Imports.Newtonsoft.Json;
    using Raven.Imports.Newtonsoft.Json.Serialization;
    using Raven.Json.Linq;

    public static class RavenExtensions
    {
        public static RavenJArray ToRavenJArray(this IEnumerable<RavenJObject> source)
        {
            var result = new RavenJArray();

            foreach (var item in source)
                result.Add(item);

            return result;
        }

        public static RavenJArray ToRavenJArray(this IEnumerable<RavenJToken> source)
        {
            var result = new RavenJArray();

            foreach (var item in source)
                result.Add(item);

            return result;
        }

        public static RavenJArray ToRavenJArray(this IEnumerable<RavenJValue> source)
        {
            var result = new RavenJArray();

            foreach (var item in source)
                result.Add(item);

            return result;
        }

        public static RavenJObject ToJObject(this object source)
        {
            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var jo = RavenJObject.FromObject(source, serializer);

            return jo;
        }
    }
}