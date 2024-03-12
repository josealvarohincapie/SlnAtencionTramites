using System;

namespace AtencionTramites.Model.Classes
{
	public class ValidarRadicado
	{
		public bool Resultado { get; set; }

		public string Hash { get; set; }

		public string CodigoArchivo { get; set; }

		public string NombreArchivo { get; set; }

		public string Proceso { get; set; }

		public int? Incidente { get; set; }

		public string NumeroRadicado { get; set; }

		public string UserFullName { get; set; }

		public string Etapa { get; set; }

		public DateTime? Fecha { get; set; }

		public string Decision { get; set; }

		public string IP { get; set; }
	}
}
