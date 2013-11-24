using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Serialization
{
    using Custom.Data.Metadata;
    using global::Raven.Imports.Newtonsoft.Json.Serialization;

    public class TypeContractResolver : DefaultContractResolver
    {
        public override JsonContract ResolveContract(System.Type type)
        {
            if (typeof(BaseDefinition).IsAssignableFrom(type))
            {
                return new JsonArrayContract(typeof(BaseDefinition))
                {
                    ItemConverter = new TypeConverter()
                };
            }

            return base.ResolveContract(type);
        }
    }
}