using System;

namespace AtencionTramites.Model.Classes
{
	public class SeguimientoDecision
	{
		public int Orden { get; set; }

		public string NombreDecision { get; set; }

		public string Etapa { get; set; }

		public DateTime FechaInicio { get; set; }

		public DateTime? FechaFin { get; set; }
	}
}
