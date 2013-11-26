using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Customer.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /Customer/User/

        public ActionResult Index()
        {
            return View();
        }

    }
}
