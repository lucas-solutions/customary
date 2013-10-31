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
    using Custom.Web.Mvc;

    public class StoreController : CustomController
    {

        protected ModelDescriptor ResolveModel(Guid type)
        {
            var name = DataDictionary.Current[type];

            if (name == null)
            {
                var definitionKey = string.Concat("Type/Model/", type);
                var definition = Global.Metadata.Session.Load<ModelDefinition>(definitionKey);

                name = definition.Name;
            }

            var descriptior = DataDictionary.Current.Describe(name) as ModelDescriptor;

            return descriptior;
        }
             

        #region - CRUD actions -

        //
        // GET: Data/{type}/Read/{id}

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ActionResult Read(Guid type, Guid id, int? skip, int? take)
        {
            var descriptor = ResolveModel(type);

            if (descriptor == null)
                return Json(new { success = false, message = string.Format("Could not resolve model {0}", type) }, JsonRequestBehavior.AllowGet);
            else
            {
                var repository = descriptor.Repository;

                if (repository == null)
                    return Json(new { success = false, message = string.Format("Could not resolve model {0} (1) repository", descriptor.Path, type) }, JsonRequestBehavior.AllowGet);

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
        // GET: Data/{type}/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Create(Guid type)
        {
            var descriptor = ResolveModel(type);

            if (descriptor == null)
                return Json(new { success = false, message = string.Format("Could not resolve model {0}", type) }, JsonRequestBehavior.AllowGet);
            else
            {
                var repository = descriptor.Repository;

                if (repository == null)
                    return Json(new { success = false, message = string.Format("Could not resolve model {0} (1) repository", descriptor.Path, type) }, JsonRequestBehavior.AllowGet);

                return new RavenJObjectResult { Content = descriptor.Repository.Create(null) };
            }
        }

        //
        // GET: Data/{type}/Update/{id}

        [AcceptVerbs(HttpVerbs.Put | HttpVerbs.Patch | HttpVerbs.Post)]
        public virtual ActionResult Update(Guid id, Guid type, bool patch)
        {
            var descriptor = ResolveModel(type);

            if (descriptor == null)
                return Json(new { success = false, message = string.Format("Could not resolve model {0}", type) }, JsonRequestBehavior.AllowGet);
            else
            {
                var repository = descriptor.Repository;

                if (repository == null)
                    return Json(new { success = false, message = string.Format("Could not resolve model {0} (1) repository", descriptor.Path, type) }, JsonRequestBehavior.AllowGet);

                return new RavenJObjectResult { Content = descriptor.Repository.Update(id, null, patch) };
            }
        }

        //
        // GET: Data/{type}/Delete/{id}

        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Get | HttpVerbs.Post)]
        public virtual ActionResult Delete(Guid type, Guid id)
        {
            var descriptor = ResolveModel(type);

            if (descriptor == null)
                return Json(new { success = false, message = string.Format("Could not resolve model {0}", type) }, JsonRequestBehavior.AllowGet);
            else
            {
                var repository = descriptor.Repository;

                if (repository == null)
                    return Json(new { success = false, message = string.Format("Could not resolve model {0} (1) repository", descriptor.Path, type) }, JsonRequestBehavior.AllowGet);

                return new RavenJObjectResult { Content = descriptor.Repository.Delete(id) };
            }
        }

        #endregion - CRUD actions -
    }
}
