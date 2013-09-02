using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    public class MasterController : Controller
    {
        //
        // GET: /Master/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetJsonChildren()
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}
