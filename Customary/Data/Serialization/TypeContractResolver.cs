using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Serialization
{
    using Custom.Data.Metadata;
    using Raven.Imports.Newtonsoft.Json.Serialization;

    public class TypeContractResolver : DefaultContractResolver
    {
        public override JsonContract ResolveContract(Type type)
        {
            if (typeof(DefinitionBase).IsAssignableFrom(type))
            {
                return new JsonArrayContract(typeof(DefinitionBase))
                {
                    ItemConverter = new TypeConverter()
                };
            }

            return base.ResolveContract(type);
        }
    }
}