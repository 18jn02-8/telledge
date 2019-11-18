using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace telledge
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /*
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Student",
                "student/{controller}/{action}/{id}",
                new { id = UrlParameter.Optional },
                new[] { "telledge.Controllers.Student" }
            );
            routes.MapRoute(
                "Default", // ���[�g��
                "teacher/{controller}/{action}/{id}", // �p�����[�^�[�t���� URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // �p�����[�^�[�̊���l
            );

        }
        */
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
