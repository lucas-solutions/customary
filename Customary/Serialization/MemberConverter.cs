using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Serialization
{
    using Custom.Metadata;
    using Newtonsoft.Json.Linq;

    public class MemberConverter : JsonCreationConverter<MemberDescriptor>
    {
        protected override MemberDescriptor Create(Type objectType, JObject jObject)
        {
            MemberTypes type;
            Enum.TryParse<MemberTypes>(jObject.Value<string>("MemberType"), out type);

            switch (type)
            {
                case MemberTypes.Enum:
                    return new EnumDescriptor();

                case MemberTypes.Complex:
                    return new ComplexDescriptor();

                case MemberTypes.Entity:
                    return new EntityDescriptor();

                case MemberTypes.Property:
                    return new PropertyDescriptor();

                case MemberTypes.Method:
                    return new MethodDescriptor();

                case MemberTypes.Event:
                    return new EventDescriptor();

                default:
                    return new MemberDescriptor();
            }
        }
    }
}