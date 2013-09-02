using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Models;

    public class ExtController : Controller
    {
        public ContentResult Custom()
        {
            var reflection = new UriReflection(null);

            return Content("", "");
        }

        public ContentResult Metadata()
        {
            return Content("", "");
        }
    }
}
