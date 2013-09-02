using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Extensions;
    using Custom.Models;
    using Custom.Processes;
    using Custom.Results;

    public class AreasControllerBase : ReflectionController
    {
        #region - REST -

        //
        // DELETE: /Reflection/Areas/DeleteJson
        [HttpDelete]
        public JsonResult DeleteJson(Area area)
        {
            var value = (JsonObject)Request.InputStream;
            return Json(new { success = false, message = "Testing failure on delete " + value.ToString() });
        }

        //
        // POST: /Reflection/Areas/PostJson
        [HttpPost]
        public JsonResult PostJson(Area area)
        {
            var value = (JsonObject)Request.InputStream;
            return Json(new { success = false, message = "Testing failure on update " + value.ToString() });
        }

        //
        // PUT: /Reflection/Areas/PutJson
        [HttpPut]
        public JsonResult PutJson(Area area)
        {
            var value = (JsonObject)Request.InputStream;
            return Json(new { success = false, message = "Testing failure on insert " + value.ToString() });
        }

        #endregion - REST -

        #region - Ajax -

        //
        // POST: /Reflection/PostJsonDelete
        [HttpPost]
        public JsonResult PostJsonDelete(Area area)
        {
            return Json(null);
        }

        //
        // POST: /Reflection/PostJsonUpdate
        [HttpPost]
        public JsonResult PostJsonUpdate(Area area)
        {
            area.Update(Request.InputStream);
            var value = (JsonObject)Request.InputStream;
            return Json(new { success = false, message = "Testing failure on update " + value.ToString() });
        }

        //
        // POST: /Reflection/PostJsonCreate
        [HttpPost]
        public JsonResult PutJsonCreate(Area area)
        {
            area.Insert(Request.InputStream);
            var value = (JsonObject)Request.InputStream;
            return Json(new { success = false, message = "Testing failure on create " + value.ToString() });
        }

        #endregion - Ajax -

        #region - JsonP -

        //
        // POST: /Reflection/Areas/DeleteJsonDelete
        [HttpPost]
        public JsonResult PostJsonpDelete(Area area)
        {
            area.Delete(Request.InputStream);
            JsonObject value = (JsonObject)Request.InputStream;
            return Json(new { success = false, message = "Testing failure on delete " + value.ToString() });
        }

        //
        // POST: /Reflection/Areas/PostJsonUpdate
        [HttpPost]
        public JsonResult PostJsonpUpdate(Area area)
        {
            area.Update(Request.InputStream);
            var value = (JsonObject)Request.InputStream;
            return Json(new { success = false, message = "Testing failure on update " + value.ToString() });
        }

        //
        // POST: /Reflection/Areas/PutJsonCreate
        [HttpPost]
        public JsonResult PutJsonpCreate(Area area)
        {
            var value = (JsonObject)Request.InputStream;
            return Json(new { success = false, message = "Testing failure on create " + value.ToString() });
        }

        #endregion - JsonP -

        #region - Areas -

        //
        // GET: /Reflection/Areas/GetAreasHtml
        [HttpGet]
        public ViewResult GetAreasHtml(Area area)
        {
            return View("DisplayAreas", new AreaViewModel
            {
                Area = area
            });
        }

        //
        // GET: /Reflection/Areas/GetAreasHtmlWidget
        [HttpGet]
        public PartialViewResult GetAreasHtmlWidget(Area area)
        {
            return PartialView("DisplayAreas", new AreaViewModel
            {
                Area = area
            });
        }

        //
        // GET: /Reflection/Areas/GetAreasJsonChildren
        [HttpGet]
        public JsonResult GetAreasJsonChildren(Area area)
        {
            return Json(area.AreasChildren(), JsonRequestBehavior.AllowGet);
        }

        #region - Areas Grid Store -

        //
        // DELETE: /Reflection/Areas/DeleteAreasJson
        [HttpDelete]
        public JsonResult DeleteAreasJson(Area area)
        {
            return Json(null);
        }

        //
        // GET: /Reflection/Areas/GetAreasJson
        [HttpGet]
        public ContentResult GetAreasJson(Area area, int? start, int? limit, int? page)
        {
            var json = area.AreasStore(start ?? 0, limit ?? UInt16.MaxValue);
            return Content(json, "application/json");
        }

        //
        // POST: /Reflection/Areas/PostAreasJson
        [HttpPost]
        public JsonResult PostAreasJson(Area area)
        {
            var response = area.Update(Request.InputStream);
            return Json(response);
        }

        //
        // POST: /Reflection/Areas/PostAreasJsonDelete
        [HttpPost]
        public JsonResult PostAreasJsonDelete(Area area)
        {
            return Json(null);
        }

        //
        // POST: /Reflection/Areas/PostAreasJsonUpdate
        [HttpPost]
        public JsonResult PostAreasJsonUpdate(Area area)
        {
            var response = area.Update(Request.InputStream);
            return Json(response);
        }

        //
        // POST: /Reflection/Areas/PostAreasJsonCreate
        [HttpPost]
        public JsonResult PostAreasJsonCreate(Area area)
        {
            var response = area.Insert(Request.InputStream);
            return Json(response);
        }

        //
        // PUT: /Reflection/Areas/GetAreasJson
        [HttpPut]
        public JsonResult PutAreasJson(Area area)
        {
            var response = area.Insert(Request.InputStream);
            return Json(response);
        }

        #endregion - Areas Grid Store -

        #endregion - Areas -

        #region - Files -

        //
        // GET: /Reflection/Areas/GetFilesHtml
        [HttpGet]
        public ViewResult GetFilesHtml(Area area)
        {
            return View("DisplayFiles", new AreaViewModel
            {
                Area = area
            });
        }

        //
        // GET: /Reflection/Areas/GetFilesHtmlWidget
        [HttpGet]
        public PartialViewResult GetFilesHtmlWidget(Area area)
        {
            return PartialView("DisplayFiles", new AreaViewModel
            {
                Area = area
            });
        }

        //
        // GET: /Reflection/Areas/GetFilesJson
        [HttpGet]
        public ContentResult GetFilesJson(Area area, int? start, int? limit, int? page)
        {
            return Content(area.AreasStore(start ?? 0, limit ?? UInt16.MaxValue), "application/json");
        }

        //
        // GET: /Reflection/Areas/GetFilesJsonChildren
        [HttpGet]
        public JsonResult GetFilesJsonChildren(Area area)
        {
            return Json(area.FilesChildren(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Areas/GetFilesJsonStore
        [HttpGet]
        public StoreResult GetFilesJsonStore(Area area, int? start, int? limit, int? page)
        {
            return new StoreResult(area.Files.Skip(start ?? 0).Take(limit ?? UInt16.MaxValue), area.Files.Count());
        }

        #endregion - Files -

        #region - Grids -

        //
        // GET: /Reflection/Areas/GetGridsHtml
        [HttpGet]
        public ViewResult GetGridsHtml(Area area)
        {
            return View("DisplayGrids", new AreaViewModel
            {
                Area = area
            });
        }

        //
        // GET: /Reflection/Areas/GetGridsHtmlWidget
        [HttpGet]
        public PartialViewResult GetGridsHtmlWidget(Area area)
        {
            return PartialView("DisplayGrids", new AreaViewModel
            {
                Area = area
            });
        }

        //
        // GET: /Reflection/Areas/GetGridsJson
        [HttpGet]
        public JsonResult GetGridsJson(Area area)
        {
            return Json(new Node
            {
                name = "Grids",
                text = "Grids",
                type = "grids",
                children = area.GridsChildren()
            }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Areas/GetGridsJsonChildren
        [HttpGet]
        public JsonResult GetGridsJsonChildren(Area area)
        {
            return Json(area.GridsChildren(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Areas/GetGridsJsonStore
        [HttpGet]
        public StoreResult GetGridsJsonStore(Area area, int? start, int? limit, int? page)
        {
            return new StoreResult(area.Grids.Skip(start ?? 0).Take(limit ?? UInt16.MaxValue), area.Grids.Count());
        }

        //
        // POST: /Reflection/Areas/PostGridsJsonDelete
        [HttpPost]
        public JsonResult PostGridsJsonDelete(Area area)
        {
            return Json(null);
        }

        #endregion - Grids -

        #region - Lists -

        //
        // GET: /Reflection/Areas/GetListsHtml
        [HttpGet]
        public ViewResult GetListsHtml(Area area)
        {
            return View("DisplayLists", new AreaViewModel
            {
                Area = area
            });
        }

        //
        // GET: /Reflection/Areas/GetListsHtmlWidget
        [HttpGet]
        public PartialViewResult GetListsHtmlWidget(Area area)
        {
            return PartialView("DisplayLists", new AreaViewModel
            {
                Area = area
            });
        }

        //
        // GET: /Reflection/Areas/GetListsJson
        [HttpGet]
        public JsonResult GetListsJson(Area area)
        {
            return Json(new Node
            {
                name = "Lists",
                text = "Lists",
                type = "lists",
                children = area.ListsChildren()
            }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Areas/GetListsJsonChildren
        [HttpGet]
        public JsonResult GetListsJsonChildren(Area area)
        {
            return Json(area.ListsChildren(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Areas/GetListsJsonStore
        [HttpGet]
        public StoreResult GetListsJsonStore(Area area, int? start, int? limit, int? page)
        {
            return new StoreResult(area.Lists.Skip(start ?? 0).Take(limit ?? UInt16.MaxValue), area.Lists.Count());
        }

        #endregion - Lists -

        #region - Notes -

        //
        // GET: /Reflection/Areas/GetNotesHtml
        [HttpGet]
        public ViewResult GetNotesHtml(Area area)
        {
            return View("DisplayNotes", new AreaViewModel
            {
                Area = area
            });
        }

        //
        // GET: /Reflection/Areas/GetNotesHtmlWidget
        [HttpGet]
        public PartialViewResult GetNotesHtmlWidget(Area area)
        {
            return PartialView("DisplayNotes", new AreaViewModel
            {
                Area = area
            });
        }

        //
        // GET: /Reflection/Areas/GetNotesJson
        [HttpGet]
        public JsonResult GetNotesJson(Area area)
        {
            return Json(new Node
            {
                name = "Notes",
                text = "Notes",
                type = "notes",
                children = area.NotesChildren()
            }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Areas/GetNotesJsonChildren
        [HttpGet]
        public JsonResult GetNotesJsonChildren(Area area)
        {
            return Json(area.NotesChildren(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Reflection/Areas/GetNotesJsonStore
        [HttpGet]
        public StoreResult GetNotesJsonStore(Area area, int? start, int? limit, int? page)
        {
            return new StoreResult(area.Notes.Skip(start ?? 0).Take(limit ?? UInt16.MaxValue), area.Notes.Count());
        }

        #endregion - Notes -
    }
}
