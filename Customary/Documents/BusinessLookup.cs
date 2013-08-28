using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Documents
{
    public class BusinessLookup
    {
        private readonly Stack<string> _path;
        private readonly Stack<BusinessSegment> _result;

        public BusinessLookup(Uri url)
            : base()
        {
            var origin = url.Host;
            var segments = url.LocalPath.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();

            _path = new Stack<string>(segments);
            _result = new Stack<BusinessSegment>();
        }

        public Stack<string> Path
        {
            get { return _path; }
        }

        public Stack<BusinessSegment> Result
        {
            get { return _result; }
        }
    }
}