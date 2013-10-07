using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Custom.Serialization
{
    using Custom.Metadata;
    using Raven.Imports.Newtonsoft.Json.Linq;

    public class TypeConverter : JsonCreationConverter<TypeDescriptor>
    {
        protected override TypeDescriptor Create(Type objectType, JObject jObject)
        {
            var id = (jObject.Value<string>("id") ?? string.Empty).Split('/');

            MemberTypes type;

            switch (id.Length)
            {
                case 0:
                case 1:
                case 2:
                    return (TypeDescriptor)Activator.CreateInstance(objectType);

                default:
                    var typeName = id.Reverse().Skip(1).FirstOrDefault();
                    if (System.Enum.TryParse<MemberTypes>(typeName, out type))
                        switch (type)
                        {
                            case MemberTypes.Complex:
                                return new ComplexDescriptor();

                            case MemberTypes.Enum:
                                return new EnumDescriptor();

                            case MemberTypes.Entity:
                                return new EntityDescriptor();

                            case MemberTypes.Value:
                                return new ValueDescriptor();
                        }
                    break;
            }

            return (TypeDescriptor)Activator.CreateInstance(objectType);
        }
    }
}