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

        [NotMapped]
        public int? CodigoAbogado { get; set; }

        [NotMapped]
        public string NombreAbogado { get; set; }

        [NotMapped]
        public int? CodigoSecretariaRespuesta { get; set; }

        [NotMapped]
        public string NombreSecretariaRespuesta { get; set; }

        [NotMapped]
        public int? CodigoAreaRespuesta { get; set; }

        [NotMapped]
        public string NombreAreaRespuesta { get; set; }

        [NotMapped]
        public int? CodigoGrupoRespuesta { get; set; }

        [NotMapped]
        public string NombreGrupoRespuesta { get; set; }

        [NotMapped]
        public int? CodigoFuncionarioRespuesta { get; set; }

        [NotMapped]
        public string NombreFuncionarioRespuesta { get; set; }

        [NotMapped]
        public int? CodigoAbogadoRespuesta { get; set; }

        [NotMapped]
        public string NombreAbogadoRespuesta { get; set; }

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
