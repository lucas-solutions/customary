using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Data.Controllers
{
    using Custom.Web.Mvc;

    public sealed class ValueController : Controller
    {
        //
        // GET: Data/Store/Metadata/Type/Value
        // GET: Data/Store/Metadata/Type/Value/{Select|Read}
        // GET: Data/Store/Metadata/Type/Value/{id}
        // GET: Data/Store/Metadata/Type/Value/{id}/{Select|Read}

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Select(Guid id)
        {
            return new RavenJObjectResult { Content = null };
        }

        //
        // POST: Data/Store/Metadata/Type/Value
        // POST: Data/Store/Metadata/Type/Value/{Insert|Create}

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Guid id)
        {
            return new RavenJObjectResult { Content = null };
        }

        //
        // PUT: Data/Store/Metadata/Type/Value/{id}
        // PUT: Data/Store/Metadata/Type/Value/{id}/Update
        // PATCH: Data/Store/Metadata/Type/Value/{id}
        // PATCH: Data/Store/Metadata/Type/Value/{id}/Update
        // POST: Data/Store/Metadata/Type/Value/{id}/Update

        [AcceptVerbs(HttpVerbs.Put | HttpVerbs.Patch | HttpVerbs.Post)]
        public ActionResult Update(Guid id, bool patch)
        {
            return new RavenJObjectResult { Content = null };
        }

        //
        // DELETE: Data/Store/Metadata/Type/Value/{id}
        // DELETE: Data/Store/Metadata/Type/Value/{id}/{Delete|Destroy}
        // GET: Data/Store/Metadata/Type/Value/{id}/{Delete|Destroy}

        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Delete(Guid id)
        {
            return new RavenJObjectResult { Content = null };
        }

        // POST: Data/Store/Metadata/Type/Value/{id}/Validate

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Validate(Guid id)
        {
            return new RavenJObjectResult { Content = null };
        }
    }
}
