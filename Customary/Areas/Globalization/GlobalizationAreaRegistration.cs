using System.Web.Mvc;

namespace Custom.Areas.Globalization
{
    public class GlobalizationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Globalization";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            // Ext JS route
            context.MapRoute(
                "Globalization_ext",
                "App/Globalization/{controller}/{action}.js"
            );

            context.MapRoute(
                "Globalization_default",
                "Globalization/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
