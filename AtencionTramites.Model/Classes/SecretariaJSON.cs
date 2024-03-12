using AtencionTramites.Model.ModelAtencionTramites;
using Ultimus.Interfaces;

namespace AtencionTramites.Model.Classes
{
	public class SecretariaJSON : UltimusJson
	{
		public string NombreSecretaria { get; set; }

		public Secretaria Secretaria { get; set; }
	}
}
