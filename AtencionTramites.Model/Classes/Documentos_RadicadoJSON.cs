using AtencionTramites.Model.ModelAtencionTramites;
using System.Collections.Generic;
using Ultimus.Interfaces;

namespace AtencionTramites.Model.Classes
{
	public class Documentos_RadicadoJSON : UltimusJson
	{
        public string Hash { get; set; }
        public long CodigoSolicitudOriginal { get; set; }
        public List<RadicadoDocumento> Documentos { get; set; }
    }
}