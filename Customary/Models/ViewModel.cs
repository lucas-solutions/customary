using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class ViewModel
    {
        public string ClassName
        {
            get;
            set;
        }

        public string ComponentName
        {
            get;
            set;
        }

        public string Layout
        {
            get;
            set;
        }

        public IDictionary<string, object> Options
        {
            get;
            set;
        }

        public string PageTitle
        {
            get;
            set;
        }

        public string ViewName
        {
            get;
            set;
        }
    }
}