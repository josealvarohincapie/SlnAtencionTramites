namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Respuesta")]
    public partial class Respuesta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CodigoSolicitud { get; set; }

        public long? CodigoSolicitudOriginal { get; set; }

        public long? CodigoSolicitudInterna { get; set; }

        public int? Incidente { get; set; }

        public int? Secuencial { get; set; }

        [StringLength(250)]
        public string NumeroRadicado { get; set; }

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
        public string Ciudad { get; set; }

        [StringLength(250)]
        public string Correo { get; set; }

        public int? Folios { get; set; }

        [StringLength(250)]
        public string Anexos { get; set; }

        [StringLength(2000)]
        public string RutaFisicaDocumento { get; set; }

        [StringLength(2000)]
        public string RutaVirtualDocumento { get; set; }

        public int? IdDocumentoFirmado { get; set; }

        public string UrlParaFirma { get; set; }

        public bool? DocumentoFirmado { get; set; }

        [StringLength(2000)]
        public string RutaFisicaDocumentoSinFirma { get; set; }

        [StringLength(2000)]
        public string RutaVirtualDocumentoSinFirma { get; set; }

        public bool? EsUrgente { get; set; }

        public bool? ResponderConCorreo { get; set; }

        public string AsuntoDocumento { get; set; }

        public string CuerpoDocumento { get; set; }

        public int? CodigoFormato { get; set; }

        public int? CodigoRecipienteSecretaria { get; set; }

        public int? CodigoRecipienteFuncionario { get; set; }

        public int? CodigoRecipienteAbogado { get; set; }

        [StringLength(250)]
        public string NumeroGuia { get; set; }

        public bool? Entregado { get; set; }

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

        [StringLength(50)]
        public string NombreUsuarioRevisar { get; set; }

        [StringLength(50)]
        public string IDUsuarioRevisar { get; set; }

        [StringLength(50)]
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

        public bool? FirmaFisica { get; set; }

        [StringLength(100)]
        public string EmpresaTransportadora { get; set; }

        [StringLength(2000)]
        public string RutaFisicaBarcode { get; set; }

        [StringLength(2000)]
        public string RutaVirtualBarcode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Telefono { get; set; }

        [StringLength(100)]
        public string Direccion { get; set; }

        public int? CodigoFuncionario { get; set; }

        [StringLength(100)]
        public string Funcionario { get; set; }

        [StringLength(250)]
        public string NombreDefensor { get; set; }

        public int? CodigoDefensor { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaCita { get; set; }

        [StringLength(10)]
        public string HoraCita { get; set; }

        public bool? HabilitaRespIntegrada { get; set; }

        public int? CodigoFinalizacion { get; set; }

        public string CuerpoEmail { get; set; }

        public virtual EstadoTarea EstadoTarea { get; set; }

        public virtual Formato Formato { get; set; }
    }
}
