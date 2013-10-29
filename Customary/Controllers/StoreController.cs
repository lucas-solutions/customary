using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Custom.Controllers
{
    public class StoreController : Controller
    {
        #region - CRUD actions -

        //
        // GET: Data/{type}/Read/{id}

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ActionResult Read(Guid type, Guid id)
        {
            var definitionKey = string.Concat("Type/Entity/", type);

            var definition = Global.Metadata.Session.Load<Custom.Data.Metadata.EntityDefinition>(definitionKey);

            if (Guid.Empty.Equals(id))
            {
            }
            else
            {
            }

            return Json(id, JsonRequestBehavior.AllowGet);
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
