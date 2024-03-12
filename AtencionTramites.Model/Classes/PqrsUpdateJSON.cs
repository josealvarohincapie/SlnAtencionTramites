using System.ComponentModel.DataAnnotations;

namespace AtencionTramites.Model.Classes
{
	public class PqrsUpdateJSON
	{
		[Required(ErrorMessage = "El campo NumeroRadicado es requerido")]
		public string NumeroRadicado { get; set; }

		[Required(ErrorMessage = "El campo CodigoEstado es requerido")]
		[Range(1, int.MaxValue, ErrorMessage = "El campo CodigoEstado debe ser mayor a 0")]
		public int CodigoEstado { get; set; }

		[Required(ErrorMessage = "El campo Usuario es requerido")]
		public string Usuario { get; set; }
	}
}
