using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.App.Controllers
{
    using Custom.Models;

    public class NavigationController : Controller
    {
        //
        // GET: /Admin/Navigation/

        public ActionResult Index()
        {
            //'Customary.model.Navigation'
            var vm = new ExtPageModel
            {
                ClassName = "App.admin.views.Navigation",
                PageTitle = "Admin Navigation",
                ViewName = "~/Areas/Admin/Views/Navigation/Index.cshtml"
            };
            return View(Pages.ExtJs, vm);
        }

        //
        // GET: /Admin/Navigation/Host

        public ActionResult Host(string id)
        {
            var vm = new ExtPageModel
            {
                ClassName = "App.admin.views.Navigation.Host",
                PageTitle = "Admin Navigation Domain",
                ViewName = "~/Areas/Admin/Views/Navigation/Host.cshtml"
            };
            return View(Pages.ExtJs, vm);
        }

        //
        // GET: /Admin/Navigation/Path

        public ActionResult Path(string id)
        {
            var vm = new ExtPageModel
            {
                ClassName = "App.admin.views.Navigation.Path",
                PageTitle = "Admin Navigation Segment",
                ViewName = "~/Areas/Admin/Views/Navigation/Path.cshtml"
            };
            return View(Pages.ExtJs, vm);
        }
    }
}
