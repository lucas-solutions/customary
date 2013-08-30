using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Admin.Models
{
    using Custom.Models;

    public class ValidationViewModel : ViewModel
    {
        public string Presence
        {
            get;
            set;
        }

        public string Format
        {
            get;
            set;
        }

        public string Length
        {
            get;
            set;
        }

        public string Custom
        {
            get;
            set;
        }
    }
}