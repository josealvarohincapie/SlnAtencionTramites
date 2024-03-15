using System.Web.Http;

namespace AtencionTramites.WCF
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("ExternalApi", "api/{controller}/{action}/{id}", new
            {
                id = RouteParameter.Optional
            });
        }
    }
}
