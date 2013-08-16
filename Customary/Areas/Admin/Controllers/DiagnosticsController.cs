using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Admin.Controllers
{
    public class DiagnosticsController : Controller
    {
        //
        // GET: /Admin/Diagnostics/

        public ActionResult Index()
        {
            return View();
        }

    }
}
