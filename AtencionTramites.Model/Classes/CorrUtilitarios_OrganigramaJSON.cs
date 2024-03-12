using System.Collections.Generic;
using Ultimus.Interfaces;

namespace AtencionTramites.Model.Classes
{
	public class CorrUtilitarios_OrganigramaJSON : UltimusJson
	{
		public Organigrama Organigrama { get; set; }

		public OrganigramaEntidad OrganigramaEntidad { get; set; }

		public OrganigramaSecretaria OrganigramaSecretaria { get; set; }

		public OrganigramaUsuario OrganigramaUsuario { get; set; }

		public List<OrganigramaUsuario> OrganigramaUsuarioList { get; set; }
	}
}
