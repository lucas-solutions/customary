using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Routing;

namespace Custom.Web
{
    using Custom.Data.Serialization;

    public class RequestDescriptor
    {
        private static readonly Dictionary<string, StreamFormat> SupportedTypes = new Dictionary<string, StreamFormat>
        {
            { "application/json", StreamFormat.Application.Json },
            { "application/javascript", StreamFormat.Application.JavaScript },
            { "application/octet-stream", StreamFormat.Application.Binary },
            { "application/ogg", StreamFormat.Application.Ogg },
            { "application/pdf", StreamFormat.Application.Pdf },
            { "application/postscript", StreamFormat.Application.PostScript },
            { "application/rdf+xml", StreamFormat.Application.Resource },
            { "application/rss+xml", StreamFormat.Application.Rss },
            { "application/soap+xml", StreamFormat.Application.Soap },
            { "application/font-woff", StreamFormat.Application.Font },
            { "application/xhtml+xml", StreamFormat.Application.Html },
            { "application/xml", StreamFormat.Application.Xml },
            { "application/xml-dtd", StreamFormat.Application.Dtd },
            { "application/xop+xml", StreamFormat.Application.Xop },
            { "application/zip", StreamFormat.Application.Zip },
            { "application/gzip", StreamFormat.Application.Gzip },
            { "application/x-font-woff", StreamFormat.Application.Font },
            { "application/x-javascript", StreamFormat.Application.JavaScript },

            { "audio/basic" , StreamFormat.Audio.Basic },
            { "audio/L24", StreamFormat.Audio.L24 },
            { "audio/mp4", StreamFormat.Audio.Mp4 },
            { "audio/mpeg", StreamFormat.Audio.Mp3 },
            { "audio/ogg", StreamFormat.Audio.Ogg },
            { "audio/vorbis", StreamFormat.Audio.Vorbis },
            { "audio/vnd.rn-realaudio", StreamFormat.Audio.RealAudio },
            { "audio/vnd.wave", StreamFormat.Audio.Wav },
            { "audio/webm", StreamFormat.Audio.WebM },

            { "image/gif", StreamFormat.Image.Gif },
            { "image/jpeg", StreamFormat.Image.Jpeg },
            { "image/pjpeg", StreamFormat.Image.Jpeg },
            { "image/png", StreamFormat.Image.Png },
            { "image/svg+xml", StreamFormat.Image.Svg },
            { "image/tiff", StreamFormat.Image.Tiff },
            { "image/vnd.microsoft.icon", StreamFormat.Image.Icon },

            { "multipart/mixed", StreamFormat.Multipart.Email },
            { "multipart/alternative", StreamFormat.Multipart.Email },
            { "multipart/related", StreamFormat.Multipart.Email },
            { "multipart/form-data", StreamFormat.Multipart.Webform },
            { "multipart/signed", StreamFormat.Multipart.Signed },
            { "multipart/encrypted", StreamFormat.Multipart.Encrypted },

            { "text/cmd", StreamFormat.Text.Command },
            { "text/css", StreamFormat.Text.Css },
            { "text/csv", StreamFormat.Text.Csv },
            { "text/html", StreamFormat.Text.Html },
            { "text/javascript", StreamFormat.Text.JavaScript },
            { "text/plain", StreamFormat.Text.Plain },
            { "text/vcard", StreamFormat.Text.ContactInformation },
            { "text/xml", StreamFormat.Text.Xml },

            { "video/mpeg", StreamFormat.Video.Mpeg },
            { "video/mp4", StreamFormat.Video.Mp4 },
            { "video/ogg", StreamFormat.Video.Ogg },
            { "video/quicktime", StreamFormat.Video.QuickTime },
            { "video/webm", StreamFormat.Video.WebM },
            { "video/x-matroska", StreamFormat.Video.Matroska },
            { "video/x-ms-wmv", StreamFormat.Video.Wmv },
            { "video/x-flv", StreamFormat.Video.Flv }
        };

        private static StreamFormat ParseRequestFormat(string contentType)
        {
            StreamFormat type;
            if (SupportedTypes.TryGetValue(contentType, out type))
                return type;

            return StreamFormat.Text.Html;
        }

        private static StreamFormat ParseResponseFormat(string[] acceptTypes)
        {
            foreach (var acceptType in acceptTypes)
            {
                StreamFormat type;
                if (SupportedTypes.TryGetValue(acceptType, out type))
                    return type;
            }

            return StreamFormat.Text.Html;
        }

        private readonly RequestContext _requestContext;
        private string _controllerName;
        private Type _controllerType;
        private HttpMethod _httpMethod;
        private StreamFormat _requestFormat;
        private StreamFormat _responseFormat;
        private string _action;

        public RequestDescriptor(RequestContext requestContext, string controllerName)
        {
            _requestContext = requestContext;
            _controllerName = controllerName;

            _requestFormat = ParseRequestFormat(requestContext.HttpContext.Request.ContentType);
            _responseFormat = ParseResponseFormat(requestContext.HttpContext.Request.AcceptTypes);
            _httpMethod = new HttpMethod(requestContext.HttpContext.Request.HttpMethod);

            Initialize();
        }

        public string ControllerName
        {
            get { return _controllerName; }
            protected set { _controllerName = value; }
        }

        public string Action
        {
            get { return _action ?? "Index"; }
            protected set { _action = value; }
        }

        public string Area
        {
            get;
            protected set;
        }

        public StreamFormat RequestFormat
        {
            get { return _requestFormat; }
        }

        public Type ControllerType
        {
            get { return _controllerType; }
            protected set { _controllerType = value; }
        }

        public RequestContext RequestContext
        {
            get { return _requestContext; }
        }

        public StreamFormat ResponseFormat
        {
            get { return _responseFormat; }
        }

        protected virtual void Initialize()
        {
        }
    }
}