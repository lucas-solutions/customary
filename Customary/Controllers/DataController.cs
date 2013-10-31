using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Custom.Controllers
{
    using Custom.Data;
    using Custom.Data.Metadata;
    using Custom.Models;
    
    public class DataController : Custom.Web.Mvc.CustomController
    {
        #region - CRUD actions -

        //
        // GET: Data/{area}/{controller}/{id}/Read
        // GET: Data/{controller}/{id}/Read

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ActionResult Read(Guid id, string store)
        {
            if (Guid.Empty.Equals(id))
            {
            }
            else
            {
            }

            return Json(id, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: Data/{area}/{controller}/{id}/Create
        // GET: Data/{controller}/{id}/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Create(Guid id, string store)
        {
            return Json(id);
        }

        //
        // GET: Data/{area}/{controller}/{id}/Update
        // GET: Data/{controller}/{id}/Update

        [AcceptVerbs(HttpVerbs.Put | HttpVerbs.Patch | HttpVerbs.Post)]
        public virtual ActionResult Update(Guid id, string store, bool patch)
        {
            if (Guid.Empty.Equals(id))
            {
            }
            else
            {
            }

            return Json(id);
        }

        //
        // GET: Data/{area}/{controller}/{id}/Delete
        // GET: Data/{controller}/{id}/Delete

        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Get | HttpVerbs.Post)]
        public virtual ActionResult Delete(Guid id, string store)
        {
            string root, discriminator, document, key;

            if (RouteData.Route == RouteTable.Routes[Global.DataRouteName])
            {
                discriminator = null;
                root = document = RouteData.Values["controller"] as string;
            }
            else if (RouteData.Route == RouteTable.Routes[Global.DataGroupRouteName])
            {
                root = RouteData.Values["area"] as string;
                discriminator = RouteData.Values["controller"] as string;
                document = string.Concat(root, '/', discriminator);
            }
            else
            {
                throw new Exception();
            }

            key = string.Concat(document, '/', id);

            Dictionary<string, string> _baseToStoreName = null;

            if (string.IsNullOrEmpty(store))
            {
                _baseToStoreName.TryGetValue(document, out store);
            }

            if (string.IsNullOrEmpty(store) && !string.IsNullOrEmpty(discriminator))
            {
                _baseToStoreName.TryGetValue(root, out store);
            }

            if (string.IsNullOrEmpty(store))
            {
                throw new Exception();
            }

            return Json(new { success = true, message = string.Format("{0} deleted from store {1}.", key, store) }, JsonRequestBehavior.AllowGet);
        }

        #endregion - CRUD actions -

        //
        // GET: /Data/Browse

        public ActionResult Browse()
        {
            var page = new Page(this, null);

            page.Title = "Welcome to Customary Metadata";

            return page;
        }

        #region - Service call dropplet -

        //
        // GET: /Data/Drop

        public ActionResult Drop(string name, string id)
        {
            return PartialView();
        }

        #endregion - Service call dropplet -

        #region - Service call process -

        //
        // POST: /Data/Invoke

        [HttpPost]
        public ActionResult Invoke(string name, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion - Service call process -

        #region - Entity edit dropplets -

        //
        // GET: /Data/Edit

        public ActionResult Edit(string name, string id)
        {
            return PartialView();
        }

        //
        // GET: /Data/New

        public ActionResult New(string name)
        {
            return PartialView();
        }

        //
        // GET: /Data/View

        public ActionResult View(string name, string id)
        {
            return PartialView();
        }

        #endregion - Entity edit dropplets -


        //
        // GET: /Data/Directory.js

        public ActionResult Directory()
        {
            return ScriptView();
        }

        //
        // GET: /Data/Factory.js

        public ActionResult Factory()
        {
            return File("~/Scripts/Data/Factory.js", "text/javascript");
        }

        //
        // GET: /Data/Enum/{id}

        public ActionResult Children(string id, string name, NameDescriptor descriptor)
        {
            Queue<string> surplus = null;

            if (descriptor == null)
            {
                if (!string.IsNullOrEmpty(name))
                    descriptor = DataDictionary.Current.Describe(name);
            }

            return descriptor != null && (surplus == null || surplus.Count > 0)
                ? Raven(true, null, descriptor.ToRavenJObject(true)["children"])
                : Raven(false, "Not found", null);
        }

        //
        // GET: /Data/Schema.js

        public ActionResult Schema()
        {
            return ScriptView();
        }
    }
}
