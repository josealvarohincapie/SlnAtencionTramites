using AtencionTramites.Model.ModelAtencionTramites;
using Ultimus.Interfaces;

namespace AtencionTramites.Model.Classes
{
	public class CiudadJSON : UltimusJson
	{
		public string CodigoDepartamento { get; set; }

		public Ciudad Ciudad { get; set; }
	}
}