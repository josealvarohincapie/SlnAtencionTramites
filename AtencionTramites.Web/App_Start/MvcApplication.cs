using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using Ultimus.Framework;

namespace AtencionTramites
{
	public class MvcApplication : HttpApplication
	{
		private void Application_Start(object sender, EventArgs e)
		{
			AreaRegistration.RegisterAllAreas();
			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			new ResourceTrasform().OptimizeUltimusFrameworkBundle();
			GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			};
			JsonConvert.DefaultSettings = () => new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				NullValueHandling = NullValueHandling.Ignore
			};
		}

        protected void Session_Start(object sender, EventArgs e)
		{
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
			if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
			{
				HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST, GET");
				HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Authorization, Origin, Content-Type, Accept, X-Requested-With");
				HttpContext.Current.ApplicationInstance.CompleteRequest();
			}
		}
	}
}