using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Data.Controllers
{
    using Custom.Data;
    using Custom.Web.Mvc;
    using global::Raven.Json.Linq;

    public class DirectoryController : CustomController
    {
        //
        // GET: /Data/Directory/{name}

        public ActionResult Index(string name)
        {
            var descriptor = DataDictionary.Current.Describe(name);

            return descriptor != null
                ? Success(descriptor.ToRavenJObject(true)["children"])
                : Failure("Not found");
        }

        public ActionResult Store(string name)
        {
            var jsonArray = new RavenJArray(Global.Metadata.Session.Advanced.LoadStartingWith<RavenJObject>("Store/", null, 0, 100).OfType<RavenJToken>());

            return Success(jsonArray);
        }
    }
}
