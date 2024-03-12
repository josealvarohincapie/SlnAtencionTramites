using AtencionTramites.Model.ModelAtencionTramites;
using Ultimus.Interfaces;

namespace AtencionTramites.Model.Classes
{
	public class TipoSolicitanteJSON : UltimusJson
	{
		public string NombreTipoS { get; set; }

		public Secretaria Secretaria { get; set; }
	}
}
