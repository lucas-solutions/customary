using Raven.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Custom.Areas.Type.Controllers
{
    using Custom.Web;

    public class EntityController : ApiController
    {
        // GET api/entity
        public RavenJObject Get(int? skip, int? take, int? page, string sort)
        {
            var result = new RavenJObject();

            var data = new RavenJArray();

            data.Add(new RavenJValue("value1"));
            data.Add(new RavenJValue("value2"));

            result["success"] = true;
            result["data"] = data;

            return result;
        }

        // GET api/entity/5
        public RavenJObject Get(Guid id, CrudActions crud)
        {
            var result = new RavenJObject();

            switch (crud)
            {
                case CrudActions.Delete:
                    result["success"] = true;
                    result["message"] = string.Format("Entity {0} deleted.", id);
                    break;

                default:
                    var data = new RavenJArray();

                    data.Add(new RavenJValue(id));

                    result["success"] = true;
                    result["data"] = data;
                    break;
            }

            return result;
        }

        // POST api/entity
        public void Post([FromBody]RavenJToken value)
        {
            //return "CREATE";
        }

        // POST api/entity
        public void Post(Guid id, [FromBody]RavenJToken value, CrudActions crud)
        {
            switch (crud)
            {
                case CrudActions.Update:
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

        // PUT api/entity/5
        public void Put(Guid id, [FromBody]RavenJToken value)
        {
            //return "UPDATE";
        }

        // DELETE api/entity/5
        public void Delete(Guid id)
        {
            //return "DELETE";
        }
    }
}
