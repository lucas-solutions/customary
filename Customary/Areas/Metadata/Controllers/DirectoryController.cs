using Raven.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Metadata.Controllers
{
    /// <summary>
    /// Presents the left panel with a tree browsing the types
    /// </summary>
    public class DirectoryController : Custom.Controllers.CustomController
    {
        //
        // GET: /Metadata/Directory/Panel

        public ActionResult Panel()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Directory/Read

        public ActionResult Read(string id)
        {
            var directory = Global.Metadata.Directory;

            var match = string.IsNullOrEmpty(id) ? directory : directory.Match(id.Split('-').AsEnumerable().GetEnumerator());

            return match != null
                ? Raven(true, null, match.ToRavenJObject(true)["children"])
                : Raven(false, "Not found", null);
        }
    }
}
