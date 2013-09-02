using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Models;
    using Custom.Processes;
    using Custom.Repositories;
    using Custom.Results;
    using Custom.Transforms;

    public class AppsController : ReflectionController
    {
        //
        // GET: /Apps/GetHtml
        [HttpGet]
        public ViewResult GetHtml(App app)
        {
            return View("Display", new AppViewModel
            {
                App = app
            });
        }

        //
        // GET: /Apps/GetJson
        [HttpGet]
        public JsonResult GetJson(App app)
        {
            return null;
        }

        //
        // GET: /Apps/GetJsonChildren
        [HttpGet]
        public JsonResult GetJsonChildren(App app)
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
                }.Union(app.Areas.Select(o => new TreeNodeModel
                {
                    name = o.Name,
                    path = "Nodes",
                    text = o.Name,
                    type = "area"
                })), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Apps/GetJsonMetadata
        [HttpGet]
        public JsonResult GetJsonMetadata(App app)
        {
            using (var processes = new AreaProcesses(Reflection))
            {
                return Json(processes.Metadata, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // POST: /Apps/PostJsonCopyTo
        [HttpPost]
        public JsonResult PostJsonCopyTo(App app)
        {
            return null;
        }

        //
        // POST: /Apps/PostJsonCreate
        [HttpPost]
        public JsonResult PostJsonCreate(App app)
        {
            return null;
        }

        //
        // POST: /Apps/PostJsonDelete
        [HttpPost]
        public JsonResult PostJsonDelete(App app)
        {
            return null;
        }

        //
        // POST: /Apps/PostJsonMoveTo
        [HttpPost]
        public JsonResult PostJsonMoveTo(App app)
        {
            return null;
        }

        //
        // GET: /Apps/GetJsonNode
        [HttpGet]
        public JsonResult GetJsonNode(App app)
        {
            return Json(app.Areas.Select(o => new TreeNodeModel
            {
                name = o.Name,
                path = "Nodes",
                text = o.Name,
                type = "area"
            }));
        }

        //
        // POST: /Apps/PostJsonUpdate
        [HttpPost]
        public JsonResult PostJsonUpdate(App app)
        {
            return null;
        }

        /*Get {value} {format}
        Post {value} {format} Inc { amount: ? }
        Post {value} {format} Set { value: ? }
        Post {value} {format} Unset { }*/


        #region - Areas -

        //
        // GET: /Apps/GetAreasJson
        [HttpGet]
        public JsonResult GetAreasJson(App app, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection))
            {
                result = Json(processes.Get(app.Areas, start ?? 0, limit ?? -1, AreaTransforms.ToPlainObject), JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        //
        // GET: /Areas/GetAreasJsonStore
        [HttpGet]
        public JsonResult GetAreasJsonStore(App app, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection))
            {
                result = Json(processes.Get(app.Areas, start ?? 0, limit ?? -1, null), JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        //
        // POST: /Apps/PostAreasJsonClear
        [HttpPost]
        public JsonResult PostAreasJsonClear(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Clear(app.Areas));
            }
            return result;
        }

        //
        // POST: /Apps/PostAreasJsonCopyTo
        [HttpPost]
        public JsonResult PostAreasJsonCopyTo(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.CopyTo(app.Areas));
            }
            return result;
        }

        //
        // POST: /Apps/PostAreasJsonInsert
        [HttpPost]
        public JsonResult PostAreasJsonInsert(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Insert(app.Areas, (Area x) => { return app.Areas.Any(o => o.Name == x.Name); }));
            }
            return result;
        }

        //
        // POST: /Apps/PostAreasJsonMoveTo
        [HttpPost]
        public JsonResult PostAreasJsonMoveTo(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.MoveTo(app.Areas));
            }
            return result;
        }

        //
        // POST: /Apps/PostAreasJsonRemove
        [HttpPost]
        public JsonResult PostAreasJsonRemove(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Remove(app.Areas, (Area x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        //
        // POST: /Apps/PostAreasJsonUpdate
        [HttpPost]
        public JsonResult PostAreasJsonUpdate(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Update(app.Areas, (Area x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        #endregion - Areas -

        #region - Files -

        //
        // GET: /Apps/GetFilesJson
        [HttpGet]
        public JsonResult GetFilesJson(App app, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<File>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Get(app.Files, start ?? 0, limit ?? -1, null), JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        //
        // GET: /Apps/GetFilesJsonStore
        [HttpGet]
        public JsonResult GetFilesJsonStore(App app, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<File>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Get(app.Files, start ?? 0, limit ?? -1, null), JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        //
        // POST: /Apps/PostFilesJsonClear
        [HttpPost]
        public JsonResult PostFilesJsonClear(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<File>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Clear(app.Files));
            }
            return result;
        }

        //
        // POST: /Apps/PostFilesJsonCopyTo
        [HttpPost]
        public JsonResult PostFilesJsonCopyTo(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<File>(Reflection, BodyJsonObject))
            {
                result = Json(processes.CopyTo(app.Files));
            }
            return result;
        }

        //
        // POST: /Apps/PostFilesJsonInsert
        [HttpPost]
        public JsonResult PostFilesJsonInsert(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<File>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Insert(app.Files, (File x) => { return app.Files.Any(o => o.Name == x.Name); }));
            }
            return result;
        }

        //
        // POST: /Apps/PostFilesJsonMoveTo
        [HttpPost]
        public JsonResult PostFilesJsonMoveTo(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.MoveTo(app.Files));
            }
            return result;
        }

        //
        // POST: /Apps/PostFilesJsonRemove
        [HttpPost]
        public JsonResult PostFilesJsonRemove(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<File>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Remove(app.Files, (File x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        //
        // POST: /Apps/PostFilesJsonUpdate
        [HttpPost]
        public JsonResult PostFilesJsonUpdate(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<File>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Update(app.Files, (File x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        #endregion - Files -

        #region - Lists -

        //
        // GET: /Apps/GetListsJson
        [HttpGet]
        public JsonResult GetListsJson(App app, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection))
            {
                result = Json(processes.Get(app.Lists, start ?? 0, limit ?? -1, null), JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        //
        // GET: /Areas/GetListsJsonStore
        [HttpGet]
        public JsonResult GetListsJsonStore(App app, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<List>(Reflection))
            {
                result = Json(processes.Get(app.Lists, start ?? 0, limit ?? -1, null), JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        //
        // POST: /Apps/PostListsJsonClear
        [HttpPost]
        public JsonResult PostListsJsonClear(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<List>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Clear(app.Lists));
            }
            return result;
        }

        //
        // POST: /Apps/PostListsJsonCopyTo
        [HttpPost]
        public JsonResult PostListsJsonCopyTo(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.CopyTo(app.Lists));
            }
            return result;
        }

        //
        // POST: /Apps/PostListsJsonInsert
        [HttpPost]
        public JsonResult PostListsJsonInsert(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<List>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Insert(app.Lists, (List x) => { return app.Lists.Any(o => o.Name == x.Name); }));
            }
            return result;
        }

        //
        // POST: /Apps/PostListsJsonMoveTo
        [HttpPost]
        public JsonResult PostListsJsonMoveTo(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Area>(Reflection, BodyJsonObject))
            {
                result = Json(processes.MoveTo(app.Lists));
            }
            return result;
        }

        //
        // POST: /Apps/PostListsJsonRemove
        [HttpPost]
        public JsonResult PostListsJsonRemove(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<List>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Remove(app.Lists, (List x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        //
        // POST: /Apps/PostListsJsonUpdate
        [HttpPost]
        public JsonResult PostListsJsonUpdate(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<List>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Update(app.Lists, (List x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        #endregion - Lists -

        #region - Grids -

        //
        // GET: /Apps/GetGridsJson
        [HttpGet]
        public JsonResult GetGridsJson(App app, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection))
            {
                result = Json(processes.Get(app.Grids, start ?? 0, limit ?? -1, null), JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        //
        // GET: /Areas/GetGridsJsonStore
        [HttpGet]
        public JsonResult GetGridsJsonStore(App app, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection))
            {
                result = Json(processes.Get(app.Grids, start ?? 0, limit ?? -1, null), JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        //
        // POST: /Apps/PostGridsJsonClear
        [HttpPost]
        public JsonResult PostGridsJsonClear(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Clear(app.Grids));
            }
            return result;
        }

        //
        // POST: /Apps/PostGridsJsonCopyTo
        [HttpPost]
        public JsonResult PostGridsJsonCopyTo(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection, BodyJsonObject))
            {
                result = Json(processes.CopyTo(app.Grids));
            }
            return result;
        }

        //
        // POST: /Apps/PostGridsJsonInsert
        [HttpPost]
        public JsonResult PostGridsJsonInsert(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Insert(app.Grids, (Grid x) => { return app.Grids.Any(o => o.Name == x.Name); }));
            }
            return result;
        }

        //
        // POST: /Apps/PostGridsJsonMoveTo
        [HttpPost]
        public JsonResult PostGridsJsonMoveTo(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection, BodyJsonObject))
            {
                result = Json(processes.MoveTo(app.Grids));
            }
            return result;
        }

        //
        // POST: /Apps/PostGridsJsonRemove
        [HttpPost]
        public JsonResult PostGridsJsonRemove(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Remove(app.Grids, (Grid x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        //
        // POST: /Apps/PostGridsJsonUpdate
        [HttpPost]
        public JsonResult PostGridsJsonUpdate(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Grid>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Update(app.Grids, (Grid x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        #endregion - Grids -

        #region - Notes -

        //
        // GET: /Apps/GetNotesJson
        [HttpGet]
        public JsonResult GetNotesJson(App app, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection))
            {
                result = Json(processes.Get(app.Notes, start ?? 0, limit ?? -1, null), JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        //
        // GET: /Areas/GetNotesJsonStore
        [HttpGet]
        public JsonResult GetNotesJsonStore(App app, int? start, int? limit, int? page)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection))
            {
                result = Json(processes.Get(app.Notes, start ?? 0, limit ?? -1, null), JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        //
        // POST: /Apps/PostNotesJsonClear
        [HttpPost]
        public JsonResult PostNotesJsonClear(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Clear(app.Notes));
            }
            return result;
        }

        //
        // POST: /Apps/PostNotesJsonCopyTo
        [HttpPost]
        public JsonResult PostNotesJsonCopyTo(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection, BodyJsonObject))
            {
                result = Json(processes.CopyTo(app.Notes));
            }
            return result;
        }

        //
        // POST: /Apps/PostNotesJsonInsert
        [HttpPost]
        public JsonResult PostNotesJsonInsert(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Insert(app.Notes, (Note x) => { return app.Notes.Any(o => o.Name == x.Name); }));
            }
            return result;
        }

        //
        // POST: /Apps/PostNotesJsonMoveTo
        [HttpPost]
        public JsonResult PostNotesJsonMoveTo(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection, BodyJsonObject))
            {
                result = Json(processes.MoveTo(app.Notes));
            }
            return result;
        }

        //
        // POST: /Apps/PostNotesJsonRemove
        [HttpPost]
        public JsonResult PostNotesJsonRemove(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Remove(app.Notes, (Note x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        //
        // POST: /Apps/PostNotesJsonUpdate
        [HttpPost]
        public JsonResult PostNotesJsonUpdate(App app)
        {
            JsonResult result;
            using (var processes = new ReflectionProcesses<Note>(Reflection, BodyJsonObject))
            {
                result = Json(processes.Update(app.Notes, (Note x, string id) => { return x.Name == id; }));
            }
            return result;
        }

        #endregion - Notes -
    }
}
