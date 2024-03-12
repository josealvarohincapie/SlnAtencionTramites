namespace AtencionTramites.Model.Classes
{
	public class OrganigramaEntidad
	{
		public int CodigoEntidad { get; set; }

		public string NombreEntidad { get; set; }

		public string Departamento { get; set; }

		public string Municipio { get; set; }

		public string Sigla { get; set; }

		public int SecuencialInicio { get; set; }

		public string RutaDocumentos { get; set; }

		public string Dominio { get; set; }

		public string RecipienteNotificaciones { get; set; }

		public bool Habilitado { get; set; }
	}
}
