namespace AtencionTramites.Model.Classes
{
	public class OrganigramaUsuario
	{
		public int CodigoUsuario { get; set; }

		public string NombreUsuario { get; set; }

		public string NombreCompleto { get; set; }

		public string Cargo { get; set; }

		public string Cedula { get; set; }

		public string Correo { get; set; }

		public string Firma { get; set; }

		public bool CorrExtRecibida { get; set; }

		public bool CorrExtEnviada { get; set; }

		public bool CorrInterna { get; set; }
	}
}
