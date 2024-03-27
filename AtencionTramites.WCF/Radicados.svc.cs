using AtencionTramites.Model.Classes;
using AtencionTramites.Model.DAL;
using AtencionTramites.Model.ModelAtencionTramites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Ultimus.Interfaces;
using Ultimus.Utilitarios;

namespace AtencionTramites.WCF
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]

    public class Radicados : IRadicados
    {
        private UltimusLogs logs = new UltimusLogs("Radicados");

        public Documentos_RadicadoJSON CargarDocumentosRadicado(Documentos_RadicadoJSON model)
        {
            Variables Variables = new Variables();
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    RadicadoDocumentoDAL radicadoDocumentoDAL = new RadicadoDocumentoDAL();
                    model.Documentos = radicadoDocumentoDAL.ObtenerRadicadoDocumentoList(db, model.CodigoSolicitud);
                }
                model.CodigoRespuesta = TipoCodigoRespuesta.EXITOSO.ToString();
            }
            catch (Exception ex)
            {
                model.DescripcionRespuesta = Constantes.MensajeErrorGenerico;
                model.CodigoRespuesta = TipoCodigoRespuesta.ERROR.ToString();
                logs.Error(ex);
            }
            return model;
        }

       
    }
}