using System.Collections.Generic;
using AtencionTramites.Model.ModelAtencionTramites;
using Ultimus.Interfaces;

namespace AtencionTramites.Model.Classes
{
	public class AtencionTramiteQue_SeguimientoJSON : UltimusJson
	{
		public List<RadicadoDecision> RadicadoDecisionList { get; set; }
	}
}
