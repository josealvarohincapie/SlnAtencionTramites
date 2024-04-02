using System.ServiceModel;
using AtencionTramites.Model.Classes;

namespace AtencionTramites.WCF
{
    [ServiceContract]
    internal interface IClasificacionTramites
    {
        [OperationContract]
        ClasificacionTramites_RadicadoJSON Radicado_Cargar(ClasificacionTramites_RadicadoJSON model);

		[OperationContract]
        Documentos_RadicadoJSON CargarDocumentosRadicado(Documentos_RadicadoJSON model);
		
		[OperationContract]
        ClasificacionTramites_SeguimientoJSON ClasificacionTramiteSeguimiento_Cargar(ClasificacionTramites_SeguimientoJSON model);
        [OperationContract]
		ClasificacionPeticion_JSON CargarClasificacionPeticion(ClasificacionPeticion_JSON model);
        
        [OperationContract]
        ClasificacionPeticion_JSON GuardarClasificacionPeticion(ClasificacionPeticion_JSON model);

        [OperationContract]
        DerechoClasificacion_JSON GuardarDerechosClasificacion(DerechoClasificacion_JSON model);
    }
}