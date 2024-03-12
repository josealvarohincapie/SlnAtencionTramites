using System.Security.Claims;

namespace AtencionTramites.Model.Classes
{
	public class JWTContainerModel : IAuthContainerModel
	{
		private Variables Variables = new Variables();

		public int ExpireMinutes { get; set; }

		public string SecretKey { get; set; }

		public string SecurityAlgorithm { get; set; } = "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256";


		public Claim[] Claims { get; set; }
	}
}
