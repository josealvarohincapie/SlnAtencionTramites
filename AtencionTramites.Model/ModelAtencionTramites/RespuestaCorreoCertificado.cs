namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RespuestaCorreoCertificado")]
    public partial class RespuestaCorreoCertificado
    {
        [Key]
        public Guid CodigoRespuestaCorreoCertificado { get; set; }

        public long CodigoSolicitud { get; set; }

        public int CodigoTipoCorreo { get; set; }

        public long IdMensaje { get; set; }

        [StringLength(1000)]
        public string Asunto { get; set; }

        public string Cuerpo { get; set; }

        [StringLength(250)]
        public string NombreDestinatario { get; set; }

        [StringLength(250)]
        public string CorreoDestinatario { get; set; }

        public string Adjunto { get; set; }

        [StringLength(250)]
        public string NombreAdjunto { get; set; }

        public bool? Entregado { get; set; }

        [StringLength(2000)]
        public string RutaFisicaDocumento { get; set; }

        [StringLength(2000)]
        public string RutaVirtualDocumento { get; set; }

        public DateTime FechaCreacion { get; set; }

        [Required]
        [StringLength(250)]
        public string NombreUsuarioCreacion { get; set; }

        [Required]
        [StringLength(250)]
        public string IDUsuarioCreacion { get; set; }

        public virtual TipoCorreo TipoCorreo { get; set; }
    }
}
