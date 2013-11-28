using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Custom.Web.Mvc
{
    [Obsolete]
    public static class RequestExtensions
    {
        private static readonly Dictionary<string, AcceptTypes> SupportedTypes = new Dictionary<string, AcceptTypes>
        {
            { "application/json", AcceptTypes.Json },
            { "application/javascript", AcceptTypes.JavaScript },
            { "application/octet-stream", AcceptTypes.Binary },
            { "application/ogg", AcceptTypes.Ogg },
            { "application/pdf", AcceptTypes.Pdf },
            { "application/postscript", AcceptTypes.PostScript },
            { "application/rdf+xml", AcceptTypes.Resource },
            { "application/rss+xml", AcceptTypes.Rss },
            { "application/soap+xml", AcceptTypes.Soap },
            { "application/font-woff", AcceptTypes.Font },
            { "application/xhtml+xml", AcceptTypes.Html },
            { "application/xml", AcceptTypes.Xml },
            { "application/xml-dtd", AcceptTypes.Dtd },
            { "application/xop+xml", AcceptTypes.Xop },
            { "application/zip", AcceptTypes.Zip },
            { "application/gzip", AcceptTypes.Gzip },
            { "application/x-font-woff", AcceptTypes.Font },
            { "application/x-javascript", AcceptTypes.JavaScript },

            { "audio/basic" , AcceptTypes.Audio },
            { "audio/L24", AcceptTypes.L24 },
            { "audio/mp4", AcceptTypes.Mp4 },
            { "audio/mpeg", AcceptTypes.Mp3 },
            { "audio/ogg", AcceptTypes.Ogg },
            { "audio/vorbis", AcceptTypes.Vorbis },
            { "audio/vnd.rn-realaudio", AcceptTypes.RealAudio },
            { "audio/vnd.wave", AcceptTypes.Wav },
            { "audio/webm", AcceptTypes.WebM },

            { "image/gif", AcceptTypes.Gif },
            { "image/jpeg", AcceptTypes.Jpeg },
            { "image/pjpeg", AcceptTypes.Jpeg },
            { "image/png", AcceptTypes.Png },
            { "image/svg+xml", AcceptTypes.Svg },
            { "image/tiff", AcceptTypes.Tiff },
            { "image/vnd.microsoft.icon", AcceptTypes.Icon },

            { "multipart/mixed", AcceptTypes.Email },
            { "multipart/alternative", AcceptTypes.Email },
            { "multipart/related", AcceptTypes.Email },
            { "multipart/form-data", AcceptTypes.Webform },
            { "multipart/signed", AcceptTypes.Signed },
            { "multipart/encrypted", AcceptTypes.Encrypted },

            { "text/cmd", AcceptTypes.Command },
            { "text/css", AcceptTypes.Css },
            { "text/csv", AcceptTypes.Csv },
            { "text/html", AcceptTypes.Html },
            { "text/javascript", AcceptTypes.JavaScript },
            { "text/plain", AcceptTypes.Text },
            { "text/vcard", AcceptTypes.vCard },
            { "text/xml", AcceptTypes.Xml },

            { "video/mpeg", AcceptTypes.Mpeg },
            { "video/mp4", AcceptTypes.Mp4 },
            { "video/ogg", AcceptTypes.Ogg },
            { "video/quicktime", AcceptTypes.QuickTime },
            { "video/webm", AcceptTypes.WebM },
            { "video/x-matroska", AcceptTypes.Matroska },
            { "video/x-ms-wmv", AcceptTypes.Wmv },
            { "video/x-flv", AcceptTypes.Flv }
        };

        public static AcceptTypes Accept(this HttpRequest request)
        {
            AcceptTypes types = AcceptTypes.Any;

            foreach (var name in request.AcceptTypes)
            {
                AcceptTypes type;
                if (SupportedTypes.TryGetValue(name, out type))
                    types |= type;
            }

            return types;
        }

        public static AcceptTypes Accept(this HttpRequestBase request)
        {
            AcceptTypes types = AcceptTypes.Any;

            foreach (var name in request.AcceptTypes)
            {
                AcceptTypes type;
                if (SupportedTypes.TryGetValue(name, out type))
                    types |= type;
            }

            return types;
        }

        public static bool Test(this AcceptTypes types, AcceptTypes type)
        {
            return (types & type) == type;
        }
    }
}