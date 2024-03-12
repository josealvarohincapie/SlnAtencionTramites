using System;

namespace AtencionTramites.Model.Classes
{
	public class RadicadoTramite
	{
		public int Incidente { get; set; }

		public string NumeroRadicado { get; set; }

		public string NombreSecretaria { get; set; }

		public DateTime FechaCreacion { get; set; }

		public string Remitente { get; set; }

		public string Asunto { get; set; }

		public string Etapa { get; set; }

		public string Proceso { get; set; }

		public string Usuario { get; set; }
	}
}
