using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Admin.Controllers
{
    using Custom.Models.Ext;
    using Custom.Controllers;
    using Custom.Metadata;
    using Custom.Navigation;
    using Custom.Presentation;

    public class MetadataController : ExtController
    {
        //
        // GET: /Admin/Metadata/

        public ActionResult Index(string id)
        {
            if (id == null)
            {
            }

            var type = Global.Metadata.Describe(id);

            switch (type.MemberType)
            {
                case MemberTypes.Complex:
                    break;

                case MemberTypes.Entity:
                    break;

                case MemberTypes.Enum:
                    break;

                case MemberTypes.Primitive:
                    break;

                case MemberTypes.Unit:
                    break;
            }

            return View();
        }

        //
        // GET: /Admin/Metadata/Model

        public ActionResult Model(string id)
        {
            var type = Global.Metadata.Describe(id);

            if (type.MemberType != Metadata.MemberTypes.Entity)
            {
                return View();
            }

            var accept = Request.Accept();

            if (accept.Test(AcceptTypes.JavaScript))
            {
                var model = new ModelViewModel
                {
                };

                return Script(Scripts.Model, model);
            }

            if (accept.Test(AcceptTypes.Html) || accept == AcceptTypes.Any)
            {
            }

            return View();
        }

        //
        // GET: /Admin/Metadata/Object

        public ActionResult Object(string id)
        {
            //var model = new FormViewModel();

            return View();
        }
    }
}
