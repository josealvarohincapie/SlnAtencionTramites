using System.Web.Http.Filters;

namespace AtencionTramites
{
	public class UnhandledExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext context)
		{
		}
	}
}