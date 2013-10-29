using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
//using System.Web.Http;

namespace Custom.Areas.Type.Controllers
{
    using Custom.Web;

    public class ValueController : Custom.Controllers.DataController
    {
        //
        // GET: Data/Type/Value/{id}/Read

        [AcceptVerbs(HttpVerbs.Get)]
        public override ActionResult Read(Guid id, string store)
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
        // GET: Data/Type/Value/{id}/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public override ActionResult Create(Guid id, string store)
        {
            return Json(id);
        }

        //
        // GET: Data/Type/Value/{id}/Update

        [AcceptVerbs(HttpVerbs.Put | HttpVerbs.Patch | HttpVerbs.Post)]
        public override ActionResult Update(Guid id, string store, bool patch)
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
        // GET: Data/Type/Value/{id}/Delete

        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Get | HttpVerbs.Post)]
        public override ActionResult Delete(Guid id, string store)
        {
            return Json(new { success = true, message = string.Format("Type/Value/{0} deleted.", id) }, JsonRequestBehavior.AllowGet);
        }
    }

    /*
    public class ValueController : ApiController
    {
        // GET api/value
        public IEnumerable<string> Get(int? skip, int? take, int? page, string sort)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/value/5
        public string Get(Guid id, CrudActions crud)
        {
            switch (crud)
            {
                case CrudActions.Delete:
                    return "DELETE";
                default:
                    return "READ";
            }
        }

        // POST api/value
        public void Post([FromBody]string value)
        {
            //return "CREATE";
        }

        // POST api/value
        public void Post(Guid id, [FromBody]string value, CrudActions crud)
        {
            switch (crud)
            {
                case CrudActions.Updagte:
                    //return "UPDATE";
                    break;
                case CrudActions.Delete:
                    //return "DELETE";
                    break;
                default:
                    //return "CREATE";
                    break;
            }
        }

        // PUT api/value/5
        public void Put(Guid id, [FromBody]string value)
        {
            //return "UPDATE";
        }

        // DELETE api/value/5
        public void Delete(Guid id)
        {
            //return "DELETE";
        }
    }*/
}
