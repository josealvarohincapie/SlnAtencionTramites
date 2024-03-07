namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Catalogo.Letra")]
    public partial class Letra
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string Codigo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1)]
        public string Nombre { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Habilitado { get; set; }
    }
}
