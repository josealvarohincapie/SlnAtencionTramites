using AtencionTramites;
using System.Web;
using System.Web.Routing;

namespace AtencionTramites
{
	public class SessionRouteHandler : IRouteHandler
	{
		IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
		{
			return new SessionControllerHandler(requestContext.RouteData);
		}
	}
}