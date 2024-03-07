namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Catalogo.Derecho")]
    public partial class Derecho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Derecho()
        {
            DerechosClasificacion = new HashSet<DerechosClasificacion>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codigo { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

        public bool Habilitado { get; set; }

        public int CodigoAreaDerecho { get; set; }

        public virtual AreaDerecho AreaDerecho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DerechosClasificacion> DerechosClasificacion { get; set; }
    }
}
