using System.Web.Mvc;

namespace Custom.Areas.Diagnostics
{
    public class DiagnosticsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Diagnostics";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            // Ext JS route
            context.MapRoute(
                "Diagnostics_ext",
                "App/Diagnostics/{controller}/{action}.js"
            );

            context.MapRoute(
                "Diagnostics_default",
                "Diagnostics/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
