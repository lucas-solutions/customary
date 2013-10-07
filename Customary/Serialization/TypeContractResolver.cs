using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Serialization
{
    using Custom.Metadata;
    using Raven.Imports.Newtonsoft.Json.Serialization;

    public class TypeContractResolver : DefaultContractResolver
    {
        public override JsonContract ResolveContract(Type type)
        {
            if (typeof(Descriptor).IsAssignableFrom(type))
            {
                return new JsonArrayContract(typeof(Descriptor))
                {
                    ItemConverter = new TypeConverter()
                };
            }

            return base.ResolveContract(type);
        }
    }
}