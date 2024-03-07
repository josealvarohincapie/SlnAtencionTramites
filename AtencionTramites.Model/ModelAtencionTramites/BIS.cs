namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Catalogo.BIS")]
    public partial class BIS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codigo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Habilitado { get; set; }
    }
}
