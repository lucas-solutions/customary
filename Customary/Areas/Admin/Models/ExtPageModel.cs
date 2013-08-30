using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Admin.Models
{
    public class ExtPageModel : Custom.Models.PageModel
    {
        public string ClassName
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