using AtencionTramites.Model.ModelAtencionTramites;
using System.Collections.Generic;
using Ultimus.Interfaces;

namespace AtencionTramites.Model.Classes
{
	public class ClasificacionPeticion_JSON : UltimusJson
	{
        public string Hash { get; set; }
        public long CodigoSolicitudOriginal { get; set; }
        public ClasificacionPeticion ClasificacionPeticion { get; set; }
    }
}