using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Models;

    public class FieldsController : Controller
    {
        //
        // GET: /Fields/

        public ActionResult Index()
        {
            return View();
        }

    }
}
