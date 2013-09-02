using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Reflection.Controllers
{
    using Custom.Models;
    using Custom.Repositories;

    public class ApplicationsController : ReflectionController
    {
        //
        // GET: /Reflection/Applications/GetHtml
        [HttpGet]
        public ViewResult GetHtml(App application)
        {
            return View("Display", new ApplicationViewModel
            {
                Application = application
            });
        }

        //
        // GET: /Reflection/Applications/GetHtmlWidget
        [HttpGet]
        public PartialViewResult GetHtmlWidget(App application)
        {   
            return PartialView("Display", new ApplicationViewModel
            {
                Application = application
            });
        }

        //
        // GET: /Reflection/Applications/GetJson
        [HttpGet]
        public JsonResult GetJson(App application)
        {
            return Json(new ApplicationViewModel
            {
                Application = application
            });
        }

        //
        // GET: /Reflection/Applications/GetXml
        [HttpGet]
        public ActionResult GetXml(App application)
        {
            return Json(new ApplicationViewModel
            {
                Application = application
            });
        }
    }
}
