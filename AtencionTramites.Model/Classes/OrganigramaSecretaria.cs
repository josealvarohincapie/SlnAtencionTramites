namespace AtencionTramites.Model.Classes
{
	public class OrganigramaSecretaria
	{
		public int CodigoSecretaria { get; set; }

		public string NombreSecretaria { get; set; }

		public string CodigoDependencia { get; set; }

		public int? CodigoIntegracionDozzier { get; set; }

		public string Correo { get; set; }

		public string CargoAprobadorRemplazo { get; set; }

		public bool Habilitado { get; set; }
	}
}
