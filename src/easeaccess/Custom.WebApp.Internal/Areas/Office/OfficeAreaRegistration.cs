using System.Web.Mvc;

namespace Custom.Areas.Office
{
    public class OfficeAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Office";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Office_default",
                "Office/{controller}/{id}/{action}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
