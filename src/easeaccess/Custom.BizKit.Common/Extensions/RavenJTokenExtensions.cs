using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Extensions
{
    using Raven.Json.Linq;
using System.Collections;

    public static class RavenJTokenExtensions
    {
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
            foreach (RavenJToken iteratorVariable0 in source)
            {
                if (iteratorVariable0 is RavenJValue)
                {
                    yield return iteratorVariable0.Convert<U>();
                }
                else
                {
                    foreach (U iteratorVariable1 in iteratorVariable0.Values<U>())
                    {
                        yield return iteratorVariable1;
                    }
                }
                RavenJObject iteratorVariable2 = (RavenJObject)iteratorVariable0;
                RavenJToken token = iteratorVariable2[key];
                if (token != null)
                {
                    yield return token.Convert<U>();
                }
            }
        }
    }
}
