using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Diagnostics.Controllers
{
    public class LoggerController : Controller
    {
        //
        // GET: /Diagnostics/Logger/

        public ActionResult Index()
        {
            return View();
        }

    }
}
