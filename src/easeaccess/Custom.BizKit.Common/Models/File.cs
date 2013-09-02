using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class File
    {
        private string _title;

        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Title
        {
            get { return _title ?? string.Empty; }
            set { _title = value; }
        }
    }
}