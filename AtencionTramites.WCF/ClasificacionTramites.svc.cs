using AtencionTramites.Model.Classes;
using AtencionTramites.Model.DAL;
using AtencionTramites.Model.ModelAtencionTramites;
using AtencionTramites.WCF.Classes;
using AtencionTramites.WCF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Ultimus.Interfaces;
using Ultimus.Interfaces.UltimusForm;
using Ultimus.Utilitarios;
using System.Web;
using TipoCodigoRespuesta = Ultimus.Interfaces.TipoCodigoRespuesta;

namespace AtencionTramites.WCF
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]

    public class ClasificacionTramites : IClasificacionTramites
    {
        private UltimusLogs logs = new UltimusLogs("ClasificacionTramites");

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ClasificacionTramites_RadicadoJSON Radicado_Cargar(ClasificacionTramites_RadicadoJSON model)
        {
            Variables Variables = new Variables();
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    RadicadoDAL RadicadoDAL = new RadicadoDAL();
                    RadicadoInternoDAL RadicadoInternoDAL = new RadicadoInternoDAL();
                    RespuestaDAL RespuestaDAL = new RespuestaDAL();
                    model.Radicado = RadicadoDAL.ObtenerRadicado(db, model.CodigoSolicitudOriginal);
					model.Radicado.ClasificacionPeticion = ObtenerClasificacionPeticion(model.CodigoSolicitudOriginal);
                    model.Radicado.DerechosClasificacion = ObtenerDerechosClasificacion(model.CodigoSolicitudOriginal);
                    model.RadicadoInterno = RadicadoInternoDAL.ObtenerRadicadoInterno(db, model.CodigoSolicitudInterna, 1);
                    model.RadicadoInternoRespuesta = RadicadoInternoDAL.ObtenerRadicadoInterno(db, model.CodigoSolicitudInterna, 2);
                    model.Respuesta = RespuestaDAL.ObtenerRespuesta(db, model.CodigoSolicitud);
                    if (model.Respuesta == null)
                    {
                        model.Respuesta = new Respuesta();
                        if (model.Radicado == null)
                        {
                            UltimusDAL ultimusDAL = new UltimusDAL();
                            DEPARTMENTS Entidad = ultimusDAL.ObtenerEntidadUsuario(model.UltimusUserID);
                            if (Entidad != null)
                            {
                                model.Respuesta.CodigoEntidad = Entidad.ID;
                                model.Respuesta.NombreEntidad = Entidad.NAME;
                            }
                            DEPARTMENTS Secretaria = ultimusDAL.ObtenerSecretariaUsuario(model.UltimusUserID);
                            if (Secretaria != null)
                            {
                                model.Respuesta.CodigoSecretaria = Secretaria.ID;
                                model.Respuesta.NombreSecretaria = Secretaria.NAME;
                            }
                            model.Respuesta.HabilitaRespIntegrada = false;
                        }
                        else
                        {
                            model.Respuesta.CodigoEntidad = model.Radicado.CodigoEntidad;
                            model.Respuesta.NombreEntidad = model.Radicado.NombreEntidad;
                            model.Respuesta.CodigoSecretaria = model.Radicado.CodigoSecretaria;
                            model.Respuesta.NombreSecretaria = model.Radicado.NombreSecretaria;
                            model.Respuesta.Nombre = model.Radicado.Remitente;
                            model.Respuesta.Correo = model.Radicado.Correo;
                            model.Respuesta.CodigoFormato = model.Radicado.CodigoFormato;
                            model.Respuesta.NombreFormato = model.Radicado.NombreFormato;
                            model.Respuesta.CodigoTipoDocumento = model.Radicado.CodigoTipoDocumento;
                            model.Respuesta.CodigoSubTipoDocumento = model.Radicado.CodigoSubTipoDocumento;
                            List<TipoDocumentoRespuestaIntegrada> habilitados2 = db.TipoDocumentoRespuestaIntegrada.AsNoTracking().ToList();
                            model.Respuesta.HabilitaRespIntegrada = habilitados2.Exists((TipoDocumentoRespuestaIntegrada q) => q.CodigoTipoDocumento == model.Radicado.CodigoTipoDocumento && (q.CodigoSubTipoDocumento == model.Radicado.CodigoSubTipoDocumento || q.CodigoSubTipoDocumento == 0));
                        }
                    }
                    else if (model.Radicado != null)
                    {
                        model.Respuesta.CodigoTipoDocumento = model.Radicado.CodigoTipoDocumento;
                        model.Respuesta.CodigoSubTipoDocumento = model.Radicado.CodigoSubTipoDocumento;
                        if (!model.Respuesta.CodigoEntidad.HasValue)
                        {
                            model.Respuesta.CodigoEntidad = model.Radicado.CodigoEntidad;
                            model.Respuesta.NombreEntidad = model.Radicado.NombreEntidad;
                            model.Respuesta.CodigoSecretaria = model.Radicado.CodigoSecretaria;
                            model.Respuesta.NombreSecretaria = model.Radicado.NombreSecretaria;
                            model.Respuesta.Nombre = model.Radicado.Remitente;
                            model.Respuesta.Correo = model.Radicado.Correo;
                            model.Respuesta.CodigoFormato = model.Radicado.CodigoFormato;
                            model.Respuesta.NombreFormato = model.Radicado.NombreFormato;
                            model.Respuesta.CodigoTipoDocumento = model.Radicado.CodigoTipoDocumento;
                            model.Respuesta.CodigoSubTipoDocumento = model.Radicado.CodigoSubTipoDocumento;
                            List<TipoDocumentoRespuestaIntegrada> habilitados = db.TipoDocumentoRespuestaIntegrada.AsNoTracking().ToList();
                            model.Respuesta.HabilitaRespIntegrada = habilitados.Exists((TipoDocumentoRespuestaIntegrada q) => q.CodigoTipoDocumento == model.Radicado.CodigoTipoDocumento && (q.CodigoSubTipoDocumento == model.Radicado.CodigoSubTipoDocumento || q.CodigoSubTipoDocumento == 0));
                        }
                    }
                    //if (model.UltimusStep == Constantes.ClasificacionTramites.Etapas.AnalisisPeticionClasificacion.Nombre)
                    //{
                    //    string host = HttpContext.Current.Request.Url.Host;
                    //    string serviceDomain = new Uri(Variables.FirmaElectronicaApi).Host;
                    //    string tipoDocumento = ((host == serviceDomain) ? 1.ToString() : 2.ToString());
                    //    if (!model.Respuesta.DocumentoFirmado.HasValue || !model.Respuesta.DocumentoFirmado.Value)
                    //    {
                    //        //new FirmaElectronicaInterface();
                    //        //string documento = FirmaElectronicaInterface.CargarDocumentoFirmado(tipoDocumento, model.Respuesta.IdDocumentoFirmado.Value);
                    //        if (tipoDocumento == 1.ToString() && !string.IsNullOrEmpty(documento))
                    //        {
                    //            string path2 = Variables.UltimusAttachmentPath + Variables.CorrExtEnviada_NombreProceso + "\\" + Constantes.CarpetaGenerados;
                    //            string destinationFile2 = path2 + "\\" + Path.GetFileName(documento);
                    //            if (!Directory.Exists(path2))
                    //            {
                    //                Directory.CreateDirectory(path2);
                    //            }
                    //            //File.Copy(documento, destinationFile2, overwrite: true);
                    //            model.Respuesta.RutaFisicaDocumentoSinFirma = model.Respuesta.RutaFisicaDocumento;
                    //            model.Respuesta.RutaVirtualDocumentoSinFirma = model.Respuesta.RutaVirtualDocumento;
                    //            model.Respuesta.RutaFisicaDocumento = destinationFile2;
                    //            model.Respuesta.RutaVirtualDocumento = Variables.UltimusAttachmentUrl + Variables.CorrExtEnviada_NombreProceso + "/" + Constantes.CarpetaGenerados + "/" + Path.GetFileName(destinationFile2);
                    //            model.Respuesta.DocumentoFirmado = true;
                    //            RespuestaDAL.ActualizarRecepcionFirma(db, model.Respuesta);
                    //            //File.Delete(documento);
                    //        }
                    //        //if (tipoDocumento == 2.ToString() && !string.IsNullOrEmpty(documento))
                    //        //{
                    //        //    //byte[] bytes = Convert.FromBase64String(documento);
                    //        //    string nombre = Guid.NewGuid().ToString();
                    //        //    string path = Variables.UltimusAttachmentPath + Variables.CorrExtEnviada_NombreProceso + "\\" + Constantes.CarpetaGenerados;
                    //        //    string destinationFile = path + "\\" + nombre + ".pdf";
                    //        //    if (!Directory.Exists(path))
                    //        //    {
                    //        //        Directory.CreateDirectory(path);
                    //        //    }
                    //        //    BinaryWriter binaryWriter = new BinaryWriter(new FileStream(destinationFile, FileMode.CreateNew));
                    //        //    binaryWriter.Write(bytes, 0, bytes.Length);
                    //        //    binaryWriter.Close();
                    //        //    model.Respuesta.RutaFisicaDocumentoSinFirma = model.Respuesta.RutaFisicaDocumento;
                    //        //    model.Respuesta.RutaVirtualDocumentoSinFirma = model.Respuesta.RutaVirtualDocumento;
                    //        //    model.Respuesta.RutaFisicaDocumento = destinationFile;
                    //        //    model.Respuesta.RutaVirtualDocumento = Variables.UltimusAttachmentUrl + Variables.CorrExtEnviada_NombreProceso + "/" + Constantes.CarpetaGenerados + "/" + Path.GetFileName(destinationFile);
                    //        //    model.Respuesta.DocumentoFirmado = true;
                    //        //    RespuestaDAL.ActualizarRecepcionFirma(db, model.Respuesta);
                    //        //}
                    //    }
                    //}
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

        public Documentos_RadicadoJSON CargarDocumentosRadicado(Documentos_RadicadoJSON model)
        {
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    RadicadoDocumentoDAL radicadoDocumentoDAL = new RadicadoDocumentoDAL();
                    model.Documentos = radicadoDocumentoDAL.ObtenerRadicadoDocumentoList(db, model.CodigoSolicitudOriginal);
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

        public List<DerechosClasificacion> ObtenerDerechosClasificacion(long codigoSolicitudOriginal)
        {
            List<DerechosClasificacion> derechosClasificacion = null;
            try
            {

                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    DerechoClasificacionDAL derechoClasificacionDAL = new DerechoClasificacionDAL();

                    derechosClasificacion = derechoClasificacionDAL.ObtenerDerechosClasificacion(db, codigoSolicitudOriginal);
                }
            }
            catch (Exception ex)
            {
                logs.Error(ex);
            }

            return derechosClasificacion;
        }

        public ClasificacionPeticion ObtenerClasificacionPeticion(long codigoSolicitudOriginal)
        {
            ClasificacionPeticion clasificacionPeticion = null;
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    ClasificacionPeticionDAL clasificacionPeticionDAL = new ClasificacionPeticionDAL();

                    clasificacionPeticion = clasificacionPeticionDAL.ObtenerClasificacionPeticion(db, codigoSolicitudOriginal);
                }                
            }
            catch (Exception ex)
            {                
                logs.Error(ex);
            }

            return clasificacionPeticion;
        }

        public ClasificacionPeticion_JSON CargarClasificacionPeticion(ClasificacionPeticion_JSON model)
        {
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    ClasificacionPeticionDAL clasificacionPeticionDAL = new ClasificacionPeticionDAL();

                    model.ClasificacionPeticion = clasificacionPeticionDAL.ObtenerClasificacionPeticion(db, model.CodigoSolicitudOriginal);
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

        public ClasificacionPeticion_JSON GuardarClasificacionPeticion(ClasificacionPeticion_JSON model)
        {
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    model.CodigoRespuesta = TipoCodigoRespuesta.EXITOSO.ToString();
                }
            }
            catch (Exception ex)
            {
                model.DescripcionRespuesta = Constantes.MensajeErrorGenerico;
                model.CodigoRespuesta = TipoCodigoRespuesta.ERROR.ToString();
                logs.Error(ex);
            }
            return model;
        }

        public DerechoClasificacion_JSON GuardarDerechosClasificacion(DerechoClasificacion_JSON model) 
        {
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    DerechoClasificacionDAL derechoClasificacionDAL = new DerechoClasificacionDAL();
                    derechoClasificacionDAL.GuardarDerechosClasificacion(db, model.DerechosClasificacion[0]);
                    
                    model.DerechosClasificacion = derechoClasificacionDAL.ObtenerDerechosClasificacion(db, model.CodigoSolicitud);
                    model.CodigoRespuesta = TipoCodigoRespuesta.EXITOSO.ToString();
                }
            }
            catch (Exception ex)
            {
                model.DescripcionRespuesta = Constantes.MensajeErrorGenerico;
                model.CodigoRespuesta = TipoCodigoRespuesta.ERROR.ToString();
                logs.Error(ex);
            }
            return model;
        }
		public ClasificacionTramites_SeguimientoJSON ClasificacionTramiteSeguimiento_Cargar(ClasificacionTramites_SeguimientoJSON model)
        {
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    ClasificacionTramitesDecisionDAL ClasificacionTramitesDecisionDAL = new ClasificacionTramitesDecisionDAL();
                    if (model.CodigoSolicitud != 0L)
                    {
                        model.RadicadoDecisionList = ClasificacionTramitesDecisionDAL.ObtenerClasificacionTramitesDecisionList(db, model.CodigoSolicitud);
                    }
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
public ClasificacionTramites_RadicadoJSON Radicado_Completar(ClasificacionTramites_RadicadoJSON model)
        {
            try
            {
                using (DbAtencionTramites db = new DbAtencionTramites())
                {
                    //Temporal
                    model = new ClasificacionTramites_RadicadoJSON();
                    model.CodigoSolicitud = 1;
                    model.RespuestaDecision.CodigoDecision = 1;
                    model.CodigoRespuesta = "0";
                    model.UltimusProcess = "ClasificacionTramites";

                    //model.Radicado.CodigoSolicitud = 1;
                    //model.Radicado.CodigoCiudad = 1;

                    //Fin Temporal

                    if (model.CodigoSolicitud == 0L)
                    {
                        model.DescripcionRespuesta = Constantes.MensajeGenerarSolicitud;
                        model.CodigoRespuesta = TipoCodigoRespuesta.ADVERTENCIA.ToString();
                        return model;
                    }
                    if (model.RespuestaDecision.CodigoDecision == 0)
                    {
                        model.DescripcionRespuesta = Constantes.MensajeLlenarDecision;
                        model.CodigoRespuesta = TipoCodigoRespuesta.ADVERTENCIA.ToString();
                        return model;
                    }
                    
                    if (model.CodigoRespuesta != TipoCodigoRespuesta.EXITOSO.ToString())
                    {
                        return model;
                    }

                    UltimusInterface UltimusInterface = new UltimusInterface();

                    model.UltimusTaskStartTime = model.UltimusTaskStartTime.Replace("p.\u00a0m.", "PM").Replace("a.\u00a0m.", "AM");

                    if (model.UltimusStep == Constantes.ClasificacionTramites.Etapas.AnalisisPeticionClasificacion.Nombre)
                    {
                        UltimusInterface.EnviarClasificacionTramites(model);
                        model.Respuesta.Incidente = model.UltimusIncident;
                        model.Respuesta.CodigoEstadoTarea = null;
                        //Guardar
                    }
                }
                model.DescripcionRespuesta = Constantes.MensajeSatisfactorioGenerico;
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

        //     
    }
}