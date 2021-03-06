using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace telledge
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Student",
                "student/{controller}/{action}/{id}",
                new { id = UrlParameter.Optional },
                new[] { "telledge.Controllers.Students" }
            );
            routes.MapRoute(
                "Teacher",
                "teacher/{controller}/{action}/{id}",
                new { id = UrlParameter.Optional },
                new[] { "telledge.Controllers.Teachers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "top"}
            );
        }
    }
}
