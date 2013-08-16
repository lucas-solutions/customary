using System.Web.Mvc;

namespace Custom.Areas.ExtJs
{
    public class ExtJsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "ExtJs"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ExtJs",
                "ExtJs/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
