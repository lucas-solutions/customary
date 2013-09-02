using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Reflection.Controllers
{
    using Custom.Models;

    public class PropertiesController : ReflectionController
    {
        //
        // GET: /Reflection/Properties/GetHtml

        public ViewResult GetHtml(Column property)
        {
            return View(new ColumnViewModel
            {
                Property = property
            });
        }

        //
        // GET: /Reflection/Properties/GetHtmlWidget

        public PartialViewResult GetHtmlWidget(Column property)
        {
            return PartialView(new ColumnViewModel
            {
                Property = property
            });
        }

        //
        // GET: /Reflection/Properties/GetJson

        public JsonResult GetJson(Column property)
        {
            return Json(new ColumnViewModel
            {
                Property = property
            });
        }
    }
}
