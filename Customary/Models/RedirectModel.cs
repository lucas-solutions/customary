using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class RedirectModel
    {
        public int SessionID
        {
            get;
            set;
        }

        public int HitCount
        {
            get;
            set;
        }

        public string Param
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public string OriginalUrl
        {
            get;
            set;
        }

        public NameValueCollection QueryString
        {
            get;
            set;
        }
    }
}