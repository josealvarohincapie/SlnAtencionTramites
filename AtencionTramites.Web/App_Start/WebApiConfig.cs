using AtencionTramites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Routing;
using Ultimus.Utilitarios;

namespace AtencionTramites
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            RouteTable.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}/{id}/{id2}", new
            {
                id = RouteParameter.Optional,
                id2 = RouteParameter.Optional
            }).RouteHandler = new SessionRouteHandler();
            config.Filters.Add(new UnhandledExceptionFilter());
        }
    }
}