using Custom.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Data.Controllers
{
    public class EntityController : Controller
    {
        //
        // GET: Data/Store/Metadata/Type/Model/{model}/Entities
        // GET: Data/Store/Metadata/Type/Model/{model}/Entities/{Select|Read}
        // GET: Data/Store/Metadata/Type/Model/{model}/Entities/{id}
        // GET: Data/Store/Metadata/Type/Model/{model}/Entities/{id}/{Select|Read}

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Select(Guid model, Guid id)
        {
            return new RavenJObjectResult { Content = null };
        }

        //
        // POST: Data/Store/Metadata/Type/Model/{model}/Entities
        // POST: Data/Store/Metadata/Type/Model/{model}/Entities/{Insert|Create}

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Guid model, Guid id)
        {
            return new RavenJObjectResult { Content = null };
        }

        //
        // PUT: Data/Store/Metadata/Type/Model/{model}/Entities/{id}
        // PUT: Data/Store/Metadata/Type/Model/{model}/Entities/{id}/Update
        // PATCH: Data/Store/Metadata/Type/Model/{model}/Entities/{id}
        // PATCH: Data/Store/Metadata/Type/Model/{model}/Entities/{id}/Update
        // POST: Data/Store/Metadata/Type/Model/{model}/Entities/{id}/Update

        [AcceptVerbs(HttpVerbs.Put | HttpVerbs.Patch | HttpVerbs.Post)]
        public ActionResult Update(Guid model, Guid id, bool patch)
        {
            return new RavenJObjectResult { Content = null };
        }

        //
        // DELETE: Data/Store/Metadata/Type/Model/{model}/Entities/{id}
        // DELETE: Data/Store/Metadata/Type/Model/{model}/Entities/{id}/{Delete|Destroy}
        // GET: Data/Store/Metadata/Type/Model/{model}/Entities/{id}/{Delete|Destroy}

        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Delete(Guid model, Guid id)
        {
            return new RavenJObjectResult { Content = null };
        }

        // POST: Data/Store/Metadata/Type/Model/{id}/Validate

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Validate(Guid model, Guid id)
        {
            return new RavenJObjectResult { Content = null };
        }

        // GET: Data/Store/Metadata/Type/Model/{model}/Entities/{id}/Invoke/{fn}
        // POST: Data/Store/Metadata/Type/Model/{model}/Entities/{id}/Invoke/{fn}

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Invoke(Guid model, Guid id, string fn)
        {
            return new RavenJObjectResult { Content = null };
        }
    }
}
