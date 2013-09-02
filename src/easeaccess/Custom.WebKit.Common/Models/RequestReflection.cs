using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Custom.Models
{
    using Custom.Models;
    using Custom.Extensions;

    public class RequestReflection : UriReflection, IHttpHandler
    {
        private static readonly List<string> _ignores = new List<string>();

        public static void Ingnore(string path)
        {
            var segments = path.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var key = string.Concat(segments).ToLower();

            if (!_ignores.Any(o => key.StartsWith(o)))
                _ignores.Add(key);
        }

        private static string Key = "RequestReflection";

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

        public static implicit operator RequestReflection(HttpContext context)
        {
            var segments = context.Request.Url.LocalPath.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var key = string.Concat(segments).ToLower();

            if (_ignores.Any(o => key.StartsWith(o)))
                return null;

            var reflection = context.Items[Key] as RequestReflection;
            if (reflection == null)
            {
                reflection = new RequestReflection(context);
                context.Items[Key] = reflection;
            }
            return reflection;
        }

        public static implicit operator RequestReflection(HttpContextBase context)
        {
            var segments = context.Request.Url.LocalPath.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var key = string.Concat(segments).ToLower();

            if (_ignores.Any(o => key.StartsWith(o)))
                return null;

            var reflection = context.Items[Key] as RequestReflection;
            if (reflection == null)
            {
                reflection = new RequestReflection(context.Request);
                context.Items[Key] = reflection;
            }
            return reflection;
        }

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

        private string _mvcAction;
        private string _mvcArea;
        private string _mvcController = "Apps";
        private string _mvcId;
        private string _httpMethod;
        private string _dataType;
        private bool _redirected = false;
        private HttpContext _context;

        private RequestReflection(HttpContext context)
            : base(context.Request.Url)
        {
            _context = context;
            _dataType = ResponseType(context.Request.AcceptTypes);
            _httpMethod = context.Request.HttpMethod.PascalCase();
        }

        private RequestReflection(HttpRequestBase request)
            : base(request.Url)
        {
            _dataType = ResponseType(request.AcceptTypes);
            _httpMethod = request.HttpMethod.PascalCase();
        }

        public bool IsMatch
        {
            get { return _mvcController != null; }
        }

        public string RewritePath
        {
            get { return string.IsNullOrEmpty(_mvcId) ? string.Join("/", "~", _mvcArea, _mvcController, MvcAction) : string.Join("/", "~", _mvcArea, _mvcController, _mvcId, MvcAction); }
        }

        private string MvcAction
        {
            get { return _mvcAction ?? string.Concat(_httpMethod, Property, _dataType, string.Concat(Queue)); }
        }

        private string MvcArea
        {
            get { return _mvcArea; }
        }

        private string MvcController
        {
            get { return _mvcController; }
        }

        protected override int Match(Area area)
        {
            var weight = base.Match(area);

            if (weight.Equals(2) || weight.Equals(3))
                _mvcController = "Areas";

            return weight;
        }

        protected override int Match(Column column)
        {
            var weight = base.Match(column);

            if (weight.Equals(2) || weight.Equals(3))
                _mvcController = "Columns";

            return weight;
        }

        protected override int Match(Field field)
        {
            var weight = base.Match(field);

            if (weight.Equals(2) || weight.Equals(3))
                _mvcController = "Fields";

            return weight;
        }

        protected override int Match(File file)
        {
            var weight = base.Match(file);

            if (weight.Equals(2) || weight.Equals(3))
                _mvcController = "Files";

            return weight;
        }

        protected override int Match(Model form)
        {
            var weight = base.Match(form);

            if (weight.Equals(2) || weight.Equals(3))
                _mvcController = "Forms";

            return weight;
        }

        protected override int Match(Grid grid)
        {
            var weight = base.Match(grid);

            if (weight.Equals(2) || weight.Equals(3))
                _mvcController = "Grids";

            return weight;
        }

        protected override int Match(Item item)
        {
            var weight = base.Match(item);

            if (weight.Equals(2) || weight.Equals(3))
                _mvcController = "Items";

            return weight;
        }

        protected override int Match(List list)
        {
            var weight = base.Match(list);

            if (weight.Equals(2) || weight.Equals(3))
                _mvcController = "Lists";

            return weight;
        }

        protected override int Match(Note note)
        {
            var weight = base.Match(note);

            if (weight.Equals(2) || weight.Equals(3))
                _mvcController = "Notes";

            return weight;
        }

        public void Redirect()
        {
            if (!_redirected)
            {
                _redirected = true;
                _context.Response.Redirect(RewritePath);
            }
        }

        #region - IHttpHandler implementation -

        bool IHttpHandler.IsReusable
        {
            get { return false; }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        #endregion - IHttpHandler implementation -
    }
}
