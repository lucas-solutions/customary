using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Documents
{
    public class Lookup
    {
        const string Apps = @"Apps";
        const string Enums = @"Enums";
        const string Files = @"Files";
        const string Forms = @"Forms";
        const string Grids = @"Grids";
        const string Models = @"Models";
        const string Notes = @"Notes";
        const string Pages = @"Pages";
        const string Reports = @"Reports";
        const string Screens = @"Screens";

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

        private readonly HttpContext _context;
        private string _httpMethod;
        private string _dataType;
        private readonly Stack<string> _path;
        private readonly LookupResult _result;
        private readonly string[] _segments;

        public Lookup(HttpContext context)
            : base()
        {
            _context = context;
            _dataType = ResponseType(context.Request.AcceptTypes);
            _httpMethod = context.Request.HttpMethod.PascalCase();

            var origin = _context.Request.Url.Host;
            var segments = _context.Request.Url.LocalPath.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();

            _path = new Stack<string>(segments);

            var master = new Master();

            _result = master.Lookup(this);
            _segments = _path.ToArray();
        }

        public HttpContext Context
        {
            get { return _context; }
        }

        public string DataType
        {
            get { return _dataType; }
        }

        public string HttpMethod
        {
            get { return _httpMethod; }
        }

        public Stack<string> Path
        {
            get { return _path; }
        }

        public HttpRequest Request
        {
            get { return _context.Request; }
        }

        public LookupResult Result
        {
            get { return _result; }
        }
    }
}
