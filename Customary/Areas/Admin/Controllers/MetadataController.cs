using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Admin.Controllers
{
    using Custom.Areas.Admin.Models;
    using Custom.Controllers;
    using Custom.Navigation;
    using Custom.Presentation;

    public class MetadataController : CustomController
    {
        //
        // GET: /Admin/Metadata/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Model()
        {
            var accept = Request.Accept();

            if (accept.Test(AcceptTypes.JavaScript))
            {
                var model = new ExtModel
                {
                };

                return Script(Scripts.Model, model);
            }

            if (accept.Test(AcceptTypes.Html) || accept == AcceptTypes.Any)
            {
            }

            return View();
        }

    }
}
