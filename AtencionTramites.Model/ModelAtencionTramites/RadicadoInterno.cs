namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RadicadoInterno")]
    public partial class RadicadoInterno
    {
        [NotMapped]
        public string NombreFormato { get; set; }

        [NotMapped]
        public string NombreTipoOficio { get; set; }

        [NotMapped]
        public string NombreEstadoTarea { get; set; }

        [NotMapped]
        public List<RadicadoInternoAdicional> RadicadoInternoAdicional { get; set; }

        [NotMapped]
        public List<RadicadoInternoDocumento> RadicadoInternoDocumento { get; set; }

        [NotMapped]
        public bool Descartado { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CodigoSolicitud { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoTipo { get; set; }

        public long? CodigoSolicitudOriginal { get; set; }

        public long? CodigoSolicitudInterna { get; set; }

        public int? Incidente { get; set; }

        public int? Secuencial { get; set; }

        [StringLength(250)]
        public string NumeroRadicado { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public int? CodigoEntidad { get; set; }

        [StringLength(250)]
        public string NombreEntidad { get; set; }

        public int? CodigoSecretaria { get; set; }

        [StringLength(250)]
        public string NombreSecretaria { get; set; }

        [StringLength(250)]
        public string Calificativo { get; set; }

        [StringLength(250)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string Cargo { get; set; }

        [StringLength(250)]
        public string Correo { get; set; }

        [StringLength(2000)]
        public string RutaFisicaDocumento { get; set; }

        [StringLength(2000)]
        public string RutaVirtualDocumento { get; set; }

        public string AsuntoDocumento { get; set; }

        public string CuerpoDocumento { get; set; }

        public int? CodigoFormato { get; set; }

        public int? CodigoTipoOficio { get; set; }

        public int? CodigoRecipienteSecretaria { get; set; }

        public int? CodigoRecipienteArea { get; set; }

        public int? CodigoRecipienteGrupo { get; set; }

        public int? CodigoRecipienteFuncionario { get; set; }

        public int? CodigoRecipienteAbogado { get; set; }

        public int? CodigoSecretariaSolicitarInformaciones { get; set; }

        [StringLength(250)]
        public string NombreSecretariaSolicitarInformaciones { get; set; }

        public DateTime? FechaCreacion { get; set; }

        [StringLength(250)]
        public string NombreUsuarioCreacion { get; set; }

        [StringLength(250)]
        public string IDUsuarioCreacion { get; set; }

        public DateTime? FechaProyectar { get; set; }

        [StringLength(250)]
        public string NombreUsuarioProyectar { get; set; }

        [StringLength(250)]
        public string IDUsuarioProyectar { get; set; }

        [StringLength(50)]
        public string CodigoFirmaUsuarioProyectar { get; set; }

        public DateTime? FechaRevisar { get; set; }

        [StringLength(250)]
        public string NombreUsuarioRevisar { get; set; }

        [StringLength(250)]
        public string IDUsuarioRevisar { get; set; }

        [StringLength(10)]
        public string CodigoFirmaUsuarioRevisar { get; set; }

        public DateTime? FechaAprobacion { get; set; }

        [StringLength(250)]
        public string NombreUsuarioAprobacion { get; set; }

        [StringLength(250)]
        public string IDUsuarioAprobacion { get; set; }

        [StringLength(250)]
        public string CargoUsuarioAprobacion { get; set; }

        [StringLength(50)]
        public string CodigoFirmaUsuarioAprobacion { get; set; }

        [StringLength(250)]
        public string HashAprobacion { get; set; }

        [StringLength(250)]
        public string IPAprobacion { get; set; }

        public int? CodigoEstadoTarea { get; set; }

        public virtual EstadoTarea EstadoTarea { get; set; }

        public virtual Formato Formato { get; set; }

        public virtual TipoOficio TipoOficio { get; set; }
    }
}
