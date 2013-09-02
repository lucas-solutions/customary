using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Extensions;
    using Custom.Models;
    using Custom.Processes;
    using Custom.Results;
    using Custom.Transforms;

    public class AreasController : ReflectionController
    {
        //
        // GET: /Areas/GetHtml
        [HttpGet]
        public ViewResult GetHtml(Area area)
        {
            return View("Display", new AreaViewModel
            {
                Area = area
            });
        }

        //
        // GET: /Areas/GetJson
        [HttpGet]
        public JsonResult GetJson(Area area)
        {
            return null;
        }

        //
        // GET: /Areas/GetJsonChildren
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
                    name = o.Name,
                    path = "Nodes",
                    text = o.Name,
                    type = "area"
                })), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Areas/GetJsonMetadata
        [HttpGet]
        public JsonResult GetJsonMetadata(Area area)
        {
            using (var processes = new AreaProcesses(Reflection))
            {
                return Json(processes.Metadata, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // POST: /Areas/PostJsonCopyTo
        [HttpPost]
        public JsonResult PostJsonCopyTo(Area area)
        {
            return null;
        }

        //
        // POST: /Areas/PostJsonCreate
        [HttpPost]
        public JsonResult PostJsonCreate(Area area)
        {
            return null;
        }

        //
        // POST: /Areas/PostJsonDelete
        [HttpPost]
        public JsonResult PostJsonDelete(Area area)
        {
            return null;
        }

        //
        // POST: /Areas/PostJsonMoveTo
        [HttpPost]
        public JsonResult PostJsonMoveTo(Area area)
        {
            return null;
        }

        //
        // GET: /Areas/GetJsonNode
        [HttpGet]
        public JsonResult GetJsonNode(Area area)
        {
            return Json(area.Areas.Select(o => new TreeNodeModel
            {
                name = o.Name,
                path = "Nodes",
                text = o.Name,
                type = "area"
            }));
        }

        //
        // POST: /Areas/PostJsonUpdate
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
        // GET: /Areas/GetAreasJson
        [HttpGet]
        public JsonResult GetAreasJson(Area area, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection))
            {
                result = Json(processes.Get(area.Areas, start ?? 0, limit ?? -1, AreaTransforms.ToPlainObject), JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        //
        // POST: /Areas/PostAreasJsonClear
        [HttpPost]
        public JsonResult PostAreasJsonClear(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Clear(area.Areas));
            }
            return result;
        }

        //
        // POST: /Areas/PostAreasJsonCopyTo
        [HttpPost]
        public JsonResult PostAreasJsonCopyTo(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.CopyTo(area.Areas));
            }
            return result;
        }

        //
        // POST: /Areas/PostAreasJsonInsert
        [HttpPost]
        public JsonResult PostAreasJsonInsert(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Insert(area.Areas, (Area x) => { return area.Areas.Any(o => o.Name == x.Name); }));
            }
            return result;
        }

        //
        // POST: /Areas/PostAreasJsonMoveTo
        [HttpPost]
        public JsonResult PostAreasJsonMoveTo(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.MoveTo(area.Areas));
            }
            return result;
        }

        //
        // POST: /Areas/PostAreasJsonRemove
        [HttpPost]
        public JsonResult PostAreasJsonRemove(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Remove(area.Areas, (Area x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        //
        // POST: /Areas/PostAreasJsonUpdate
        [HttpPost]
        public JsonResult PostAreasJsonUpdate(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Update(area.Areas, (Area x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        #endregion - Areas -

        #region - Files -

        //
        // GET: /Areas/GetFilesJson
        [HttpGet]
        public JsonResult GetFilesJson(Area area, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<File>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Get(area.Files, start ?? 0, limit ?? -1, null));
            }
            return result;
        }

        //
        // POST: /Areas/PostFilesJsonClear
        [HttpPost]
        public JsonResult PostFilesJsonClear(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<File>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Clear(area.Files));
            }
            return result;
        }

        //
        // POST: /Areas/PostFilesJsonCopyTo
        [HttpPost]
        public JsonResult PostFilesJsonCopyTo(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<File>(Reflection, BodyJsonObject))
            {
                result = Json(processes.CopyTo(area.Files));
            }
            return result;
        }

        //
        // POST: /Areas/PostFilesJsonInsert
        [HttpPost]
        public JsonResult PostFilesJsonInsert(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<File>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Insert(area.Files, (File x) => { return area.Files.Any(o => o.Name == x.Name); }));
            }
            return result;
        }

        //
        // POST: /Areas/PostFilesJsonMoveTo
        [HttpPost]
        public JsonResult PostFilesJsonMoveTo(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.MoveTo(area.Files));
            }
            return result;
        }

        //
        // POST: /Areas/PostFilesJsonRemove
        [HttpPost]
        public JsonResult PostFilesJsonRemove(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<File>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Remove(area.Files, (File x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        //
        // POST: /Areas/PostFilesJsonUpdate
        [HttpPost]
        public JsonResult PostFilesJsonUpdate(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<File>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Update(area.Files, (File x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        #endregion - Files -

        #region - Lists -

        //
        // GET: /Areas/GetListsJson
        [HttpGet]
        public JsonResult GetListsJson(Area area, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection))
            {
                result = Json(processes.Get(area.Lists, start ?? 0, limit ?? -1, null), JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        //
        // POST: /Areas/PostListsJsonClear
        [HttpPost]
        public JsonResult PostListsJsonClear(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<List>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Clear(area.Lists));
            }
            return result;
        }

        //
        // POST: /Areas/PostListsJsonCopyTo
        [HttpPost]
        public JsonResult PostListsJsonCopyTo(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.CopyTo(area.Lists));
            }
            return result;
        }

        //
        // POST: /Areas/PostListsJsonInsert
        [HttpPost]
        public JsonResult PostListsJsonInsert(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<List>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Insert(area.Lists, (List x) => { return area.Lists.Any(o => o.Name == x.Name); }));
            }
            return result;
        }

        //
        // POST: /Areas/PostListsJsonMoveTo
        [HttpPost]
        public JsonResult PostListsJsonMoveTo(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.MoveTo(area.Lists));
            }
            return result;
        }

        //
        // POST: /Areas/PostListsJsonRemove
        [HttpPost]
        public JsonResult PostListsJsonRemove(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<List>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Remove(area.Lists, (List x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        //
        // POST: /Areas/PostListsJsonUpdate
        [HttpPost]
        public JsonResult PostListsJsonUpdate(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<List>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Update(area.Lists, (List x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        #endregion - Lists -

        #region - Grids -

        //
        // GET: /Areas/GetGridsJson
        [HttpGet]
        public JsonResult GetGridsJson(Area area, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection))
            {
                result = Json(processes.Get(area.Grids, start ?? 0, limit ?? -1, null), JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        //
        // GET: /Areas/GetGridsJsonStore
        [HttpGet]
        public JsonResult GetGridsJsonStore(Area area, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection))
            {
                result = Json(processes.Get(area.Grids, start ?? 0, limit ?? -1, null), JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        //
        // POST: /Areas/PostGridsJsonClear
        [HttpPost]
        public JsonResult PostGridsJsonClear(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Clear(area.Grids));
            }
            return result;
        }

        //
        // POST: /Areas/PostGridsJsonCopyTo
        [HttpPost]
        public JsonResult PostGridsJsonCopyTo(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection, BodyJsonObject))
            {
                result = Json(processes.CopyTo(area.Grids));
            }
            return result;
        }

        //
        // POST: /Areas/PostGridsJsonInsert
        [HttpPost]
        public JsonResult PostGridsJsonInsert(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Insert(area.Grids, (Grid x) => { return area.Grids.Any(o => o.Name == x.Name); }));
            }
            return result;
        }

        //
        // POST: /Areas/PostGridsJsonMoveTo
        [HttpPost]
        public JsonResult PostGridsJsonMoveTo(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection, BodyJsonObject))
            {
                result = Json(processes.MoveTo(area.Grids));
            }
            return result;
        }

        //
        // POST: /Areas/PostGridsJsonRemove
        [HttpPost]
        public JsonResult PostGridsJsonRemove(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Remove(area.Grids, (Grid x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        //
        // POST: /Areas/PostGridsJsonUpdate
        [HttpPost]
        public JsonResult PostGridsJsonUpdate(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Update(area.Grids, (Grid x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        #endregion - Grids -

        #region - Notes -

        //
        // GET: /Areas/GetNotesJson
        [HttpGet]
        public JsonResult GetNotesJson(Area area, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection))
            {
                result = Json(processes.Get(area.Notes, start ?? 0, limit ?? -1, null), JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        //
        // POST: /Areas/PostNotesJsonClear
        [HttpPost]
        public JsonResult PostNotesJsonClear(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Clear(area.Notes));
            }
            return result;
        }

        //
        // POST: /Areas/PostNotesJsonCopyTo
        [HttpPost]
        public JsonResult PostNotesJsonCopyTo(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection, BodyJsonObject))
            {
                result = Json(processes.CopyTo(area.Notes));
            }
            return result;
        }

        //
        // POST: /Areas/PostNotesJsonInsert
        [HttpPost]
        public JsonResult PostNotesJsonInsert(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Insert(area.Notes, (Note x) => { return area.Notes.Any(o => o.Name == x.Name); }));
            }
            return result;
        }

        //
        // POST: /Areas/PostNotesJsonMoveTo
        [HttpPost]
        public JsonResult PostNotesJsonMoveTo(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection, BodyJsonObject))
            {
                result = Json(processes.MoveTo(area.Notes));
            }
            return result;
        }

        //
        // POST: /Areas/PostNotesJsonRemove
        [HttpPost]
        public JsonResult PostNotesJsonRemove(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Remove(area.Notes, (Note x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        //
        // POST: /Areas/PostNotesJsonUpdate
        [HttpPost]
        public JsonResult PostNotesJsonUpdate(Area area)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Update(area.Notes, (Note x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        #endregion - Notes -
    }
}
