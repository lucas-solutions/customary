using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Customer.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Customer/Profile/

        public ActionResult Index()
        {
            return View();
        }

    }
}
