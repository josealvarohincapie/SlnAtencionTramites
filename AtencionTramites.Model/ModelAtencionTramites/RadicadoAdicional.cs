namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RadicadoAdicional")]
    public partial class RadicadoAdicional
    {
        [Key]
        public Guid CodigoRadicadoAdicional { get; set; }

        public long CodigoSolicitud { get; set; }

        public int? CodigoSecretaria { get; set; }

        [StringLength(250)]
        public string NombreSecretaria { get; set; }

        [StringLength(250)]
        public string Correo { get; set; }

        public bool? SoloLectura { get; set; }
    }
}
