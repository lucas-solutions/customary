using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Data.Controllers
{
    using Custom.Data;
    using Custom.Web.Mvc;

    public class DirectoryController : CustomController
    {
        //
        // GET: /Data/Directory/{name}

        public ActionResult Default(string name)
        {
            var descriptor = DataDictionary.Current.Describe(name);

            return descriptor != null
                ? Success(descriptor.ToRavenJObject(true)["children"])
                : Failure("Not found");
        }

    }
}
