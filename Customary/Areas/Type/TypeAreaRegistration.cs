using System.Web.Http;
using System.Web.Mvc;

namespace Custom.Areas.Type
{
    public class TypeAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Type";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Type_default",
                "Type/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
