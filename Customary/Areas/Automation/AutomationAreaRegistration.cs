using System.Web.Mvc;

namespace Custom.Areas.Automation
{
    public class AutomationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Automation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            // Ext JS route
            context.MapRoute(
                "Automation_ext",
                "App/Automation/{controller}/{action}.js"
            );

            context.MapRoute(
                "Automation_default",
                "Automation/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
