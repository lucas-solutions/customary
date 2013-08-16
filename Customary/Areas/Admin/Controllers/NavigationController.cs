using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Admin.Controllers
{
    public class NavigationController : Controller
    {
        //
        // GET: /Admin/Navigation/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/Navigation/Domain

        public ActionResult Domain(string id)
        {
            return View();
        }

        //
        // GET: /Admin/Navigation/Segment

        public ActionResult Segment(string id)
        {
            return View();
        }
    }
}
