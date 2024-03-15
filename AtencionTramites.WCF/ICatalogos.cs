using AtencionTramites.Model.Classes;
using System.Collections.Generic;
using System.ServiceModel;
using Ultimus.Interfaces;

namespace AtencionTramites.WCF
{
    [ServiceContract]
    public interface ICatalogos
    {
        [OperationContract]
        List<JsonCatalogos> ObtenerEstratoSocioEconomico(CatalogoPostJSON model);

        [OperationContract]
        List<JsonCatalogos> ObtenerCentroPoblado(CatalogoPostJSON model);

        [OperationContract]
        List<JsonCatalogos> ObtenerExpresionGenero(CatalogoPostJSON model);

        [OperationContract]
        List<JsonCatalogos> ObtenerGrupo(CatalogoPostJSON model);

        [OperationContract]
        List<JsonCatalogos> ObtenerSubGrupo(CatalogoPostJSON model);

        [OperationContract]
        List<JsonCatalogos> ObtenerComunidad(CatalogoPostJSON model);

        [OperationContract]
        List<JsonCatalogos> ObtenerConclusionAsesoria(CatalogoPostJSON model);

        [OperationContract]
        List<JsonCatalogos> ObtenerAreaDerecho(CatalogoPostJSON model);

        [OperationContract]
        List<JsonCatalogos> ObtenerDerecho(CatalogoPostJSON model);

        [OperationContract]
        List<JsonCatalogos> ObtenerTipoPeticion(CatalogoPostJSON model);

        [OperationContract]
        List<JsonCatalogos> ObtenerDecision(CatalogoPostJSON model);
    }
}