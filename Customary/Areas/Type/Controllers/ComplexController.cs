using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Custom.Areas.Type.Controllers
{
    using Custom.Web;

    public class ComplexController : ApiController
    {
        // GET api/complex
        public IEnumerable<string> Get(int? skip, int? take, int? page, string sort)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/complex/5
        public string Get(int id, CrudActions crud)
        {
            switch (crud)
            {
                case CrudActions.Delete:
                    return "DELETE";
                default:
                    return "READ";
            }
        }

        // POST api/complex
        public void Post([FromBody]string value)
        {
            //return "CREATE";
        }

        // POST api/complex
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

        // PUT api/complex/5
        public void Put(int id, [FromBody]string value)
        {
            //return "UPDATE";
        }

        // DELETE api/complex/5
        public void Delete(int id)
        {
            //return "DELETE";
        }
    }
}
