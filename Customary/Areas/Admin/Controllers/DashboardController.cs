using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Areas.Admin.Controllers
{
    using Custom.Areas.Admin.Models;
    using Custom.Models;

    public class DashboardController : Controller
    {
        //
        // GET: /Admin/Dashboard/

        public ActionResult Index()
        {
            var vm = new ExtPageModel
            {
                ClassName = "App.admin.Dashboard",
                PageTitle = "Admin Dashboard",
                ViewName = "~/Areas/Admin/Views/Dashboard/Index.cshtml"
            };
            return View(Pages.ExtJs, vm);
        }

    }
}
