using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Controllers
{
    public class ControllerDescriptor
    {
        private static readonly Dictionary<string, string> SupportedTypes = new Dictionary<string, string>
        {
            { "application/json", "Json" },
            { "application/javascript", "JavaScript" },
            { "application/octet-stream", "Binary" },
            { "application/ogg", "Ogg" },
            { "application/pdf", "Pdf" },
            { "application/postscript", "PostScript" },
            { "application/rdf+xml", "Resource" },
            { "application/rss+xml", "Rss" },
            { "application/soap+xml", "Soap" },
            { "application/font-woff", "Font" },
            { "application/xhtml+xml", "Html" },
            { "application/xml", "Xml" },
            { "application/xml-dtd", "Dtd" },
            { "application/xop+xml", "Xop" },
            { "application/zip", "Zip" },
            { "application/gzip", "Gzip" },
            { "application/x-font-woff", "Font" },
            { "application/x-javascript", "JavaScript" },

            { "audio/basic" , "Audio" },
            { "audio/L24", "L24" },
            { "audio/mp4", "Mp4" },
            { "audio/mpeg", "Mp3" },
            { "audio/ogg", "Ogg" },
            { "audio/vorbis", "Vorbis" },
            { "audio/vnd.rn-realaudio", "RealAudio" },
            { "audio/vnd.wave", "Wav" },
            { "audio/webm", "WebM" },

            { "image/gif", "Gif" },
            { "image/jpeg", "Jpeg" },
            { "image/pjpeg", "Jpeg" },
            { "image/png", "Png" },
            { "image/svg+xml", "Svg" },
            { "image/tiff", "Tiff" },
            { "image/vnd.microsoft.icon", "Icon" },

            { "multipart/mixed", "Email" },
            { "multipart/alternative", "Email" },
            { "multipart/related", "Email" },
            { "multipart/form-data", "Webform" },
            { "multipart/signed", "Signed" },
            { "multipart/encrypted", "Encrypted" },

            { "text/cmd", "Command" },
            { "text/css", "Css" },
            { "text/csv", "Csv" },
            { "text/html", "Html" },
            { "text/javascript", "JavaScript" },
            { "text/plain", "Text" },
            { "text/vcard", "vCard" },
            { "text/xml", "Xml" },

            { "video/mpeg", "Mpeg" },
            { "video/mp4", "Mp4" },
            { "video/ogg","Ogg" },
            { "video/quicktime", "QuickTime" },
            { "video/webm", "WebM" },
            { "video/x-matroska", "Matroska" },
            { "video/x-ms-wmv", "Wmv" },
            { "video/x-flv", "Flv" }
        };

        private static string ResponseType(string[] acceptTypes)
        {
            foreach (var mime in acceptTypes)
            {
                string type;
                if (SupportedTypes.TryGetValue(mime, out type))
                    return type;
            }

            return "Html";
        }

        private readonly RequestContext _requestContext;
        private string _controllerName;
        private Type _controllerType;
        private string _httpMethod;
        private string _dataType;

        public ControllerDescriptor(RequestContext requestContext, string controllerName)
        {
            _requestContext = requestContext;
            _controllerName = controllerName;

            _controllerType = typeof(HomeController);
            _controllerName = "Home";

            _dataType = ResponseType(requestContext.HttpContext.Request.AcceptTypes);
            _httpMethod = requestContext.HttpContext.Request.HttpMethod.PascalCase();

            var lookup = Documents.Business.Lookup(requestContext.HttpContext.Request.Url);

            if (lookup != null)
            {
                _requestContext.RouteData.Values["controller"] = _controllerName;
                _requestContext.RouteData.Values["action"] = "Default";
            }

            _requestContext.RouteData.Values["controller"] = _controllerName;
            _requestContext.RouteData.Values["action"] = "Default";
        }

        public string ControllerName
        {
            get { return _controllerName; }
        }

        public Type ControllerType
        {
            get { return _controllerType; }
        }

        public RequestContext RequestContext
        {
            get { return _requestContext; }
        }
    }
}