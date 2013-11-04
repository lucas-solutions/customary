using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing; 

namespace Custom.Areas.Data.Controllers
{
    using Custom.Data;
    using Custom.Data.Metadata;
    using Custom.Web.Mvc;
    using Raven.Json.Linq;

    public sealed class StoreController : CustomController
    {
        //
        // GET: Store/{store}/{*keyPrefix}
        // GET: Store/{store}/{*keyPrefix}/{Select|Read}
        // GET: Store/{store}/{*keyPrefix}/{id}
        // GET: Store/{store}/{*keyPrefix}/{id}/{Select|Read}

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Select(string store, string keyPrefix, Guid id)
        {
            var data = new RavenJObject();
            data["url"] = new RavenJValue((RouteData.Route as Route).Url);

            foreach (var item in RouteData.Values)
                data[item.Key] = new RavenJValue(item.Value);

            data["store"] = new RavenJValue(store);
            data["keyPrefix"] = new RavenJValue(keyPrefix);
            data["id"] = new RavenJValue(id);

            return Success(data);
        }

        //
        // POST: Store/{store}/{*keyPrefix}
        // POST: Store/{store}/{*keyPrefix}/{Insert|Create}

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Insert(string store, string keyPrefix)
        {
            var data = new RavenJObject();
            data["url"] = new RavenJValue((RouteData.Route as Route).Url);

            foreach (var item in RouteData.Values)
                data[item.Key] = new RavenJValue(item.Value);

            data["store"] = new RavenJValue(store);
            data["keyPrefix"] = new RavenJValue(keyPrefix);

            return Success(data);
        }

        // 
        // PUT: Store/{store}/{*keyPrefix}/{id}?patch={patch}
        // PUT: Store/{store}/{*keyPrefix}/{id}/Update?patch={patch}
        // PATCH: Store/{store}/{*keyPrefix}/{id}
        // PATCH: Store/{store}/{*keyPrefix}/{id}/Update
        // POST: Store/{store}/{*keyPrefix}/{id}/Update?patch={patch}

        [AcceptVerbs(HttpVerbs.Put | HttpVerbs.Patch | HttpVerbs.Post)]
        public ActionResult Update(string store, string keyPrefix, Guid id, bool patch)
        {
            var data = new RavenJObject();
            data["url"] = new RavenJValue((RouteData.Route as Route).Url);

            foreach (var item in RouteData.Values)
                data[item.Key] = new RavenJValue(item.Value);

            data["store"] = new RavenJValue(store);
            data["keyPrefix"] = new RavenJValue(keyPrefix);
            data["id"] = new RavenJValue(id);

            return Success(data);
        }

        // 
        // DELETE: Store/{store}/{*keyPrefix}/{id}
        // DELETE: Store/{store}/{*keyPrefix}/{id}/{Delete|Destroy}
        // POST: Store/{store}/{*keyPrefix}/{id}/{Delete|Destroy}
        // GET: Store/{store}/{*keyPrefix}/{id}/{Delete|Destroy}

        [AcceptVerbs(HttpVerbs.Delete | HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Delete(string store, string keyPrefix, Guid id)
        {
            var data = new RavenJObject();
            data["url"] = new RavenJValue((RouteData.Route as Route).Url);

            foreach (var item in RouteData.Values)
                data[item.Key] = new RavenJValue(item.Value);

            data["store"] = new RavenJValue(store);
            data["keyPrefix"] = new RavenJValue(keyPrefix);
            data["id"] = new RavenJValue(id);

            return Success(data);
        }
    }
}
