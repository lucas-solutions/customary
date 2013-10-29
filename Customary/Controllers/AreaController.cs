using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Custom.Controllers
{
    using Custom.Web;

    public class AreaController : ApiController
    {
        // GET api/area
        public IEnumerable<string> Get(int? skip, int? take, int? page, string sort)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/area/5
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

        // POST api/area
        public void Post([FromBody]string value)
        {
            //return "CREATE";
        }

        // POST api/area
        public void Post(Guid id, [FromBody]string value, CrudActions crud)
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

        // PUT api/area/5
        public void Put(Guid id, [FromBody]string value)
        {
            // return "UPDATE";
        }

        // DELETE api/area/5
        public void Delete(Guid id)
        {
            //return "DELETE";
        }
    }
}
