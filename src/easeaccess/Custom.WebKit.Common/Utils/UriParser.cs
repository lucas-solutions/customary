using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Utils
{
    public static class UriParser
    {
        public static Uri Parse(string address)
        {
            Uri uri;
            if (Uri.TryCreate(address, UriKind.Absolute, out uri))
            {
            }
            return uri;
        }
    }
}
