using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Custom.Controllers
{
    using Custom.Web.Mvc;

    public class StoreController : CustomController
    {
        #region - CRUD actions -

        //
        // GET: Data/{type}/Read/{id}

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ActionResult Read(Guid type, Guid id, int? skip, int? take)
        {
            var definitionKey = string.Concat("Type/Model/", type);

            var definition = Global.Metadata.Session.Load<Custom.Data.Metadata.ModelDefinition>(definitionKey);

            var repository = Global.Repositories[definition];

            if (Guid.Empty.Equals(id))
            {
                return new RavenJObjectResult { Content = repository.Read(skip ?? 0, take ?? byte.MaxValue) };
            }
            else
            {
                return new RavenJObjectResult { Content = repository.Read(id) };
            }
        }

        //
        // GET: Data/{type}/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Create(Guid type)
        {
            return Json(type);
        }

        //
        // GET: Data/{type}/Update/{id}

        [AcceptVerbs(HttpVerbs.Put | HttpVerbs.Patch | HttpVerbs.Post)]
        public virtual ActionResult Update(Guid id, Guid type, bool patch)
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
        // GET: Data/{type}/Delete/{id}

        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Get | HttpVerbs.Post)]
        public virtual ActionResult Delete(Guid type, Guid id)
        {
            var repo = Global.Repositories[type];

            var success = repo.Delete(id);

            return Json(new { success = true, message = string.Format("{0} deleted from store {1}.", id, type) }, JsonRequestBehavior.AllowGet);
        }

        #endregion - CRUD actions -
    }
}
