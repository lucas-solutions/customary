using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    public class PageController : Controller
    {
        // GET: {*path}

        public ActionResult Default(string path)
        {
            return View();
        }
    }
}
