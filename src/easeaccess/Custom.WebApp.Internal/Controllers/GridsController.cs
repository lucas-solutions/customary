using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Models;
    using Custom.Processes;

    public class GridsController : ReflectionController
    {
        //
        // GET: /Reflection/Grids/GetHtml
        [HttpGet]
        public ViewResult GetHtml(Grid model)
        {
            return View("Display", new GridViewModel
            {
                Grid = model
            });
        }

        //
        // GET: /Reflection/Grids/GetHtmlWidget
        [HttpGet]
        public PartialViewResult GetHtmlWidget(Grid model)
        {
            return PartialView("Display", new GridViewModel
            {
                Grid = model
            });
        }

        //
        // GET: /Reflection/Grids/GetJson
        [HttpGet]
        public JsonResult GetJson(Grid grid)
        {
            return Json(new Node
            {
                name = grid.Name,
                text = grid.Name,
                type = "grid",
                children = grid.Children()
            }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Grids/GetJsonChildren
        [HttpGet]
        public JsonResult GetJsonChildren(Grid grid)
        {
            return Json(grid.Children(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Grids/GetXml
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
        // GET: /Reflection/Grids/GetPropertiesHtml
        [HttpGet]
        public ViewResult GetPropertiesHtml(Grid model)
        {
            return View("DisplayProperties", new GridViewModel
            {
                Grid = model
            });
        }

        //
        // GET: /Reflection/Grids/GetPropertiesHtmlWidget
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
        // GET: /Reflection/Grids/GetRecordsHtml
        [HttpGet]
        public ViewResult GetRecordsHtml(Grid model)
        {
            return View("DisplayRecords", new GridViewModel
            {
                Grid = model
            });
        }

        //
        // GET: /Reflection/Grids/GetRecordsHtmlWidget
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
