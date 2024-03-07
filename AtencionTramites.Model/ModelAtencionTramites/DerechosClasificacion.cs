namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DerechosClasificacion")]
    public partial class DerechosClasificacion
    {
        [Key]
        public long CodigoDerechoClasificacion { get; set; }

        public long CodigoSolicitud { get; set; }

        public int CodigoDerecho { get; set; }

        public DateTime FechaCreacion { get; set; }

        [Required]
        [StringLength(250)]
        public string NombreUsuarioCreacion { get; set; }

        [StringLength(250)]
        public string IDUsuarioCreacion { get; set; }

        public DateTime FechaUsuarioModifica { get; set; }

        [Required]
        [StringLength(250)]
        public string NombreUsuarioModifica { get; set; }

        public bool Habilitado { get; set; }

        public virtual Derecho Derecho { get; set; }

        public virtual Radicado Radicado { get; set; }
    }
}
