using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Reflection.Controllers
{
    using Custom.Models;
    using Custom.Transforms;

    public class AreasController : ReflectionController
    {
        //
        // GET: /Reflection/Areas/GetHtml
        [HttpGet]
        public ViewResult GetHtml(Area area)
        {
            return View("Display", new AreaViewModel
            {
                Area = area
            });
        }
        
        //
        // GET: /Reflection/Areas/GetJson
        [HttpGet]
        public JsonResult GetJson(Area area)
        {
            return null;
        }

        //
        // GET: /Reflection/Areas/GetJsonChildren
        [HttpGet]
        public JsonResult GetJsonChildren(Area area)
        {
            return Json(new[]
                {
                    new TreeNodeModel
                    {
                        path = "Files",
                        text = "Files",
                        type = "files"
                    },
                    new TreeNodeModel
                    {
                        path = "Lists",
                        text = "Lists",
                        type = "lists"
                    },
                    new TreeNodeModel
                    {
                        path = "Models",
                        text = "Models",
                        type = "models"
                    },
                    new TreeNodeModel
                    {
                        path = "Notes",
                        text = "Notes",
                        type = "notes"
                    }
                }.Union(area.Areas.Select(o => new TreeNodeModel
                {
                    name = o.Id,
                    path = "Nodes",
                    text = o.Id,
                    type = "area"
                })), JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Reflection/Areas/PostJsonCopyTo
        [HttpPost]
        public JsonResult PostJsonCopyTo(Area area)
        {
            return null;
        }

        //
        // POST: /Reflection/Areas/PostJsonCreate
        [HttpPost]
        public JsonResult PostJsonCreate(Area area)
        {
            return null;
        }

        //
        // POST: /Reflection/Areas/PostJsonDelete
        [HttpPost]
        public JsonResult PostJsonDelete(Area area)
        {
            return null;
        }

        //
        // POST: /Reflection/Areas/PostJsonMoveTo
        [HttpPost]
        public JsonResult PostJsonMoveTo(Area area)
        {
            return null;
        }

        //
        // GET: /Reflection/Areas/GetJsonNode
        [HttpGet]
        public JsonResult GetJsonNode(Area area)
        {
            return Json(area.Areas.Select(o => new TreeNodeModel
            {
                name = o.Id,
                path = "Nodes",
                text = o.Id,
                type = "area"
            }));
        }

        //
        // POST: /Reflection/Areas/PostJsonUpdate
        [HttpPost]
        public JsonResult PostJsonUpdate(Area area)
        {
            return null;
        }

/*Get {value} {format}
Post {value} {format} Inc { amount: ? }
Post {value} {format} Set { value: ? }
Post {value} {format} Unset { }*/


        #region - Areas -

        //
        // GET: /Reflection/Areas/GetAreasJson
        [HttpGet]
        public JsonResult GetAreasJson(Area area)
        {
            return CollectionJson(area.Areas, AreaTransforms.ToTreeNode);
        }

        //
        // POST: /Reflection/Areas/PostAreasJsonAdd
        [HttpPost]
        public JsonResult PostAreasJsonAdd(Area area)
        {
            return CollectionJsonAdd(area.Areas);
        }

        //
        // POST: /Reflection/Areas/PostAreasJsonClear
        [HttpPost]
        public JsonResult PostAreasJsonClear(Area area)
        {
            return CollectionJsonClear(area.Areas);
        }

        //
        // POST: /Reflection/Areas/PostAreasJsonContains
        [HttpPost]
        public JsonResult PostAreasJsonContains(Area area)
        {
            return CollectionJsonContains(area.Areas);
        }

        //
        // POST: /Reflection/Areas/PostAreasJsonCopyTo
        [HttpPost]
        public JsonResult PostAreasJsonCopyTo(Area area)
        {
            return CollectionJsonCopyTo(area.Areas);
        }

        //
        // POST: /Reflection/Areas/PostAreasJsonIndexOf
        [HttpPost]
        public JsonResult PostAreasJsonIndexOf(Area area)
        {
            return CollectionJsonIndexOf(area.Areas);
        }

        //
        // POST: /Reflection/Areas/PostAreasJsonInsert
        [HttpPost]
        public JsonResult PostAreasJsonInsert(Area area)
        {
            return CollectionJsonInsert(area.Areas);
        }

        //
        // POST: /Reflection/Areas/PostAreasJsonMoveTo
        [HttpPost]
        public JsonResult PostAreasJsonMoveTo(Area area)
        {
            return CollectionJsonMoveTo(area.Areas);
        }

        //
        // POST: /Reflection/Areas/PostAreasJsonRemove
        [HttpPost]
        public JsonResult PostAreasJsonRemove(Area area)
        {
            return CollectionJsonRemove(area.Areas, (Area o, string id) => { return o.Id == id; });
        }

        //
        // POST: /Reflection/Areas/PostAreasJsonRemoveAt
        [HttpPost]
        public JsonResult PostAreasJsonRemoveAt(Area area)
        {
            return CollectionJsonRemoveAt(area.Areas);
        }

        #endregion - Areas -

        #region - Files -

        //
        // GET: /Reflection/Files/GetFilesJson
        [HttpGet]
        public JsonResult GetFilesJson(Area area)
        {
            return CollectionJson(area.Files, null);
        }

        //
        // POST: /Reflection/Files/PostFilesJsonAdd
        [HttpPost]
        public JsonResult PostFilesJsonAdd(Area area)
        {
            return CollectionJsonAdd(area.Files);
        }

        //
        // POST: /Reflection/Files/PostFilesJsonClear
        [HttpPost]
        public JsonResult PostFilesJsonClear(Area area)
        {
            return CollectionJsonClear(area.Files);
        }

        //
        // POST: /Reflection/Files/PostFilesJsonContains
        [HttpPost]
        public JsonResult PostFilesJsonContains(Area area)
        {
            return CollectionJsonContains(area.Files);
        }

        //
        // POST: /Reflection/Files/PostFilesJsonCopyTo
        [HttpPost]
        public JsonResult PostFilesJsonCopyTo(Area area)
        {
            return CollectionJsonCopyTo(area.Files);
        }

        //
        // POST: /Reflection/Files/PostFilesJsonIndexOf
        [HttpPost]
        public JsonResult PostFilesJsonIndexOf(Area area)
        {
            return CollectionJsonIndexOf(area.Files);
        }

        //
        // POST: /Reflection/Files/PostFilesJsonInsert
        [HttpPost]
        public JsonResult PostFilesJsonInsert(Area area)
        {
            return CollectionJsonInsert(area.Files);
        }

        //
        // POST: /Reflection/Files/PostFilesJsonMoveTo
        [HttpPost]
        public JsonResult PostFilesJsonMoveTo(Area area)
        {
            return CollectionJsonMoveTo(area.Files);
        }

        //
        // POST: /Reflection/Files/PostFilesJsonRemove
        [HttpPost]
        public JsonResult PostFilesJsonRemove(Area area)
        {
            return CollectionJsonRemove(area.Files, (File o, string id) => { return o.Id == id; });
        }

        //
        // POST: /Reflection/Files/PostFilesJsonRemoveAt
        [HttpPost]
        public JsonResult PostFilesJsonRemoveAt(Area area)
        {
            return CollectionJsonRemoveAt(area.Files);
        }

        #endregion - Files -

        #region - Lists -

        //
        // GET: /Reflection/Lists/GetListsJson
        [HttpGet]
        public JsonResult GetListsJson(Area area)
        {
            return CollectionJson(area.Lists, null);
        }

        //
        // POST: /Reflection/Lists/PostListsJsonAdd
        [HttpPost]
        public JsonResult PostListsJsonAdd(Area area)
        {
            return CollectionJsonAdd(area.Lists);
        }

        //
        // POST: /Reflection/Lists/PostListsJsonClear
        [HttpPost]
        public JsonResult PostListsJsonClear(Area area)
        {
            return CollectionJsonClear(area.Lists);
        }

        //
        // POST: /Reflection/Lists/PostListsJsonContains
        [HttpPost]
        public JsonResult PostListsJsonContains(Area area)
        {
            return CollectionJsonContains(area.Lists);
        }

        //
        // POST: /Reflection/Lists/PostListsJsonCopyTo
        [HttpPost]
        public JsonResult PostListsJsonCopyTo(Area area)
        {
            return CollectionJsonCopyTo(area.Lists);
        }

        //
        // POST: /Reflection/Lists/PostListsJsonIndexOf
        [HttpPost]
        public JsonResult PostListsJsonIndexOf(Area area)
        {
            return CollectionJsonIndexOf(area.Lists);
        }

        //
        // POST: /Reflection/Lists/PostListsJsonInsert
        [HttpPost]
        public JsonResult PostListsJsonInsert(Area area)
        {
            return CollectionJsonInsert(area.Lists);
        }

        //
        // POST: /Reflection/Lists/PostListsJsonMoveTo
        [HttpPost]
        public JsonResult PostListsJsonMoveTo(Area area)
        {
            return CollectionJsonMoveTo(area.Lists);
        }

        //
        // POST: /Reflection/Lists/PostListsJsonRemove
        [HttpPost]
        public JsonResult PostListsJsonRemove(Area area)
        {
            return CollectionJsonRemove(area.Lists, (List o, string id) => { return o.Id == id; });
        }

        //
        // POST: /Reflection/Lists/PostListsJsonRemoveAt
        [HttpPost]
        public JsonResult PostListsJsonRemoveAt(Area area)
        {
            return CollectionJsonRemoveAt(area.Lists);
        }

        #endregion - Lists -

        #region - Grids -

        //
        // GET: /Reflection/Grids/GetGridsJson
        [HttpGet]
        public JsonResult GetGridsJson(Area area)
        {
            return CollectionJson(area.Grids, null);
        }

        //
        // POST: /Reflection/Grids/PostGridsJsonAdd
        [HttpPost]
        public JsonResult PostGridsJsonAdd(Area area)
        {
            return CollectionJsonAdd(area.Grids);
        }

        //
        // POST: /Reflection/Grids/PostGridsJsonClear
        [HttpPost]
        public JsonResult PostGridsJsonClear(Area area)
        {
            return CollectionJsonClear(area.Grids);
        }

        //
        // POST: /Reflection/Grids/PostGridsJsonContains
        [HttpPost]
        public JsonResult PostGridsJsonContains(Area area)
        {
            return CollectionJsonContains(area.Grids);
        }

        //
        // POST: /Reflection/Grids/PostGridsJsonCopyTo
        [HttpPost]
        public JsonResult PostGridsJsonCopyTo(Area area)
        {
            return CollectionJsonCopyTo(area.Grids);
        }

        //
        // POST: /Reflection/Grids/PostGridsJsonIndexOf
        [HttpPost]
        public JsonResult PostGridsJsonIndexOf(Area area)
        {
            return CollectionJsonIndexOf(area.Grids);
        }

        //
        // POST: /Reflection/Grids/PostGridsJsonInsert
        [HttpPost]
        public JsonResult PostGridsJsonInsert(Area area)
        {
            return CollectionJsonInsert(area.Grids);
        }

        //
        // POST: /Reflection/Grids/PostGridsJsonMoveTo
        [HttpPost]
        public JsonResult PostGridsJsonMoveTo(Area area)
        {
            return CollectionJsonMoveTo(area.Grids);
        }

        //
        // POST: /Reflection/Grids/PostGridsJsonRemove
        [HttpPost]
        public JsonResult PostGridsJsonRemove(Area area)
        {
            return CollectionJsonRemove(area.Grids, (Grid o, string id) => { return o.Id == id; });
        }

        //
        // POST: /Reflection/Grids/PostGridsJsonRemoveAt
        [HttpPost]
        public JsonResult PostGridsJsonRemoveAt(Area area)
        {
            return CollectionJsonRemoveAt(area.Grids);
        }

        #endregion - Grids -

        #region - Notes -

        //
        // GET: /Reflection/Notes/GetNotesJson
        [HttpGet]
        public JsonResult GetNotesJson(Area area)
        {
            return CollectionJson(area.Notes, null);
        }

        //
        // POST: /Reflection/Notes/PostNotesJsonAdd
        [HttpPost]
        public JsonResult PostNotesJsonAdd(Area area)
        {
            return CollectionJsonAdd(area.Notes);
        }

        //
        // POST: /Reflection/Notes/PostNotesJsonClear
        [HttpPost]
        public JsonResult PostNotesJsonClear(Area area)
        {
            return CollectionJsonClear(area.Notes);
        }

        //
        // POST: /Reflection/Notes/PostNotesJsonContains
        [HttpPost]
        public JsonResult PostNotesJsonContains(Area area)
        {
            return CollectionJsonContains(area.Notes);
        }

        //
        // POST: /Reflection/Notes/PostNotesJsonCopyTo
        [HttpPost]
        public JsonResult PostNotesJsonCopyTo(Area area)
        {
            return CollectionJsonCopyTo(area.Notes);
        }

        //
        // POST: /Reflection/Notes/PostNotesJsonIndexOf
        [HttpPost]
        public JsonResult PostNotesJsonIndexOf(Area area)
        {
            return CollectionJsonIndexOf(area.Notes);
        }

        //
        // POST: /Reflection/Notes/PostNotesJsonInsert
        [HttpPost]
        public JsonResult PostNotesJsonInsert(Area area)
        {
            return CollectionJsonInsert(area.Notes);
        }

        //
        // POST: /Reflection/Notes/PostNotesJsonMoveTo
        [HttpPost]
        public JsonResult PostNotesJsonMoveTo(Area area)
        {
            return CollectionJsonMoveTo(area.Notes);
        }

        //
        // POST: /Reflection/Notes/PostNotesJsonRemove
        [HttpPost]
        public JsonResult PostNotesJsonRemove(Area area)
        {
            return CollectionJsonRemove(area.Notes, (Note o, string id) => { return o.Id == id; });
        }

        //
        // POST: /Reflection/Notes/PostNotesJsonRemoveAt
        [HttpPost]
        public JsonResult PostNotesJsonRemoveAt(Area area)
        {
            return CollectionJsonRemoveAt(area.Notes);
        }

        #endregion - Notes -
    }
}
