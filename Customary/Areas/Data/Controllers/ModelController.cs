using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Data.Controllers
{
    using Custom.Web.Mvc;

    public sealed class ModelController : NameController
    {
        //
        // GET: Data/Store/Metadata/Type/Model
        // GET: Data/Store/Metadata/Type/Model/{Select|Read}
        // GET: Data/Store/Metadata/Type/Model/{id}
        // GET: Data/Store/Metadata/Type/Model/{id}/{Select|Read}

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Select(Guid id)
        {
            return base.Select("Type/Model", id);
        }

        //
        // POST: Data/Store/Metadata/Type/Model
        // POST: Data/Store/Metadata/Type/Model/{Insert|Create}

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create()
        {
            return base.Create("Type/Model");
        }

        //
        // PUT: Data/Store/Metadata/Type/Model/{id}
        // PUT: Data/Store/Metadata/Type/Model/{id}/Update
        // PATCH: Data/Store/Metadata/Type/Model/{id}
        // PATCH: Data/Store/Metadata/Type/Model/{id}/Update
        // POST: Data/Store/Metadata/Type/Model/{id}/Update

        [AcceptVerbs(HttpVerbs.Put | HttpVerbs.Patch | HttpVerbs.Post)]
        public ActionResult Update(Guid id, bool patch)
        {
            return base.Update("Type/Model", id, patch);
        }

        //
        // DELETE: Data/Store/Metadata/Type/Model/{id}
        // DELETE: Data/Store/Metadata/Type/Model/{id}/{Delete|Destroy}
        // GET: Data/Store/Metadata/Type/Model/{id}/{Delete|Destroy}

        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Delete(Guid id, string property, string index)
        {
            return base.Delete("Type/Model", id, property, index);
        }

        // POST: Data/Store/Metadata/Type/Model/{id}/Validate

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Validate(Guid id)
        {
            return base.Validate("Type/Model", id);
        }

        // GET: Data/Store/Metadata/Type/Model/Invoke/{fn}
        // GET: Data/Store/Metadata/Type/Model/{id}/Invoke/{fn}
        // POST: Data/Store/Metadata/Type/Model/Invoke/{fn}
        // POST: Data/Store/Metadata/Type/Model/{id}/Invoke/{fn}

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Invoke(Guid id, string fn)
        {
            return base.Invoke("Type/Model", id, fn);
        }
    }
}
