namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Catalogo.Remitente")]
    public partial class Remitente
    {
        [Key]
        [StringLength(250)]
        public string Nombre { get; set; }

        public bool Habilitado { get; set; }
    }
}
