namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RadicadoDecision")]
    public partial class RadicadoDecision
    {
        [NotMapped]
        public string NombreDecision { get; set; }

        [NotMapped]
        public int? CodigoSecretaria { get; set; }

        [NotMapped]
        public string NombreSecretaria { get; set; }

        [NotMapped]
        public int? CodigoArea { get; set; }

        [NotMapped]
        public string NombreArea { get; set; }

        [NotMapped]
        public int? CodigoGrupo { get; set; }

        [NotMapped]
        public string NombreGrupo { get; set; }

        [NotMapped]
        public int? CodigoFuncionario { get; set; }

        [NotMapped]
        public string NombreFuncionario { get; set; }

        [Key]
        public Guid CodigoRadicadoDecision { get; set; }

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
