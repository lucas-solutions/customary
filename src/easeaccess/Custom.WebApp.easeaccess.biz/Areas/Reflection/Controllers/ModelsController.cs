using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Reflection.Controllers
{
    using Custom.Models;

    public class ModelsController : ReflectionController
    {
        //
        // GET: /Reflection/Models/GetHtml
        [HttpGet]
        public ViewResult GetHtml(Grid model)
        {
            return View("Display", new GridViewModel
            {
                Grid = model
            });
        }

        //
        // GET: /Reflection/Models/GetHtmlWidget
        [HttpGet]
        public PartialViewResult GetHtmlWidget(Grid model)
        {
            return PartialView("Display", new GridViewModel
            {
                Grid = model
            });
        }

        //
        // GET: /Reflection/Models/GetJson
        [HttpGet]
        public JsonResult GetJson(Grid model)
        {
            return Json(new GridViewModel
            {
                Grid = model
            });
        }

        //
        // GET: /Reflection/Models/GetJsonNode
        [HttpGet]
        public JsonResult GetJsonNode(Grid model)
        {
            return Json(new GridViewModel
            {
                Grid = model
            });
        }

        //
        // GET: /Reflection/Models/GetXml
        [HttpGet]
        public ActionResult GetXml(Grid model)
        {
            return Json(new GridViewModel
            {
                Grid = model
            });
        }

        #region - Properties -

        //
        // GET: /Reflection/Models/GetPropertiesHtml
        [HttpGet]
        public ViewResult GetPropertiesHtml(Grid model)
        {
            return View("DisplayProperties", new GridViewModel
            {
                Grid = model
            });
        }

        //
        // GET: /Reflection/Models/GetPropertiesHtmlWidget
        [HttpGet]
        public PartialViewResult GetPropertiesHtmlWidget(Grid model)
        {
            return PartialView("DisplayProperties", new GridViewModel
            {
                Grid = model
            });
        }

        #endregion - Properties -

        #region - Records -

        //
        // GET: /Reflection/Models/GetRecordsHtml
        [HttpGet]
        public ViewResult GetRecordsHtml(Grid model)
        {
            return View("DisplayRecords", new GridViewModel
            {
                Grid = model
            });
        }

        //
        // GET: /Reflection/Models/GetRecordsHtmlWidget
        [HttpGet]
        public PartialViewResult GetRecordsHtmlWidget(Grid model)
        {
            return PartialView("DisplayRecords", new GridViewModel
            {
                Grid = model
            });
        }

        #endregion - Records -
    }
}
