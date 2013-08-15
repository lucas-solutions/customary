using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var logger = new Custom.Diagnostics.LogglyLogger("21e21e20-67cc-49ec-b817-a5e09e81780c");
            logger.LogError("Home Index", new HttpException(500, "Text"), new Dictionary<string, object> { { "value", "1" } });

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
