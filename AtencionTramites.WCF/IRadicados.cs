using System.ServiceModel;
using AtencionTramites.Model.Classes;

namespace AtencionTramites.WCF
{
    [ServiceContract]
    internal interface IRadicados
    {
        [OperationContract]
        Documentos_RadicadoJSON CargarDocumentosRadicado(Documentos_RadicadoJSON model);        
    }
}