using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Models;
    using Custom.Processes;
    using Custom.Repositories;
    using Custom.Results;

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
            return Json(new Node
            {
                leaf = true,
                name = file.Name,
                raw = file,
                text = file.Name,
                type = "File"
            }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Files/GetJsonChildren
        [HttpGet]
        public JsonResult GetJsonChildren(File file)
        {
            return Json(new FileViewModel
            {
                File = file
            });
        }
    }
}
