using AtencionTramites.Model.Classes;
using System.ServiceModel;

namespace AtencionTramites.WCF
{
    [ServiceContract]
    [CustomContractBehaviorAttribute]
    public interface IClasificacionTramites
    {
        [OperationContract]
        ClasificacionTramites_RadicadoJSON Radicado_Cargar(ClasificacionTramites_RadicadoJSON model);

        [OperationContract]
        ClasificacionTramites_RadicadoJSON Radicado_Guardar(ClasificacionTramites_RadicadoJSON model);

        [OperationContract]
        ClasificacionTramites_RadicadoJSON Radicado_Descartar(ClasificacionTramites_RadicadoJSON model);

        [OperationContract]
        long GuardarRadicadoPadre(RadicadoPadre model);

        [OperationContract]
        ClasificacionTramites_SeguimientoJSON Seguimiento_Cargar(ClasificacionTramites_SeguimientoJSON model);
    }
}