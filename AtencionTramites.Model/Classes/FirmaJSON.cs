namespace AtencionTramites.Model.Classes
{
	public class FirmaJSON
	{
		public string Proceso { get; set; }

		public long CodigoSolicitud { get; set; }

		public string EmailUsuario { get; set; }

		public string TipoDocumento { get; set; }

		public string Documento { get; set; }

		public string RazonFirma { get; set; }

		public string Ubicacion { get; set; }

		public string UrlRespuesta { get; set; }

		public bool FirmarTodo { get; set; }

		public bool Estampa { get; set; }

		public int Posicion { get; set; }

		public string Imagen { get; set; }

		public int PosicionX { get; set; }

		public int PosicionY { get; set; }
	}
}
