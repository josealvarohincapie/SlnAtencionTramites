namespace AtencionTramites.Model.Classes
{
	public class Organigrama
	{
		public bool EsAdministrador { get; set; }

		public int? CodigoEntidad { get; set; }

		public string NombreEntidad { get; set; }

		public int? CodigoSecretaria { get; set; }

		public string NombreSecretaria { get; set; }

		public int? CodigoGrupo { get; set; }

		public string NombreGrupo { get; set; }
	}
}
