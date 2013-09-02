using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Custom.Utils
{
    using Custom.Extensions;

    public class CompressionUtils
    {
        public static byte[] GZip(string instance)
        {
            return GZip(Encoding.UTF8.GetBytes(instance));
        }

        public static byte[] GZip(byte[] instance)
        {
            MemoryStream stream = new MemoryStream();
            GZipStream stream2 = new GZipStream((Stream)stream, CompressionMode.Compress);
            stream2.Write(instance, 0, instance.Length);
            stream2.Close();
            return stream.ToArray();
        }

        public static void GZipAndSend(object instance)
        {
            GZipAndSend((instance != null) ? instance.ToString() : "");
        }

        public static void GZipAndSend(string instance)
        {
            GZipAndSend(instance, "application/json");
        }

        public static void GZipAndSend(string instance, string responseType)
        {
            GZipAndSend(Encoding.UTF8.GetBytes(instance), responseType);
        }

        public static void GZipAndSend(byte[] instance, string responseType)
        {
            if (IsGZipSupported)
            {
                Send(GZip(instance), responseType, true);
            }
            else
            {
                Send(instance, responseType);
            }
        }

        public static void Send(byte[] instance, string responseType)
        {
            Send(instance, responseType, false);
        }

        public static void Send(byte[] instance, string responseType, bool isGZip)
        {
            HttpResponse response = HttpContext.Current.Response;
            if (isGZip)
            {
                response.AppendHeader("Content-Encoding", "gzip");
                response.Charset = "utf-8";
            }
            response.ContentType = responseType;
            response.BinaryWrite(instance);
        }

        public static bool IsGZipSupported
        {
            get
            {
                HttpRequest request = HttpContext.Current.Request;
                bool flag = request.Browser.IsBrowser("IE") && (request.Browser.MajorVersion <= 6);
                string instance = (request.Headers["Accept-Encoding"] ?? "").ToLowerInvariant();
                return (!flag && instance.Contains(new string[] { "gzip", "deflate" }));
            }
        }
    }
}
