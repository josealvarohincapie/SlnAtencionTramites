namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RadicadoInternoAdicional")]
    public partial class RadicadoInternoAdicional
    {
        [Key]
        public Guid CodigoRadicadoInternoAdicional { get; set; }

        public long CodigoSolicitud { get; set; }

        public int CodigoTipo { get; set; }

        public int? CodigoSecretariaSolicitarInformaciones { get; set; }

        [StringLength(250)]
        public string NombreSecretariaSolicitarInformaciones { get; set; }

        [StringLength(250)]
        public string Calificativo { get; set; }

        [StringLength(250)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string Cargo { get; set; }

        [StringLength(250)]
        public string Correo { get; set; }

        [StringLength(2000)]
        public string RutaFisicaDocumento { get; set; }

        [StringLength(2000)]
        public string RutaVirtualDocumento { get; set; }
    }
}
