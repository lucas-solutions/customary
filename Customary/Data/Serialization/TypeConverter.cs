using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Custom.Data.Serialization
{
    using Custom.Data.Metadata;
    using Raven.Imports.Newtonsoft.Json.Linq;

    public class TypeConverter : JsonCreationConverter<TypeDefinition>
    {
        protected override TypeDefinition Create(Type objectType, JObject jObject)
        {
            var id = (jObject.Value<string>("id") ?? string.Empty).Split('/');

            MemberTypes type;

            switch (id.Length)
            {
                case 0:
                case 1:
                case 2:
                    return (TypeDefinition)Activator.CreateInstance(objectType);

                default:
                    var typeName = id.Reverse().Skip(1).FirstOrDefault();
                    if (System.Enum.TryParse<MemberTypes>(typeName, out type))
                        switch (type)
                        {
                            case MemberTypes.Enum:
                                return new EnumDefinition();

                            case MemberTypes.Model:
                                return new ModelDefinition();

                            case MemberTypes.Unit:
                                break;

                            case MemberTypes.Value:
                                return new ValueDefinition();
                        }
                    break;
            }

            return (TypeDefinition)Activator.CreateInstance(objectType);
        }
    }
}