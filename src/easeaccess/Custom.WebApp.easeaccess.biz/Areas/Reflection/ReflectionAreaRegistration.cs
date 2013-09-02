using System.Web.Mvc;

namespace Custom.Areas.Reflection
{
    public class ReflectionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Reflection"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Reflection_default",
                "Reflection/{controller}/{action}");

            context.MapRoute(
                "Reflection_With_Id",
                "Reflection/{controller}/{id}/{action}",
                new { id = UrlParameter.Optional }
            );
        }
    }
}
