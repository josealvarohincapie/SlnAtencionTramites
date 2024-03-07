namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notificacion")]
    public partial class Notificacion
    {
        [Key]
        public Guid CodigoNotificacion { get; set; }

        public int CodigoTipoNotificacion { get; set; }

        public DateTime FechaEnvio { get; set; }

        public virtual TipoNotificacion TipoNotificacion { get; set; }
    }
}
