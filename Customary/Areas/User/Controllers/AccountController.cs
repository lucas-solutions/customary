using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.User.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /User/Account/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /User/Account/GetStarted

        public ActionResult GetStarted()
        {
            return View();
        }

    }
}
