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

    public class ListsController : ReflectionController
    {
        //
        // GET: /Reflection/Lists/GetHtml
        [HttpGet]
        public ViewResult GetHtml(List list)
        {
            return View("Display", new ListViewModel
            {
                List = list
            });
        }

        //
        // GET: /Reflection/Lists/GetHtmlWidget
        [HttpGet]
        public PartialViewResult GetHtmlWidget(List list)
        {
            return PartialView("Display", new ListViewModel
            {
                List = list
            });
        }

        //
        // GET: /Reflection/Lists/GetJson
        [HttpGet]
        public JsonResult GetJson(List list)
        {
            return Json(new Node
            {
                name = list.Name,
                raw = list,
                text = list.Name,
                type = "List",
                children = list.Children()
            }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Lists/GetJsonChildren
        [HttpGet]
        public JsonResult GetJsonChildren(List list)
        {
            return Json(list.Children(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Lists/GetXml
        [HttpGet]
        public ActionResult GetXml(List list)
        {
            return Json(new ListViewModel
            {
                List = list
            });
        }

        #region - Items -

        //
        // GET: /Reflection/Lists/GetItemsHtml
        [HttpGet]
        public ViewResult GetItemsHtml(List list)
        {
            return View("DisplayItems", new ListViewModel
            {
                List = list
            });
        }

        //
        // GET: /Reflection/Lists/GetItemsHtmlWidget
        [HttpGet]
        public PartialViewResult GetItemsHtmlWidget(List list)
        {
            return PartialView("DisplayItems", new ListViewModel
            {
                List = list
            });
        }

        #endregion - Items -
    }
}
