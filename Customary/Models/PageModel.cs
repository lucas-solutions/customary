using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    using Custom.Presentation;

    public class PageModel : ViewModel
    {
        public string Title
        {
            get;
            set;
        }

        public string Main
        {
            get;
            set;
        }

        public PageFramework Framework
        {
            get;
            set;
        }

        public PageTheme Theme
        {
            get;
            set;
        }
    }
}