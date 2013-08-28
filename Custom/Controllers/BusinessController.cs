using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    public class BusinessController : Controller
    {
        // returns business objects or processes them
        //
        // GET: /Business/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }
    }
}
