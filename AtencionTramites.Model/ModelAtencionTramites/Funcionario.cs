namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Catalogo.Funcionario")]
    public partial class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codigo { get; set; }

        [StringLength(250)]
        public string Cedula { get; set; }

        [Required]
        [StringLength(250)]
        public string Correo { get; set; }

        [Required]
        [StringLength(250)]
        public string Usuario { get; set; }

        [StringLength(250)]
        public string Firma { get; set; }

        public bool Habilitado { get; set; }
    }
}
