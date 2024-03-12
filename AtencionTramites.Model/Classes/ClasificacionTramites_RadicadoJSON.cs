using AtencionTramites.Model.ModelAtencionTramites;
using Ultimus.Interfaces;

namespace AtencionTramites.Model.Classes
{
	public class ClasificacionTramites_RadicadoJSON : UltimusJson
	{
		public string Hash { get; set; }

		public long CodigoSolicitudOriginal { get; set; }

		public long CodigoSolicitudInterna { get; set; }

		public bool HabilitaRespIntegrada { get; set; }

		public Radicado Radicado { get; set; }

		public RadicadoInterno RadicadoInterno { get; set; }

		public RadicadoInterno RadicadoInternoRespuesta { get; set; }

		public Respuesta Respuesta { get; set; }

		public RespuestaDecision RespuestaDecision { get; set; }
	}
}
