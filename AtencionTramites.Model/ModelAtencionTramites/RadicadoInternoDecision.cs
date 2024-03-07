namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RadicadoInternoDecision")]
    public partial class RadicadoInternoDecision
    {
        [Key]
        public Guid CodigoRadicadoInternoDecision { get; set; }

        public long CodigoSolicitud { get; set; }

        [Required]
        [StringLength(250)]
        public string Proceso { get; set; }

        public int Incidente { get; set; }

        [Required]
        [StringLength(250)]
        public string UserID { get; set; }

        [Required]
        [StringLength(250)]
        public string UserFullName { get; set; }

        [Required]
        [StringLength(250)]
        public string Etapa { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public int CodigoDecision { get; set; }

        [StringLength(250)]
        public string Comentarios { get; set; }

        [Required]
        [StringLength(250)]
        public string Hash { get; set; }

        [Required]
        [StringLength(250)]
        public string IP { get; set; }

        [StringLength(250)]
        public string JobFunction { get; set; }

        public virtual Decision Decision { get; set; }
    }
}
