using AtencionTramites.Model.ModelAtencionTramites;
using Ultimus.Interfaces;

namespace AtencionTramites.Model.Classes
{
	public class PqrsdJSON : UltimusJson
	{
		public Pqrs Pqrs { get; set; }

		public string NumeroRadicado { get; set; }

		public AceptaPolitica AceptaPolitica { get; set; }

		public bool GeneraExterno { get; set; }
	}
}
