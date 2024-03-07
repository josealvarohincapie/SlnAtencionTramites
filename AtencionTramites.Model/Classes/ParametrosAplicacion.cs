using Ultimus.Utilitarios;

namespace AtencionTramites.Model.Classes
{
    public class ParametrosAplicacion
    {
        public string DbAtencionTramites { get { return new ObtieneParametros("AtencionTramites").GetValueKeyRegedit("DbAtencionTramites", true); } set { } }
    }
}