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

    public class FieldsController : ReflectionController
    {
        //
        // GET: /Reflection/Fields/GetHtml
        [HttpGet]
        public ActionResult GetHtml(Field field)
        {
            return View(new FieldViewModel
            {
                Field = field
            });
        }

        //
        // GET: /Reflection/Fields/GetHtmlWidget

        public ActionResult GetHtmlWidget(Field field)
        {
            return View(new FieldViewModel
            {
                Field = field
            });
        }

        //
        // GET: /Reflection/Fields/GetJson
        [HttpGet]
        public JsonResult GetJson(Field field)
        {
            return Json(new Node
            {
                leaf = true,
                name = field.Name,
                raw = field,
                text = field.Name,
                type = "Field",
                children = field.Children()
            }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Fields/GetJsonChildren
        [HttpGet]
        public JsonResult GetJsonChildren(Field field)
        {
            return Json(field.Children(), JsonRequestBehavior.AllowGet);
        }
    }
}
