using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Office.Controllers
{
    public class EvernoteController : Controller
    {
        //
        // GET: /Office/Evernote/

        public ActionResult Index()
        {
            return View();
        }

        private ActionResult SignIn()
        {
            return Json(null);
        }
    }
}
