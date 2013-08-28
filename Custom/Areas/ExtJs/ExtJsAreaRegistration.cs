using System.Web.Mvc;

namespace Custom.Areas.ExtJs
{
    public class ExtJsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ExtJS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ExtJS_default",
                "ExtJS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
