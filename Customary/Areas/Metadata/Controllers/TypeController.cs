using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Metadata.Controllers
{
    using Custom.Areas.Metadata.Models;
    using Custom.Models;
    using Raven.Json.Linq;

    public class TypeController : Custom.Web.Mvc.CustomController
    {
        //
        // GET: /Metadata/Type/Field

        public ActionResult Field()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Type/Model

        public ActionResult Model()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Type/Proxy

        public ActionResult Proxy()
        {
            return ScriptView();
        }

        //
        // GET: /Metadata/Type/Read

        public ActionResult Read(int? page, int? start, int? limit, IEnumerable<Sort> sort, string culture)
        {
            var primitives = new[]
                {
                    typeof(System.Byte),
                    typeof(System.Double),
                    typeof(System.Single),
                    typeof(System.Int32),
                    typeof(System.Int64),
                    typeof(System.Int16),
                    typeof(System.SByte),
                    typeof(System.String),
                    typeof(System.UInt32),
                    typeof(System.UInt64),
                    typeof(System.UInt16),
                }.Select(o => new TypeModel { Name = o.Name, Namespace = o.Namespace }.ToRavenJObject());

            var data = primitives.ToRavenJArray();

            return Raven(data);
        }

        //
        // GET: /Metadata/Type/Store

        public ActionResult Store()
        {
            return ScriptView();
        }
    }
}
