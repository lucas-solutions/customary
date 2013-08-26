using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Admin.Controllers
{
    public class NavigationController : Controller
    {
        //
        // GET: /Admin/Navigation/

        public ActionResult Index()
        {
            //'Customary.model.Navigation'
            var vm = new Models.ViewModel
            {
                ClassName = "App.admin.views.Navigation",
                PageTitle = "Admin Navigation",
                ViewName = "~/Areas/Admin/Views/Navigation/Index.cshtml"
            };
            return View(Pages.ExtJs, vm);
        }

        //
        // GET: /Admin/Navigation/Domain

        public ActionResult Domain(string id)
        {
            var vm = new Models.ViewModel
            {
                ClassName = "App.admin.views.Navigation.Domain",
                PageTitle = "Admin Navigation Domain",
                ViewName = "~/Areas/Admin/Views/Navigation/Domain.cshtml"
            };
            return View(Pages.ExtJs, vm);
        }

        //
        // GET: /Admin/Navigation/Segment

        public ActionResult Segment(string id)
        {
            var vm = new Models.ViewModel
            {
                ClassName = "App.admin.views.Navigation.Segment",
                PageTitle = "Admin Navigation Segment",
                ViewName = "~/Areas/Admin/Views/Navigation/Segment.cshtml"
            };
            return View(Pages.ExtJs, vm);
        }
    }
}
