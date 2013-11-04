using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Custom.Areas.Data.Controllers
{
    using Custom.Data;
    using Custom.Data.Metadata;
    using Custom.Web.Mvc;
    using Raven.Json.Linq;

    public class AreaController : Controller
    {
        private ModelDescriptor _model;

        public ModelDescriptor ResolveModel()
        {
            return _model ?? (_model = DataDictionary.Current.Describe("Metadata/Area") as ModelDescriptor);
        }

        protected AreaDescriptor ResolveArea(Guid id)
        {
            var name = ModelDescriptor.Dictionary[id];

            if (name == null)
            {
                var definitionKey = string.Concat("Area/", id.ToString("D"));
                var definition = Global.Metadata.Session.Load<RavenJObject>(definitionKey);
                if (definition != null)
                    name = definition.Value<string>("name");
            }

            if (name == null)
                return null;

            var descriptior = DataDictionary.Current.Describe(name) as AreaDescriptor;

            return descriptior;
        }

        //
        // GET: Area/{id}
        // GET: Area/{id}/Read

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ActionResult Read(Guid id, int? skip, int? take)
        {
            var name = "Metadata/Area";
            var descriptor = ResolveModel();

            if (descriptor == null)
                return Json(new { success = false, message = string.Format("Could not resolve {0} model", name) }, JsonRequestBehavior.AllowGet);
            else
            {
                var repository = descriptor.Repository;

                if (repository == null)
                    return Json(new { success = false, message = string.Format("Could not resolve {0} repository", name) }, JsonRequestBehavior.AllowGet);

                if (Guid.Empty.Equals(id))
                {
                    return new RavenJObjectResult { Content = descriptor.Repository.Read(skip ?? 0, take ?? byte.MaxValue) };
                }
                else
                {
                    return new RavenJObjectResult { Content = descriptor.Repository.Read(id) };
                }
            }
        }

        //
        // POST: Area/
        // POST: Area/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Create()
        {
            var name = "Metadata/Area";
            var descriptor = ResolveModel();

            if (descriptor == null)
                return Json(new { success = false, message = string.Format("Could not resolve {0} model", name) }, JsonRequestBehavior.AllowGet);
            else
            {
                var repository = descriptor.Repository;

                if (repository == null)
                    return Json(new { success = false, message = string.Format("Could not resolve {0} repository", name) }, JsonRequestBehavior.AllowGet);

                return new RavenJObjectResult { Content = descriptor.Repository.Create(null) };
            }
        }

        //
        // PUT: {type}/{id}
        // PUT: {type}/{id}/Update
        // PATCH: {type}/{id}
        // PATCH: {type}/{id}/Update
        // POST: {type}/{id}/Update

        [AcceptVerbs(HttpVerbs.Put | HttpVerbs.Patch | HttpVerbs.Post)]
        public virtual ActionResult Update(Guid id, bool patch)
        {
            var name = "Metadata/Area";
            var descriptor = ResolveModel();

            if (descriptor == null)
                return Json(new { success = false, message = string.Format("Could not resolve {0} model", name) }, JsonRequestBehavior.AllowGet);
            else
            {
                var repository = descriptor.Repository;

                if (repository == null)
                    return Json(new { success = false, message = string.Format("Could not resolve {0} repository", name) }, JsonRequestBehavior.AllowGet);

                return new RavenJObjectResult { Content = descriptor.Repository.Update(id, null, patch) };
            }
        }

        //
        // DELETE: {type}/{id}
        // DELETE: {type}/{id}/Delete
        // GET: {type}/{id}/Delete

        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Get | HttpVerbs.Post)]
        public virtual ActionResult Delete(Guid id)
        {
            var name = "Metadata/Area";
            var descriptor = ResolveModel();

            if (descriptor == null)
                return Json(new { success = false, message = string.Format("Could not resolve {0} model", name) }, JsonRequestBehavior.AllowGet);
            else
            {
                var repository = descriptor.Repository;

                if (repository == null)
                    return Json(new { success = false, message = string.Format("Could not resolve {0} repository", name) }, JsonRequestBehavior.AllowGet);

                return new RavenJObjectResult { Content = descriptor.Repository.Delete(id) };
            }
        }
    }
}
