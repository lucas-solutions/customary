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

            context.MapRoute(
                "Metadata_default",
                "Metadata/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
