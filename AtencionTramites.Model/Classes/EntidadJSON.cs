using AtencionTramites.Model.ModelAtencionTramites;
using Ultimus.Interfaces;

namespace AtencionTramites.Model.Classes
{
    public class EntidadJSON : UltimusJson
    {
        public string NombreEntidad { get; set; }

        public Entidad Entidad { get; set; }
    }
}