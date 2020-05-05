﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Case_SB_Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TokenAuth", action = "GetProducts", id = UrlParameter.Optional }
            );
        }
    }
}