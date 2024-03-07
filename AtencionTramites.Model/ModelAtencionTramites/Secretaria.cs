namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Catalogo.Secretaria")]
    public partial class Secretaria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codigo { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string CodigoDependencia { get; set; }

        public int? CodigoIntegracionDozzier { get; set; }

        [StringLength(250)]
        public string Correo { get; set; }

        [StringLength(250)]
        public string CargoAprobadorRemplazo { get; set; }

        public string Contacto { get; set; }

        public bool? EsRegional { get; set; }

        public bool Habilitado { get; set; }
    }
}
