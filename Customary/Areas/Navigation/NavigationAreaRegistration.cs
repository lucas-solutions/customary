using System.Web.Mvc;

namespace Custom.Areas.Navigation
{
    public class NavigationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Navigation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            // Ext JS route
            context.MapRoute(
                "Navigation_ext",
                "App/Navigation/{controller}/{action}.js"
            );

            context.MapRoute(
                "Navigation_default",
                "Navigation/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
