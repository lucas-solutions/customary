using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Serialization
{
    using Custom.Reflection;
    using Newtonsoft.Json.Serialization;

    public class MemberContractResolver : DefaultContractResolver
    {
        public override JsonContract ResolveContract(Type type)
        {
            if (typeof(MemberDescriptor).IsAssignableFrom(type))
            {
                return new JsonArrayContract(typeof(MemberDescriptor))
                {
                    ItemConverter = new MemberConverter()
                };
            }

            return base.ResolveContract(type);
        }
    }
}