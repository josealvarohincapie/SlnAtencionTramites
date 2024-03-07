namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RespuestaAdicional")]
    public partial class RespuestaAdicional
    {
        [Key]
        public Guid CodigoRespuestaAdicional { get; set; }

        public long CodigoSolicitud { get; set; }

        [StringLength(250)]
        public string Calificativo { get; set; }

        [StringLength(250)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string Cargo { get; set; }

        [StringLength(250)]
        public string Entidad { get; set; }

        [StringLength(250)]
        public string Ciudad { get; set; }

        [StringLength(250)]
        public string Correo { get; set; }

        public long? CodigoSolicitudOriginal { get; set; }

        public string NombreSolicitudOriginal { get; set; }
    }
}
