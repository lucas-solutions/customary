using System;
using System.Linq;

namespace Custom.Data.Serialization
{
    /// <summary>
    /// http://en.wikipedia.org/wiki/MIME_type
    /// </summary>
    public class StreamFormat : IEquatable<StreamFormat>
    {
        private string _name;
        private string[] _alias;

        public StreamFormat(string mimeType)
        {
            if (string.IsNullOrEmpty(mimeType))
                throw new ArgumentException("Argument Empty String", "name");

            _name = mimeType;
        }

        private StreamFormat(string name, string[] alias)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Argument Empty String", "name");

            _name = name;
            _alias = alias;
        }

        public bool Equals(StreamFormat other)
        {
            if (other == null)
                return false;

            if (object.ReferenceEquals(this._name, other._name))
                return true;

            if (string.Compare(this._name, other._name, StringComparison.OrdinalIgnoreCase) == 0)
                return true;

            if (_alias == null)
                return false;

            if (_alias.Any(alias => string.Compare(alias, other._name, StringComparison.OrdinalIgnoreCase) == 0))
                return true;

            if (other._alias == null)
                return false;

            if (other._alias.Any(alias => string.Compare(alias, _name, StringComparison.OrdinalIgnoreCase) == 0))
                return true;

            return false;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as StreamFormat);
        }

        public override int GetHashCode()
        {
            return this._name.ToUpperInvariant().GetHashCode();
        }

        public static bool operator ==(StreamFormat left, StreamFormat right)
        {
            if (object.Equals(left, null))
                return object.Equals(right, null);

            if (object.Equals(right, null))
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(StreamFormat left, StreamFormat right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return this._name.ToString();
        }

        public static readonly StreamFormat Any = new StreamFormat("*/*");

        public static class Application
        {
            public static readonly StreamFormat Json = new StreamFormat("application/json");
            public static readonly StreamFormat JavaScript = new StreamFormat("application/javascript", new [] { "application/x-javascript", "text/javascript" });
            public static readonly StreamFormat Binary = new StreamFormat("application/octet-stream");
            public static readonly StreamFormat Ogg = new StreamFormat("application/ogg");
            public static readonly StreamFormat Pdf = new StreamFormat("application/pdf");
            public static readonly StreamFormat PostScript = new StreamFormat("application/postscript");
            public static readonly StreamFormat Resource = new StreamFormat("application/rdf+xml");
            public static readonly StreamFormat Rss = new StreamFormat("application/rss+xml");
            public static readonly StreamFormat Soap = new StreamFormat("application/soap+xml");
            public static readonly StreamFormat Font = new StreamFormat("application/font-woff", new [] { "application/x-font-woff" });
            public static readonly StreamFormat Html = new StreamFormat("application/xhtml+xml", new [] { "text/html" });
            public static readonly StreamFormat Xml = new StreamFormat("application/xml");
            public static readonly StreamFormat Dtd = new StreamFormat("application/xml");
            public static readonly StreamFormat Xop = new StreamFormat("application/xop+xml");
            public static readonly StreamFormat Zip = new StreamFormat("application/zip");
            public static readonly StreamFormat Gzip = new StreamFormat("application/gzip");
        }

        public static class Audio
        {
            public static readonly StreamFormat Basic = new StreamFormat("audio/basic");
            public static readonly StreamFormat L24 = new StreamFormat("audio/L24");
            public static readonly StreamFormat Mp4 = new StreamFormat("audio/mp4");
            public static readonly StreamFormat Mp3 = new StreamFormat("audio/mpeg");
            public static readonly StreamFormat Ogg = new StreamFormat("audio/ogg");
            public static readonly StreamFormat Vorbis = new StreamFormat("audio/vorbis");
            public static readonly StreamFormat RealAudio = new StreamFormat("audio/vnd.rn-realaudio");
            public static readonly StreamFormat Wav = new StreamFormat("audio/vnd.wave");
            public static readonly StreamFormat WebM = new StreamFormat("audio/webm");
        }

        public static class Image
        {
            public static readonly StreamFormat Gif = new StreamFormat("image/gif");
            public static readonly StreamFormat Jpeg = new StreamFormat("image/jpeg", new [] { "image/pjpeg" });
            public static readonly StreamFormat Png = new StreamFormat("image/png");
            public static readonly StreamFormat Svg = new StreamFormat("image/svg+xml");
            public static readonly StreamFormat Tiff = new StreamFormat("image/tiff");
            public static readonly StreamFormat Icon = new StreamFormat("image/vnd.microsoft.icon");
        }

        public static class Message
        {
            /// <summary>
            /// Defined in RFC 2616
            /// </summary>
            public static readonly StreamFormat Http = new StreamFormat("message/http");

            /// <summary>
            /// IMDN Instant Message Disposition Notification; Defined in RFC 5438
            /// </summary>
            public static readonly StreamFormat Imdn = new StreamFormat("message/imdn+xml");

            /// <summary>
            /// Email; Defined in RFC 2045 and RFC 2046
            /// </summary>
            public static readonly StreamFormat Email = new StreamFormat("message/partial", new [] { "message/rfc822:" });

            /// <summary>
            /// Email; EML files, MIME files, MHT files, MHTML files; Defined in RFC 2045 and RFC 2046
            /// </summary>
            public static readonly StreamFormat Rfc822 = new StreamFormat("message/rfc822", new[] { "message/partial" });
        }

        public static class Multipart
        {
            public static readonly StreamFormat Email = new StreamFormat("multipart/mixed", new [] { "multipart/alternative", "multipart/related" });
            public static readonly StreamFormat Webform = new StreamFormat("multipart/form-data");
            public static readonly StreamFormat Signed = new StreamFormat("multipart/signed");
            public static readonly StreamFormat Encrypted = new StreamFormat("multipart/encrypted");
        }

        public static class Text
        {
            public static readonly StreamFormat Command = new StreamFormat("text/cmd");
            public static readonly StreamFormat Css = new StreamFormat("text/css");
            public static readonly StreamFormat Csv = new StreamFormat("text/csv");
            public static readonly StreamFormat Html = new StreamFormat("text/html", new [] { "application/xhtml+xml" });
            public static readonly StreamFormat JavaScript = new StreamFormat("text/javascript", new [] { "application/javascript", "application/x-javascript" });
            public static readonly StreamFormat Plain = new StreamFormat("text/plain");
            public static readonly StreamFormat ContactInformation = new StreamFormat("text/vcard");
            public static readonly StreamFormat Xml = new StreamFormat("text/xml");
        }

        public static class Video
        {
            public static readonly StreamFormat Mpeg = new StreamFormat("video/mpeg");
            public static readonly StreamFormat Mp4 = new StreamFormat("video/mp4");
            public static readonly StreamFormat Ogg = new StreamFormat("video/ogg");
            public static readonly StreamFormat QuickTime = new StreamFormat("video/quicktime");
            public static readonly StreamFormat WebM = new StreamFormat("video/webm");
            public static readonly StreamFormat Matroska = new StreamFormat("video/x-matroska");
            public static readonly StreamFormat Wmv = new StreamFormat("video/x-ms-wmv");
            public static readonly StreamFormat Flv = new StreamFormat("video/x-flv");
        }
    }
}
