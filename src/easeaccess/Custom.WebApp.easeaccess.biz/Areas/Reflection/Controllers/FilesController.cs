using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Reflection.Controllers
{
    using Custom.Models;

    public class FilesController : ReflectionController
    {
        //
        // GET: /Reflection/Files/GetHtml
        [HttpGet]
        public ActionResult GetHtml(File file)
        {
            return View(new FileViewModel
            {
                File = file
            });
        }

        //
        // GET: /Reflection/Files/GetHtmlWidget
        [HttpGet]
        public ActionResult GetHtmlWidget(File file)
        {
            return View(new FileViewModel
            {
                File = file
            });
        }

        //
        // GET: /Reflection/Files/GetJson
        [HttpGet]
        public JsonResult GetJson(File file)
        {
            return Json(new FileViewModel
            {
                File = file
            });
        }

        //
        // GET: /Reflection/Files/GetJsonNode
        [HttpGet]
        public JsonResult GetJsonNode(File file)
        {
            return Json(new FileViewModel
            {
                File = file
            });
        }
    }
}
