namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pqrs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CodigoSolicitud { get; set; }

        public DateTime? Fecha { get; set; }

        public int? CodigoEntidad { get; set; }

        [StringLength(250)]
        public string NombreEntidad { get; set; }

        public int? CodigoSecretaria { get; set; }

        [StringLength(250)]
        public string NombreSecretaria { get; set; }

        public int? CodigoTipoTramite { get; set; }

        public bool? EsAnonimo { get; set; }

        public int? CodigoTipoSolicitante { get; set; }

        public int? CodigoTipoDocumentoIdentificacion { get; set; }

        [StringLength(250)]
        public string NumeroDocumentoIdentificacion { get; set; }

        [StringLength(250)]
        public string NombreCompleto { get; set; }

        public int? CodigoEstadoCivil { get; set; }

        public int? CodigoNivelEstudios { get; set; }

        [StringLength(250)]
        public string Correo { get; set; }

        [StringLength(250)]
        public string Telefono { get; set; }

        [StringLength(250)]
        public string Direccion { get; set; }

        public int? CodigoPais { get; set; }

        public int? CodigoDepartamento { get; set; }

        public int? CodigoCiudad { get; set; }

        public bool? Discapacidad { get; set; }

        public int? CodigoSituacionDiscapacidad { get; set; }

        public bool? GrupoEtnicoReconoce { get; set; }

        public int? CodigoGrupoEtnico { get; set; }

        [StringLength(250)]
        public string GrupoEtnicoIndigenaComunidad { get; set; }

        public bool? GrupoEtnicoIndigenaTieneCargo { get; set; }

        [StringLength(250)]
        public string GrupoEtnicoCual { get; set; }

        [StringLength(250)]
        public string GrupoEtnicoConsejoComunitario { get; set; }

        [StringLength(250)]
        public string GrupoEtnicoTerritorioColectivo { get; set; }

        public int? CodigoSexo { get; set; }

        public int? CodigoGenero { get; set; }

        public int? CodigoOrientacionSexual { get; set; }

        public int? CodigoProcedencia { get; set; }

        public int? CodigoRangoEdad { get; set; }

        [StringLength(250)]
        public string Asunto { get; set; }

        public int? CodigoMedioRedpuesta { get; set; }

        public int? CodigoTipoPqrs { get; set; }

        public string Resumen { get; set; }

        public int? CodigoSujetoEspecialProteccion { get; set; }

        [StringLength(20)]
        public string CodigoPostal { get; set; }

        public int? CodigoEstadoPqrs { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaHechos { get; set; }

        public int? CodigoDepartamentoHechos { get; set; }

        public int? CodigoMunicipioHechos { get; set; }

        public string DescripcionHechos { get; set; }

        public string DescripcionSolicitud { get; set; }

        [StringLength(50)]
        public string SistemaGenera { get; set; }

        public DateTime? FechaCreacion { get; set; }

        [StringLength(250)]
        public string NombreUsuarioCreacion { get; set; }

        [StringLength(250)]
        public string IDUsuarioCreacion { get; set; }

        public virtual Ciudad Ciudad { get; set; }

        public virtual Ciudad Ciudad1 { get; set; }

        public virtual Departamento Departamento { get; set; }

        public virtual Departamento Departamento1 { get; set; }

        public virtual EstadoCivil EstadoCivil { get; set; }

        public virtual Genero Genero { get; set; }

        public virtual GrupoEtnico GrupoEtnico { get; set; }

        public virtual MedioRespuesta MedioRespuesta { get; set; }

        public virtual NivelEstudios NivelEstudios { get; set; }

        public virtual OrientacionSexual OrientacionSexual { get; set; }

        public virtual Pais Pais { get; set; }

        public virtual Procedencia Procedencia { get; set; }

        public virtual RangoEdad RangoEdad { get; set; }

        public virtual Sexo Sexo { get; set; }

        public virtual SituacionDiscapacidad SituacionDiscapacidad { get; set; }

        public virtual SujetoEspecialProteccion SujetoEspecialProteccion { get; set; }

        public virtual TipoDocumentoIdentificacion TipoDocumentoIdentificacion { get; set; }

        public virtual TipoPqrs TipoPqrs { get; set; }

        public virtual TipoSolicitante TipoSolicitante { get; set; }

        public virtual TipoTramite TipoTramite { get; set; }
    }
}
