using AtencionTramites.Model.ModelAtencionTramites;
using System;
using System.Collections.Generic;
using Ultimus.Interfaces;

namespace AtencionTramites.Model.Classes
{
    public class CatalogoPostJSON : UltimusJson
    {
        public string filtro { get; set; }

        public int? CodigoEntidad { get; set; }

        public string NombreEntidad { get; set; }

        public int? CodigoSecretaria { get; set; }

        public int? CodigoArea { get; set; }

        public int? CodigoTipoTramite { get; set; }

        public int? CodigoPais { get; set; }

        public string CodigoDepartamento { get; set; }

        public int? CodigoTipoDocumento { get; set; }

        public int? CodigoSubTipoDocumento { get; set; }

        public long? CodigoSolicitudOriginal { get; set; }
    }

    public class CustomException : Exception
    {
        public CustomException(string Message) : base(Message) { }
    }
}