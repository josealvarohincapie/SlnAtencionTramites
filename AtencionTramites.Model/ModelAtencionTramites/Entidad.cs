namespace AtencionTramites.Model.ModelAtencionTramites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Catalogo.Entidad")]
    public partial class Entidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codigo { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string Departamento { get; set; }

        [Required]
        [StringLength(250)]
        public string Municipio { get; set; }

        [Required]
        [StringLength(5)]
        public string Sigla { get; set; }

        public int SecuencialInicio { get; set; }

        [Required]
        [StringLength(250)]
        public string RutaDocumentos { get; set; }

        [Required]
        [StringLength(250)]
        public string Dominio { get; set; }

        public bool? Pop3EnableSsl { get; set; }

        public int? Pop3Port { get; set; }

        [StringLength(250)]
        public string Pop3Server { get; set; }

        [StringLength(250)]
        public string Pop3Password { get; set; }

        [StringLength(250)]
        public string Pop3Email { get; set; }

        public bool? SmtpEnableSsl { get; set; }

        public int? SmtpPort { get; set; }

        [StringLength(250)]
        public string SmtpServer { get; set; }

        [StringLength(250)]
        public string SmtpUsername { get; set; }

        [StringLength(250)]
        public string SmtpPassword { get; set; }

        [StringLength(250)]
        public string SmtpEmail { get; set; }

        [StringLength(250)]
        public string RecipienteNotificaciones { get; set; }

        public bool Habilitado { get; set; }
    }
}
