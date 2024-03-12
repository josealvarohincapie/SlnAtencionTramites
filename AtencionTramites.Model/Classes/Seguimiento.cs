using System.Collections.Generic;

namespace AtencionTramites.Model.Classes
{
	public class Seguimiento
	{
		public bool Resultado { get; set; }

		public string NumeroRadicado { get; set; }

		public string NumeroDocumentoIdentificacion { get; set; }

		public string Correo { get; set; }

		public List<SeguimientoDecision> SeguimientoDecisionList { get; set; }
	}
}
