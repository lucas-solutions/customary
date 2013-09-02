using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Reflection.Controllers
{
    using Custom.Models;

    public class ItemsController : ReflectionController
    {
        //
        // GET: /Reflection/Items/GetHtml
        [HttpGet]
        public ActionResult GetHtml(Item item)
        {
            return View(new ItemViewModel
            {
                Item = item
            });
        }

        //
        // GET: /Reflection/Items/GetHtmlWidget
        [HttpGet]
        public ActionResult GetHtmlWidget(Item item)
        {
            return View(new ItemViewModel
            {
                Item = item
            });
        }

        //
        // GET: /Reflection/Items/GetJson
        [HttpGet]
        public JsonResult GetJson(Item item)
        {
            return Json(new ItemViewModel
            {
                Item = item
            });
        }
    }
}
