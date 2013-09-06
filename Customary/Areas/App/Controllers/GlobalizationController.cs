using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    public class GlobalizationController : Controller
    {
        //
        // GET: /Globalization/Country

        public ActionResult Country()
        {
            return View();
        }

        //
        // GET: /Globalization/Currency

        public ActionResult Currency()
        {
            return View();
        }

        //
        // GET: /Globalization/Dashboard

        public ActionResult Dashboard()
        {
            return View();
        }

        //
        // GET: /Globalization/Language

        public ActionResult Language()
        {
            return View();
        }

        //
        // GET: /Globalization/Measure

        public ActionResult Measure()
        {
            return View();
        }

        //
        // GET: /Globalization/Region

        public ActionResult Region()
        {
            return View();
        }
    }
}
