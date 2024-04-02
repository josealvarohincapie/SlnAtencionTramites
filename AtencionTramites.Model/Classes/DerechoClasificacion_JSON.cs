using AtencionTramites.Model.ModelAtencionTramites;
using System.Collections.Generic;
using Ultimus.Interfaces;

namespace AtencionTramites.Model.Classes
{
	public class DerechoClasificacion_JSON : UltimusJson
	{                
        public List<DerechosClasificacion> DerechosClasificacion { get; set; }
    }
}