namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClasificacionPeticion")]
    public partial class ClasificacionPeticion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CodigoSolicitud { get; set; }

        public int CodigoTipoPeticion { get; set; }

        public int? CodigoAreaDerecho { get; set; }

        [Required]
        [StringLength(2048)]
        public string DescripcionAsesoria { get; set; }

        [Required]
        [StringLength(2048)]
        public string Observaciones { get; set; }

        public bool RespuestaEscrito { get; set; }

        public int? CodigoConclusionAsesoria { get; set; }

        public DateTime FechaCreacion { get; set; }

        [Required]
        [StringLength(250)]
        public string NombreUsuarioCreacion { get; set; }

        [StringLength(250)]
        public string IDUsuarioCreacion { get; set; }

        public DateTime? FechaUsuarioModifica { get; set; }

        [StringLength(250)]
        public string NombreUsuarioModifica { get; set; }

        public virtual AreaDerecho AreaDerecho { get; set; }

        public virtual ConclusionAsesoria ConclusionAsesoria { get; set; }

        public virtual TipoPeticion TipoPeticion { get; set; }

        public virtual Radicado Radicado { get; set; }
    }
}
