using AtencionTramites.Model.ModelAtencionTramites;
using Ultimus.Interfaces;

namespace AtencionTramites.Model.Classes
{
	public class DepartamentoJSON : UltimusJson
	{
		public string CodigoPais { get; set; }

		public Departamento Departamento { get; set; }
	}
}
