using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Data.Controllers
{
    using Custom.Web.Mvc;

    public sealed class EnumController : NameController
    {
        //
        // GET: Data/Metadata/Type/Enum
        // GET: Data/Metadata/Type/Enum/{Select|Read}
        // GET: Data/Metadata/Type/Enum/{id}
        // GET: Data/Metadata/Type/Enum/{id}/{Select|Read}

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Select(Guid id)
        {
            return new RavenJObjectResult { Content = null };
        }

        //
        // POST: Data/Metadata/Type/Enum
        // POST: Data/Metadata/Type/Enum/{Insert|Create}

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Guid id)
        {
            return new RavenJObjectResult { Content = null };
        }

        //
        // PUT: Data/Metadata/Type/Enum/{id}
        // PUT: Data/Metadata/Type/Enum/{id}/Update
        // PATCH: Data/Metadata/Type/Enum/{id}
        // PATCH: Data/Metadata/Type/Enum/{id}/Update
        // POST: Data/Metadata/Type/Enum/{id}/Update

        [AcceptVerbs(HttpVerbs.Put | HttpVerbs.Patch | HttpVerbs.Post)]
        public ActionResult Update(Guid id, bool patch)
        {
            return new RavenJObjectResult { Content = null };
        }

        //
        // DELETE: Data/Metadata/Type/Enum/{id}
        // DELETE: Data/Metadata/Type/Enum/{id}/{Delete|Destroy}
        // GET: Data/Metadata/Type/Enum/{id}/{Delete|Destroy}

        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Delete(Guid id)
        {
            return new RavenJObjectResult { Content = null };
        }

        // POST: Data/Metadata/Type/Enum/{id}/Validate

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Validate(Guid id)
        {
            return new RavenJObjectResult { Content = null };
        }
    }
}
