using System.Collections.Generic;
using AtencionTramites.Model.ModelAtencionTramites;
using Ultimus.Interfaces;

namespace AtencionTramites.Model.Classes
{
	public class AtencionTramiteAse_SeguimientoJSON : UltimusJson
	{
		public long CodigoSolicitudOriginal { get; set; }

		public long CodigoSolicitudInterna { get; set; }

		public List<RadicadoDecision> RadicadoDecisionList { get; set; }

		public List<RadicadoInternoDecision> RadicadoInternoDecisionList { get; set; }
	}
}
