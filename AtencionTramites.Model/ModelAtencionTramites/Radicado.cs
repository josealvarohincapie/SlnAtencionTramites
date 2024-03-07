namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Radicado")]
    public partial class Radicado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Radicado()
        {
            DerechosClasificacion = new HashSet<DerechosClasificacion>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CodigoSolicitud { get; set; }

        public int? CodigoTipoTramite { get; set; }

        public int CodigoFuente { get; set; }

        public int? Incidente { get; set; }

        public int? Secuencial { get; set; }

        [StringLength(250)]
        public string NumeroRadicado { get; set; }

        [StringLength(250)]
        public string NumeroRadicadoTemporal { get; set; }

        public int? SecuencialDepartamental { get; set; }

        [StringLength(250)]
        public string NumeroRadicadoDepartamental { get; set; }

        public DateTime? Fecha { get; set; }

        [StringLength(250)]
        public string Remitente { get; set; }

        [StringLength(250)]
        public string Asunto { get; set; }

        [StringLength(250)]
        public string Direccion { get; set; }

        [StringLength(250)]
        public string Telefono { get; set; }

        public int? CodigoEntidad { get; set; }

        [StringLength(250)]
        public string NombreEntidad { get; set; }

        public int? CodigoSecretaria { get; set; }

        [StringLength(250)]
        public string NombreSecretaria { get; set; }

        [StringLength(250)]
        public string Correo { get; set; }

        public int? Folios { get; set; }

        [StringLength(250)]
        public string Anexos { get; set; }

        [StringLength(2000)]
        public string RutaFisicaBarcode { get; set; }

        [StringLength(2000)]
        public string RutaVirtualBarcode { get; set; }

        [StringLength(2000)]
        public string RutaFisicaBarcodeDepartamental { get; set; }

        [StringLength(2000)]
        public string RutaVirtualBarcodeDepartamental { get; set; }

        public bool? EsUrgente { get; set; }

        public int? CodigoTipoDocumento { get; set; }

        public int? CodigoSubTipoDocumento { get; set; }

        public bool? ModificaTipoDocumento { get; set; }

        public bool? EquivocacionRadicar { get; set; }

        public bool? SolicitudServidor { get; set; }

        public bool? Critico { get; set; }

        public bool? Prioritario { get; set; }

        public int? DiasVencimiento { get; set; }

        public int? HorasVencimiento { get; set; }

        public DateTime? FechaVencimiento { get; set; }

        public int? CodigoRecipienteEntidad { get; set; }

        public int? CodigoRecipienteSecretaria { get; set; }

        public int? CodigoRecipienteArea { get; set; }

        public int? CodigoRecipienteGrupo { get; set; }

        public int? CodigoRecipienteFuncionario { get; set; }

        public string DatosFuente { get; set; }

        public DateTime? FechaCreacion { get; set; }

        [StringLength(250)]
        public string NombreUsuarioCreacion { get; set; }

        [StringLength(250)]
        public string IDUsuarioCreacion { get; set; }

        [StringLength(250)]
        public string HashAprobacion { get; set; }

        [StringLength(250)]
        public string IPAprobacion { get; set; }

        public int? CodigoEstadoTarea { get; set; }

        public int? CodigoGenero { get; set; }

        public int? CodigoGrupoEtnico { get; set; }

        public int? CodigoSituacionDiscapacidad { get; set; }

        public int? CodigoSujetoEspecialProteccion { get; set; }

        public int? CodigoEstadoCivil { get; set; }

        public int? CodigoNivelEstudios { get; set; }

        public bool? Discapacidad { get; set; }

        public bool? GrupoEtnicoReconoce { get; set; }

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

        public int? CodigoOrientacionSexual { get; set; }

        public int? CodigoProcedencia { get; set; }

        public int? CodigoRangoEdad { get; set; }

        [StringLength(50)]
        public string SistemaGenera { get; set; }

        public int? CodigoTipoSolicitante { get; set; }

        public bool? EsAnonimo { get; set; }

        public int? CodigoTipoDocumentoIdentificacion { get; set; }

        [StringLength(250)]
        public string NumeroDocumentoIdentificacion { get; set; }

        public int? CodigoPais { get; set; }

        public int? CodigoDepartamento { get; set; }

        public int? CodigoCiudad { get; set; }

        public int? CodigoMedioRedpuesta { get; set; }

        public int? CodigoTipoPqrs { get; set; }

        public string Resumen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaHechos { get; set; }

        public string DescripcionHechos { get; set; }

        public string DescripcionSolicitud { get; set; }

        public int? CodigoDepartamentoHechos { get; set; }

        public int? CodigoMunicipioHechos { get; set; }

        public int? CodigoFormato { get; set; }

        public bool? PendienteValidarRespuesta { get; set; }

        public string Observaciones { get; set; }

        public virtual Ciudad Ciudad { get; set; }

        public virtual Ciudad Ciudad1 { get; set; }

        public virtual Departamento Departamento { get; set; }

        public virtual Departamento Departamento1 { get; set; }

        public virtual EstadoCivil EstadoCivil { get; set; }

        public virtual EstadoTarea EstadoTarea { get; set; }

        public virtual Formato Formato { get; set; }

        public virtual Fuente Fuente { get; set; }

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

        public virtual SubTipoDocumento SubTipoDocumento { get; set; }

        public virtual SujetoEspecialProteccion SujetoEspecialProteccion { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }

        public virtual TipoDocumentoIdentificacion TipoDocumentoIdentificacion { get; set; }

        public virtual TipoPqrs TipoPqrs { get; set; }

        public virtual TipoSolicitante TipoSolicitante { get; set; }

        public virtual TipoTramite TipoTramite { get; set; }

        public virtual ClasificacionPeticion ClasificacionPeticion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DerechosClasificacion> DerechosClasificacion { get; set; }
    }
}
