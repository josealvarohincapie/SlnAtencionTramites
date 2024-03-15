﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AtencionTramites
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Default", "{controller}/{action}/{id}/{id2}", new
            {
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional,
                id2 = UrlParameter.Optional
            });
        }
    }
}