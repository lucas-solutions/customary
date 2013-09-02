using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Office.Controllers
{
    public class TwitterController : Controller
    {
        //
        // GET: /Office/Twitter/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Office/Twitter/SignIn

        public ViewResult SignIn()
        {
            return View();
        }

    }
}
