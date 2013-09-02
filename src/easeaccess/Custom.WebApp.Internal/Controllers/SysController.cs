using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    public class SysController : Controller
    {
        //
        // GET: /Sys/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetJsonApps()
        {
            return Json(null);
        }

        public JsonResult GetJsonDropboxAccounts()
        {
            return Json(null);
        }

        public JsonResult GetJsonDropboxFolders()
        {
            return Json(null);
        }

        public JsonResult GetJsonDropboxFiles()
        {
            return Json(null);
        }

        public JsonResult GetJsonEvernoteAccounts()
        {
            return Json(null);
        }

        public JsonResult GetJsonEvernoteNotebooks()
        {
            return Json(null);
        }

        public JsonResult GetJsonEvernoteNotes()
        {
            return Json(null);
        }

        public JsonResult GetJsonServers()
        {
            return Json(null);
        }

        public JsonResult GetJsonTables()
        {
            return Json(null);
        }

        public JsonResult GetJsonTexts()
        {
            return Json(null);
        }
    }
}
