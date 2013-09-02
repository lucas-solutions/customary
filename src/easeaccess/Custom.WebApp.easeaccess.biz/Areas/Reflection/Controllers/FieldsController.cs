using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Reflection.Controllers
{
    using Custom.Models;

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
            return Json(new FieldViewModel
            {
                Field = field
            });
        }
    }
}
