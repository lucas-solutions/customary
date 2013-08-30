using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Admin.Models
{
    using Custom.Models;

    public class TreeGridModel : ViewModel
    {
        public ComplexViewModel Model
        {
            get;
            set;
        }
    }
}