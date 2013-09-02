using System;
using System.Collections.Generic;
using System.IO;

namespace Custom.Extensions
{
    using Newtonsoft.Json;
    using Raven.Abstractions.Data;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;
    using Dictionary = Dictionary<string, object>;

    public static class StreamExtensions
    {
        public static RavenJToken Data(this Stream stream)
        {
            if (stream == null)
                return null;

            if (!stream.CanRead)
                return null;

            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            RavenJObject request = null;

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(json))
                {
                    json = json.Trim();

                    if (json.StartsWith("{") && json.EndsWith("}"))
                    {
                        request = RavenJObject.Parse(json);
                    }
                }
            }

            return request != null ? request["data"] : null;
        }

        internal static JObject JObject(this Stream stream)
        {
            JObject value = null;
            if (stream != null)
            {
                if (stream.CanSeek)
                {
                    stream.Seek(0, SeekOrigin.Begin);
                }

                if (stream.CanRead)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var json = reader.ReadToEnd();
                        if (!string.IsNullOrEmpty(json))
                        {
                            json = json.Trim();

                            if (json.StartsWith("{") && json.EndsWith("}"))
                            {
                                value = Raven.Imports.Newtonsoft.Json.Linq.JObject.Parse(json);
                            }
                        }
                    }
                }
            }
            return value;
        }

        internal static void CopyTo(this Stream source, Stream target)
        {
            var bb = new Byte[source.Length];
            source.Read(bb, 0, bb.Length);
            target.Write(bb, 0, bb.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Byte[] ToByteArray(this Stream stream)
        {
            var mm = new MemoryStream();
            stream.CopyTo(mm);
            return mm.ToArray();
        }

        public static bool TryGetValue(this Stream stream, out Dictionary value)
        {
            value = null;
            using (var reader = new StreamReader(stream))
            {
                value = JsonConvert.DeserializeObject<Dictionary>(reader.ReadToEnd());
            }
            return value != null;
        }

        public static bool TryGetValue(this Stream stream, string contentType, out Dictionary value)
        {
            value = null;
            return false;
        }

        public static bool TryGetValue<T>(this Stream stream, out T value)
            where T : new()
        {
            value = default(T);
            using (var reader = new StreamReader(stream))
            {
                value = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            }
            return value != null;
        }

        public static bool TryGetValue<T>(this Stream stream, string contentType, out T value)
            where T : new()
        {
            value = default(T);
            using (var reader = new StreamReader(stream))
            {
                value = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            }
            return value != null;
        }
    }
}
