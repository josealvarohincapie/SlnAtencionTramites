using System;
using System.ComponentModel.DataAnnotations;

namespace AtencionTramites.Model.Classes
{
	public class PqrsJSON
	{
		[Required(ErrorMessage = "El campo EsAnonimo es requerido")]
		public bool? EsAnonimo { get; set; }

		[Required(ErrorMessage = "El campo CodigoSecretaria es requerido")]
		[Range(1, int.MaxValue, ErrorMessage = "El campo CodigoSecretaria debe ser mayor a 0")]
		public int? CodigoSecretaria { get; set; }

		[Required(ErrorMessage = "El campo CodigoTipoTramite es requerido")]
		[Range(1, int.MaxValue, ErrorMessage = "El campo CodigoTipoTramite debe ser mayor a 0")]
		public int? CodigoTipoTramite { get; set; }

		public int? CodigoTipoSolicitante { get; set; }

		public int? CodigoTipoDocumentoIdentificacion { get; set; }

		[RequiredIf("EsAnonimo", false, "El campo NumeroDocumentoIdentificacion es requerido")]
		public string NumeroDocumentoIdentificacion { get; set; }

		public string NombreCompleto { get; set; }

		public int? CodigoEstadoCivil { get; set; }

		public int? CodigoNivelEstudios { get; set; }

		public string Correo { get; set; }

		public string Telefono { get; set; }

		[RequiredIf("EsAnonimo", false, "El campo Direccion es requerido")]
		public string Direccion { get; set; }

		public int? CodigoPais { get; set; }

		[RequiredIf("EsAnonimo", false, "El campo CodigoDepartamento es requerido")]
		[RangeIf(1, int.MaxValue, "EsAnonimo", false, "El campo CodigoDepartamento debe ser mayor a 0")]
		public int? CodigoDepartamento { get; set; }

		[RequiredIf("EsAnonimo", false, "El campo CodigoCiudad es requerido")]
		[RangeIf(1, int.MaxValue, "EsAnonimo", false, "El campo CodigoCiudad debe ser mayor a 0")]
		public int? CodigoCiudad { get; set; }

		public bool? Discapacidad { get; set; }

		public bool? GrupoEtnicoReconoce { get; set; }

		public int? CodigoGrupoEtnico { get; set; }

		public string GrupoEtnicoIndigenaComunidad { get; set; }

		public bool? GrupoEtnicoIndigenaTieneCargo { get; set; }

		public string GrupoEtnicoCual { get; set; }

		public string GrupoEtnicoConsejoComunitario { get; set; }

		public string GrupoEtnicoTerritorioColectivo { get; set; }

		public int? CodigoSexo { get; set; }

		public int? CodigoGenero { get; set; }

		public int? CodigoOrientacionSexual { get; set; }

		public int? CodigoProcedencia { get; set; }

		public int? CodigoRangoEdad { get; set; }

		[RequiredIf("CodigoTipoTramite", 1, "El campo Asunto es requerido")]
		public string Asunto { get; set; }

		public int? CodigoMedioRedpuesta { get; set; }

		[RequiredIf("CodigoTipoTramite", 1, "El campo Resumen es requerido")]
		public string Resumen { get; set; }

		[RequiredIf("CodigoTipoTramite", 2, "El campo FechaHechos es requerido")]
		public DateTime? FechaHechos { get; set; }

		[RequiredIf("CodigoTipoTramite", 2, "El campo CodigoDepartamentoHechos es requerido")]
		[RangeIf(1, int.MaxValue, "CodigoTipoTramite", 2, "El campo CodigoDepartamentoHechos debe ser mayor a 0")]
		public int? CodigoDepartamentoHechos { get; set; }

		[RequiredIf("CodigoTipoTramite", 2, "El campo CodigoMunicipioHechos es requerido")]
		[RangeIf(1, int.MaxValue, "CodigoTipoTramite", 2, "El campo CodigoMunicipioHechos debe ser mayor a 0")]
		public int? CodigoMunicipioHechos { get; set; }

		[RequiredIf("CodigoTipoTramite", 2, "El campo DescripcionHechos es requerido")]
		public string DescripcionHechos { get; set; }

		[RequiredIf("CodigoTipoTramite", 2, "El campo DescripcionSolicitud es requerido")]
		public string DescripcionSolicitud { get; set; }

		[Required(ErrorMessage = "El campo Usuario es requerido")]
		public string Usuario { get; set; }

		[Required(ErrorMessage = "El campo NombreCompletoUsuario es requerido")]
		public string NombreCompletoUsuario { get; set; }

		[Required(ErrorMessage = "El campo NumeroRUP es requerido")]
		public string NumeroRUP { get; set; }
	}
}
