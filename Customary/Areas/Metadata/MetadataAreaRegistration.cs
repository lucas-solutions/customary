using System.Web.Mvc;

namespace Custom.Areas.Metadata
{
    public class MetadataAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Metadata";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            // Ext JS route
            context.MapRoute(
                "Metadata_ext",
                "App/Metadata/{controller}/{action}.js"
            );

            // Ext JS route
            context.MapRoute(
                "Metadata_ext_id",
                "App/Metadata/{controller}/{action}/{id}.js"
            );

            // Ext JS route
            context.MapRoute(
                "Metadata_custom_temp",
                "App/Metadata/{controller}/{action}.js"
            );

            context.MapRoute(
                "Business_Metadata",
                "Business/Metadata/{controller}/{action}/{id}.js",
                new { domain = "Business" }
            );

            context.MapRoute(
                "Custom_Metadata_temp",
                "Custom/Metadata/{controller}/{action}.js",
                new { domain = "Custom" }
            );

            context.MapRoute(
                "Custom_Metadata",
                "Custom/Metadata/{controller}/{action}/{id}.js",
                new { domain = "Custom" }
            );

            context.MapRoute(
                "Metadata_default",
                "Metadata/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
