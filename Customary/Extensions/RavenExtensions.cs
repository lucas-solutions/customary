using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Custom
{
    using Custom.Data.Metadata;
    using Custom.Models;
    using global::Raven.Abstractions;
    using global::Raven.Imports.Newtonsoft.Json;
    using global::Raven.Imports.Newtonsoft.Json.Linq;
    using global::Raven.Imports.Newtonsoft.Json.Serialization;
    using global::Raven.Json.Linq;
    
    public static partial class RavenExtensions
    {
        // https://github.com/ravendb/ravendb/blob/master/Raven.Abstractions/Extensions/JsonExtensions.cs


        /// <summary>
        /// Deserialize a <param name="self"/> to an instance of<typeparam name="T"/>
        /// </summary>
        public static T Deserialize<T>(this RavenJObject self, params JsonConverter[] converters)
            where T : class
        {
            try
            {
                var serializer = CreateDefaultJsonSerializer(/*new CamelCasePropertyNamesContractResolver()*/);

                if (converters != null)
                    foreach (var converter in converters)
                        serializer.Converters.Add(converter);

                return (T)serializer.Deserialize(new RavenJTokenReader(self), typeof(T));
            }
            catch (Exception e)
            {
                var msg = e.Message;
            }

            return null;
        }

        public static JsonSerializer CreateDefaultJsonSerializer(IContractResolver contractResolver = null)
        {
            var jsonSerializer = new JsonSerializer
            {
                DateParseHandling = DateParseHandling.None,
                ContractResolver = contractResolver ?? new DefaultContractResolver()
            };
            foreach (var defaultJsonConverter in Default.Converters)
            {
                jsonSerializer.Converters.Add(defaultJsonConverter);
            }
            return jsonSerializer;
        }

        public static RavenJArray ToRavenJArray<T>(this IEnumerable<T> source)
            where T : RavenJToken
        {
            var result = new RavenJArray();

            foreach (var item in source)
                result.Add(item);

            return result;
        }

        public static RavenJObject ToRavenJObject(this object source)
        {
            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var jo = RavenJObject.FromObject(source, serializer);

            return jo;
        }

        public static RavenJArray Merge(this RavenJArray target, RavenJArray source, ModelDefinition descriptor)
        {
            var idName = descriptor != null ? descriptor.IdProperty : null;

            foreach (var value in source.Values())
            {
            }
            return target;
        }

        public static RavenJObject Merge(this RavenJObject target, RavenJObject source, ModelDefinition descriptor)
        {
            var idName = descriptor != null ? descriptor.IdProperty : null;

            foreach (var item in source)
            {
                var key = item.Key;
                var value = item.Value;

                switch (value.Type)
                {
                    case JTokenType.Array:
                        var array = target.Value<RavenJArray>(item.Key);
                        if (array != null)
                        {
                            var propDescriptor = descriptor.Properties.FirstOrDefault(o => string.Equals(o.Name, item.Key, StringComparison.InvariantCultureIgnoreCase));
                            var propType = propDescriptor.Type;
                            array.Merge((RavenJArray)item.Value, descriptor);
                        }
                        break;

                    case JTokenType.Object:
                        break;
                }
            }
            return target;
        }

        public static void Validate(this RavenJArray value, TypeDefinition descriptor, List<Annotation> annotations)
        {
        }

        public static void Validate(this RavenJObject value, ModelDefinition descriptor, List<Annotation> annotations)
        {
        }

        public static void Validate(this RavenJToken value, TypeDefinition descriptor, List<Annotation> annotations)
        {
        }

        public static void Validate(this RavenJValue value, TypeDefinition descriptor, List<Annotation> annotations)
        {
        }

        /*private static string[] _readOnly = new[]
        {
            "CreatedBy",
            "CreatedOn",
            "ModifiedBy",
            "ModifiedOn"
        };

        private static RavenJToken Update(RavenJTokenCallbackModel model)
        {
            switch (model.Token.Type)
            {
                case JTokenType.Object:
                    var obj = model.Token as RavenJObject;
                    RavenJToken id, pos;
                    if (obj.TryGetValue("id", out id) && id.Type.Equals(JTokenType.String))
                    {
                        model.Id = id.ToString();
                        obj.Remove("id");
                    }
                    if (obj.TryGetValue("pos", out pos) && pos.Type.Equals(JTokenType.Integer))
                    {
                        model.Position = (int)Convert.ChangeType(pos.ToString(), typeof(int));
                        obj.Remove("id");
                    }
                    foreach (var name in _readOnly)
                    {
                        if (obj.TryGetValue(name, out pos))
                            obj.Remove(name);
                    }
                    break;
            }
            return model.Token;
        }

        public static bool Each(this RavenJObject source, Func<RavenJTokenCallbackModel, bool> callback)
        {
            RavenJTokenCallbackModel model;

            var data = source["data"];

            if (data != null)
            {
                switch (data.Type)
                {
                    case JTokenType.Array:
                        var index = 0;
                        var array = data as RavenJArray;
                        foreach (var token in array)
                        {
                            model = new RavenJTokenCallbackModel { Token = token, Index = index };
                            Update(model);
                            if (!callback(model))
                                break;
                            index++;
                        }
                        break;

                    default:
                        model = new RavenJTokenCallbackModel { Token = data, Index = 0 };
                        Update(model);
                        callback(model);
                        break;
                }
            }
            else
            {
                model = new RavenJTokenCallbackModel { Token = source, Index = 0 };
                Update(model);
                callback(model);
            }

            return true;
        }

        public static bool Each<T>(this RavenJObject source, Func<RavenJTokenCallbackModel<T>, bool> callback)
        {
            RavenJTokenCallbackModel<T> model;

            var data = source["data"];

            if (data != null)
            {
                switch (data.Type)
                {
                    case JTokenType.Array:
                        var index = 0;
                        var array = data as RavenJArray;
                        foreach (var token in array)
                        {
                            model = new RavenJTokenCallbackModel<T> { Token = token, Index = index };
                            model.Value = JsonConvert.DeserializeObject<T>(Update(model).ToString());
                            if (!callback(model))
                                break;
                            index++;
                        }
                        break;

                    default:
                        model = new RavenJTokenCallbackModel<T> { Token = data, Index = 0 };
                        model.Value = JsonConvert.DeserializeObject<T>(Update(model).ToString());
                        callback(model);
                        break;
                }
            }
            else
            {
                model = new RavenJTokenCallbackModel<T> { Token = source, Index = 0 };
                model.Value = JsonConvert.DeserializeObject<T>(Update(model).ToString());
                callback(model);
            }

            return true;
        }

        internal static U Convert<U>(this RavenJToken token)
        {
            if ((token is RavenJArray) && (typeof(U) == typeof(RavenJObject)))
            {
                RavenJArray array = (RavenJArray)token;
                RavenJObject obj2 = new RavenJObject();
                foreach (RavenJObject obj3 in array)
                {
                    obj2[obj3["Key"].Value<string>()] = obj3["Value"];
                }
                return (U)obj2;
            }
            bool cast = typeof(RavenJToken).IsAssignableFrom(typeof(U));
            return token.Convert<U>(cast);
        }

        internal static IEnumerable<U> Convert<U>(this IEnumerable<RavenJToken> source)
        {
            bool cast = typeof(RavenJToken).IsAssignableFrom(typeof(U));
            return (from token in source select token.Convert<U>(cast));
        }

        internal static U Convert<U>(this RavenJToken token, bool cast)
            where U : RavenJToken
        {
            if (cast)
            {
                return (U)token;
            }
            if (token != null)
            {
                DateTimeOffset offset;
                RavenJValue value2 = token as RavenJValue;
                if (value2 == null)
                {
                    throw new InvalidCastException("Cannot cast {0} to {1}.".FormatWith(CultureInfo.InvariantCulture, new object[] { token.GetType(), typeof(U) }));
                }
                if (value2.Value is U)
                {
                    return (U)value2.Value;
                }
                Type nullableType = typeof(U);
                if (nullableType.IsGenericType && (nullableType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                {
                    if (value2.Value == null)
                    {
                        return default(U);
                    }
                    nullableType = Nullable.GetUnderlyingType(nullableType);
                }
                if (nullableType == typeof(Guid))
                {
                    if (value2.Value == null)
                    {
                        return default(U);
                    }
                    return (U)new Guid(value2.Value.ToString());
                }
                if (nullableType == typeof(string))
                {
                    if (value2.Value == null)
                    {
                        return default(U);
                    }
                    return (U)value2.Value.ToString();
                }
                if ((nullableType == typeof(DateTime)) && (value2.Value is string))
                {
                    DateTime time;
                    if (DateTime.TryParseExact((string)value2.Value, Default.DateTimeFormatsToRead, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out time))
                    {
                        return (U)time;
                    }
                    return (U)RavenJsonTextReader.ParseDateMicrosoft((string)value2.Value);
                }
                if (!(nullableType == typeof(DateTimeOffset)) || !(value2.Value is string))
                {
                    return (U)System.Convert.ChangeType(value2.Value, nullableType, CultureInfo.InvariantCulture);
                }
                if (DateTimeOffset.TryParseExact((string)value2.Value, Default.DateTimeFormatsToRead, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out offset))
                {
                    return (U)offset;
                }
            }
            return default(U);
        }

        public static U Value<U>(this RavenJToken value)
        {
            return value.Convert<U>();
        }

        public static U Value<U>(this IEnumerable<RavenJToken> value)
        {
            return value.Value<RavenJToken, U>();
        }

        public static U Value<T, U>(this IEnumerable<T> value) where T : RavenJToken
        {
            RavenJToken token = value as RavenJToken;
            if (token == null)
            {
                throw new ArgumentException("Source value must be a RavenJToken.");
            }
            return token.Convert<U>();
        }

        public static IEnumerable<RavenJToken> Values(this IEnumerable<RavenJToken> source)
        {
            return source.Values(null);
        }

        public static IEnumerable<U> Values<U>(this IEnumerable<RavenJToken> source)
        {
            return source.Values<U>(null);
        }

        public static IEnumerable<RavenJToken> Values(this IEnumerable<RavenJToken> source, string key)
        {
            return source.Values<RavenJToken>(key);
        }

        internal static IEnumerable<U> Values<U>(this IEnumerable<RavenJToken> source, string key)
        {
            foreach (RavenJToken item in source)
            {
                if (item is RavenJValue)
                {
                    yield return item.Convert<U>();
                }
                else
                {
                    foreach (U iteratorVariable1 in item.Values<U>())
                    {
                        yield return iteratorVariable1;
                    }
                }
                RavenJObject iteratorVariable2 = (RavenJObject)item;
                RavenJToken token = iteratorVariable2[key];
                if (token != null)
                {
                    yield return token.Convert<U>();
                }
            }
        }*/


        public static void MergeInto(this JContainer left, JToken right)
        {
            foreach (var rightChild in right.Children<JProperty>())
            {
                var rightChildProperty = rightChild;
                var leftProperty = left.SelectToken(rightChildProperty.Name);

                if (leftProperty == null)
                {
                    // no matching property, just add 
                    left.Add(rightChild);
                }
                else
                {
                    var leftObject = leftProperty as JObject;
                    if (leftObject == null)
                    {
                        // replace value
                        var leftParent = (JProperty)leftProperty.Parent;
                        leftParent.Value = rightChildProperty.Value;
                    }

                    else
                        // recurse object
                        MergeInto(leftObject, rightChildProperty.Value);
                }
            }
        }

        /// <summary>
        /// Merge two JTokens into a new one by doing a DeepClone first then calling the function above.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static JToken Merge(this JToken left, JToken right)
        {
            switch (left.Type)
            {
                case JTokenType.Object:
                    var leftClone = (JContainer)left.DeepClone();
                    MergeInto(leftClone, right);
                    return leftClone;

                default:
                    return right.DeepClone();
            }
        }
    }
}