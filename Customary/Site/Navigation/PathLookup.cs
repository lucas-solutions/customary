using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Navigation
{
    public class PathLookup
    {
        private readonly Stack<string> _path;
        private readonly Stack<PathDescriptor> _result;

        public PathLookup(Uri url)
            : base()
        {
            var origin = url.Host;
            var segments = url.LocalPath.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();

            _path = new Stack<string>(segments);
            _result = new Stack<PathDescriptor>();
        }

        public Stack<string> Path
        {
            get { return _path; }
        }

        public Stack<PathDescriptor> Result
        {
            get { return _result; }
        }
    }
}