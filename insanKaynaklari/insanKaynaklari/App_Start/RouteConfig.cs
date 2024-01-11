using System.Web.Mvc;
using System.Web.Routing;

namespace insanKaynaklari
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GeneralSituations",
                url: "GeneralSituations/Index",
                defaults: new { controller = "GeneralSituations", action = "Index" }
            );

            routes.MapRoute(
                name: "Educations",
                url: "Educations/Index",
                defaults: new { controller = "Educations", action = "Index" }
            );

            routes.MapRoute(
                name: "People",
                url: "People/Index",
                defaults: new { controller = "People", action = "Index" }
            );
            
            routes.MapRoute(
                name: "Workers",
                url: "Workers/Index",
                defaults: new { controller = "Workers", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
