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

        //public ClasificacionTramites_RadicadoJSON Radicado_Cargar_OLD(ClasificacionTramites_RadicadoJSON model)
        //{
        //    Variables Variables = new Variables();
        //    try
        //    {
        //        using (DbAtencionTramites db = new DbAtencionTramites())
        //        {
        //            RadicadoDAL RadicadoDAL = new RadicadoDAL();
        //            RadicadoInternoDAL RadicadoInternoDAL = new RadicadoInternoDAL();
        //            RespuestaDAL RespuestaDAL = new RespuestaDAL();
        //            model.Radicado = RadicadoDAL.ObtenerRadicado(db, model.CodigoSolicitudOriginal);
        //            model.RadicadoInterno = RadicadoInternoDAL.ObtenerRadicadoInterno(db, model.CodigoSolicitudInterna, 1);
        //            model.RadicadoInternoRespuesta = RadicadoInternoDAL.ObtenerRadicadoInterno(db, model.CodigoSolicitudInterna, 2);
        //            model.Respuesta = RespuestaDAL.ObtenerRespuesta(db, model.CodigoSolicitud);
        //            if (model.Respuesta == null)
        //            {
        //                model.Respuesta = new Respuesta();
        //                if (model.Radicado == null)
        //                {
        //                    UltimusDAL ultimusDAL = new UltimusDAL();
        //                    DEPARTMENTS Entidad = ultimusDAL.ObtenerEntidadUsuario(model.UltimusUserID);
        //                    if (Entidad != null)
        //                    {
        //                        model.Respuesta.CodigoEntidad = Entidad.ID;
        //                        model.Respuesta.NombreEntidad = Entidad.NAME;
        //                    }
        //                    DEPARTMENTS Secretaria = ultimusDAL.ObtenerSecretariaUsuario(model.UltimusUserID);
        //                    if (Secretaria != null)
        //                    {
        //                        model.Respuesta.CodigoSecretaria = Secretaria.ID;
        //                        model.Respuesta.NombreSecretaria = Secretaria.NAME;
        //                    }
        //                    model.Respuesta.HabilitaRespIntegrada = false;
        //                }
        //                else
        //                {
        //                    model.Respuesta.CodigoEntidad = model.Radicado.CodigoEntidad;
        //                    model.Respuesta.NombreEntidad = model.Radicado.NombreEntidad;
        //                    model.Respuesta.CodigoSecretaria = model.Radicado.CodigoSecretaria;
        //                    model.Respuesta.NombreSecretaria = model.Radicado.NombreSecretaria;
        //                    model.Respuesta.Nombre = model.Radicado.Remitente;
        //                    model.Respuesta.Correo = model.Radicado.Correo;
        //                    model.Respuesta.CodigoFormato = model.Radicado.CodigoFormato;
        //                    model.Respuesta.NombreFormato = model.Radicado.NombreFormato;
        //                    model.Respuesta.CodigoTipoDocumento = model.Radicado.CodigoTipoDocumento;
        //                    model.Respuesta.CodigoSubTipoDocumento = model.Radicado.CodigoSubTipoDocumento;
        //                    List<TipoDocumentoRespuestaIntegrada> habilitados2 = db.TipoDocumentoRespuestaIntegrada.AsNoTracking().ToList();
        //                    model.Respuesta.HabilitaRespIntegrada = habilitados2.Exists((TipoDocumentoRespuestaIntegrada q) => q.CodigoTipoDocumento == model.Radicado.CodigoTipoDocumento && (q.CodigoSubTipoDocumento == model.Radicado.CodigoSubTipoDocumento || q.CodigoSubTipoDocumento == 0));
        //                }
        //            }
        //            else if (model.Radicado != null)
        //            {
        //                model.Respuesta.CodigoTipoDocumento = model.Radicado.CodigoTipoDocumento;
        //                model.Respuesta.CodigoSubTipoDocumento = model.Radicado.CodigoSubTipoDocumento;
        //                if (!model.Respuesta.CodigoEntidad.HasValue)
        //                {
        //                    model.Respuesta.CodigoEntidad = model.Radicado.CodigoEntidad;
        //                    model.Respuesta.NombreEntidad = model.Radicado.NombreEntidad;
        //                    model.Respuesta.CodigoSecretaria = model.Radicado.CodigoSecretaria;
        //                    model.Respuesta.NombreSecretaria = model.Radicado.NombreSecretaria;
        //                    model.Respuesta.Nombre = model.Radicado.Remitente;
        //                    model.Respuesta.Correo = model.Radicado.Correo;
        //                    model.Respuesta.CodigoFormato = model.Radicado.CodigoFormato;
        //                    model.Respuesta.NombreFormato = model.Radicado.NombreFormato;
        //                    model.Respuesta.CodigoTipoDocumento = model.Radicado.CodigoTipoDocumento;
        //                    model.Respuesta.CodigoSubTipoDocumento = model.Radicado.CodigoSubTipoDocumento;
        //                    List<TipoDocumentoRespuestaIntegrada> habilitados = db.TipoDocumentoRespuestaIntegrada.AsNoTracking().ToList();
        //                    model.Respuesta.HabilitaRespIntegrada = habilitados.Exists((TipoDocumentoRespuestaIntegrada q) => q.CodigoTipoDocumento == model.Radicado.CodigoTipoDocumento && (q.CodigoSubTipoDocumento == model.Radicado.CodigoSubTipoDocumento || q.CodigoSubTipoDocumento == 0));
        //                }
        //            }
        //            if (model.UltimusStep == Constantes.ClasificacionTramites.Etapas.AnalisisPeticionClasificacion.Nombre && new RespuestaDecisionDAL().ObtenerRespuestaDecision(db, model.CodigoSolicitud, Constantes.ClasificacionTramites.Etapas.Asesoria.Nombre).CodigoTipoFirma == 2)
        //            {
        //                string host = HttpContext.Current.Request.Url.Host;
        //                string serviceDomain = new Uri(Variables.FirmaElectronicaApi).Host;
        //                string tipoDocumento = ((host == serviceDomain) ? 1.ToString() : 2.ToString());
        //                if (!model.Respuesta.DocumentoFirmado.HasValue || !model.Respuesta.DocumentoFirmado.Value)
        //                {
        //                    //new FirmaElectronicaInterface();
        //                    string documento = ""; // FirmaElectronicaInterface.CargarDocumentoFirmado(tipoDocumento, model.Respuesta.IdDocumentoFirmado.Value);
        //                    if (tipoDocumento == 1.ToString() && !string.IsNullOrEmpty(documento))
        //                    {
        //                        string path2 = Variables.UltimusAttachmentPath + Variables.CorrExtEnviada_NombreProceso + "\\" + Constantes.CarpetaGenerados;
        //                        string destinationFile2 = path2 + "\\" + Path.GetFileName(documento);
        //                        if (!Directory.Exists(path2))
        //                        {
        //                            Directory.CreateDirectory(path2);
        //                        }
        //                        File.Copy(documento, destinationFile2, overwrite: true);
        //                        model.Respuesta.RutaFisicaDocumentoSinFirma = model.Respuesta.RutaFisicaDocumento;
        //                        model.Respuesta.RutaVirtualDocumentoSinFirma = model.Respuesta.RutaVirtualDocumento;
        //                        model.Respuesta.RutaFisicaDocumento = destinationFile2;
        //                        model.Respuesta.RutaVirtualDocumento = Variables.UltimusAttachmentUrl + Variables.CorrExtEnviada_NombreProceso + "/" + Constantes.CarpetaGenerados + "/" + Path.GetFileName(destinationFile2);
        //                        model.Respuesta.DocumentoFirmado = true;
        //                        RespuestaDAL.ActualizarRecepcionFirma(db, model.Respuesta);
        //                        File.Delete(documento);
        //                    }
        //                    if (tipoDocumento == 2.ToString() && !string.IsNullOrEmpty(documento))
        //                    {
        //                        byte[] bytes = Convert.FromBase64String(documento);
        //                        string nombre = Guid.NewGuid().ToString();
        //                        string path = Variables.UltimusAttachmentPath + Variables.CorrExtEnviada_NombreProceso + "\\" + Constantes.CarpetaGenerados;
        //                        string destinationFile = path + "\\" + nombre + ".pdf";
        //                        if (!Directory.Exists(path))
        //                        {
        //                            Directory.CreateDirectory(path);
        //                        }
        //                        BinaryWriter binaryWriter = new BinaryWriter(new FileStream(destinationFile, FileMode.CreateNew));
        //                        binaryWriter.Write(bytes, 0, bytes.Length);
        //                        binaryWriter.Close();
        //                        model.Respuesta.RutaFisicaDocumentoSinFirma = model.Respuesta.RutaFisicaDocumento;
        //                        model.Respuesta.RutaVirtualDocumentoSinFirma = model.Respuesta.RutaVirtualDocumento;
        //                        model.Respuesta.RutaFisicaDocumento = destinationFile;
        //                        model.Respuesta.RutaVirtualDocumento = Variables.UltimusAttachmentUrl + Variables.CorrExtEnviada_NombreProceso + "/" + Constantes.CarpetaGenerados + "/" + Path.GetFileName(destinationFile);
        //                        model.Respuesta.DocumentoFirmado = true;
        //                        RespuestaDAL.ActualizarRecepcionFirma(db, model.Respuesta);
        //                    }
        //                }
        //            }
        //        }
        //        model.CodigoRespuesta = TipoCodigoRespuesta.EXITOSO.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        model.DescripcionRespuesta = Constantes.MensajeErrorGenerico;
        //        model.CodigoRespuesta = TipoCodigoRespuesta.ERROR.ToString();
        //        logs.Error(ex);
        //    }
        //    return model;
        //}

        //public ClasificacionTramites_RadicadoJSON Radicado_Guardar(ClasificacionTramites_RadicadoJSON model)
        //{
        //    try
        //    {
        //        model.Respuesta.CodigoSolicitud = model.CodigoSolicitud;
        //        model.Respuesta.CodigoSolicitudOriginal = model.CodigoSolicitudOriginal;
        //        model.Respuesta.CodigoSolicitudInterna = model.CodigoSolicitudInterna;
        //        using (DbAtencionTramites db = new DbAtencionTramites())
        //        {
        //            Respuesta ele = db.Respuesta.Where((Respuesta q) => q.CodigoSolicitud == model.Respuesta.CodigoSolicitud).FirstOrDefault();
        //            if (ele == null)
        //            {
        //                model.Respuesta.CodigoSolicitud = (db.Respuesta.Any() ? (db.Respuesta.Max((Respuesta q) => q.CodigoSolicitud) + 1) : 1);
        //                if (!model.Respuesta.Fecha.HasValue)
        //                {
        //                    model.Respuesta.Fecha = DateTime.Now;
        //                }
        //                model.Respuesta.FechaCreacion = DateTime.Now;
        //                model.Respuesta.IDUsuarioCreacion = model.UltimusUserID;
        //                model.Respuesta.NombreUsuarioCreacion = model.UltimusUserFullName;
        //                GenerarNumeroRadicado(db, model.Respuesta);
        //                GenerarRespuestaFormato(db, model.Respuesta, model.Radicado);
        //                GuardarRespuestaDocumentos(db, model.Respuesta, model);
        //                GuardarRespuestaAdicional(db, model.Respuesta);
        //                db.Respuesta.Add(model.Respuesta);
        //                db.SaveChanges();
        //            }
        //            else
        //            {
        //                if (ele.Secuencial.HasValue)
        //                {
        //                    model.Respuesta.Secuencial = ele.Secuencial;
        //                }
        //                if (ele.NumeroRadicado != null)
        //                {
        //                    model.Respuesta.NumeroRadicado = ele.NumeroRadicado;
        //                }
        //                if (ele.Fecha.HasValue)
        //                {
        //                    model.Respuesta.Fecha = ele.Fecha;
        //                }
        //                if (ele.Incidente.HasValue)
        //                {
        //                    model.Respuesta.Incidente = ele.Incidente;
        //                }
        //                if (ele.CodigoRecipienteAbogado.HasValue && !model.Respuesta.CodigoRecipienteAbogado.HasValue)
        //                {
        //                    model.Respuesta.CodigoRecipienteAbogado = ele.CodigoRecipienteAbogado;
        //                }
        //                if (ele.CodigoRecipienteFuncionario.HasValue && !model.Respuesta.CodigoRecipienteFuncionario.HasValue)
        //                {
        //                    model.Respuesta.CodigoRecipienteFuncionario = ele.CodigoRecipienteFuncionario;
        //                }
        //                if (ele.CodigoRecipienteSecretaria.HasValue && !model.Respuesta.CodigoRecipienteSecretaria.HasValue)
        //                {
        //                    model.Respuesta.CodigoRecipienteSecretaria = ele.CodigoRecipienteSecretaria;
        //                }
        //                model.Respuesta.FechaCreacion = ele.FechaCreacion;
        //                model.Respuesta.IDUsuarioCreacion = ele.IDUsuarioCreacion;
        //                model.Respuesta.NombreUsuarioCreacion = ele.NombreUsuarioCreacion;
        //                if (model.UltimusStep != Constantes.ClasificacionTramites.Etapas.AnalisisPeticionClasificacion.Nombre && model.UltimusStep != Constantes.ClasificacionTramites.Etapas.AnalisisPeticionClasificacion.Nombre && model.UltimusStep != Constantes.ClasificacionTramites.Etapas.Asesoria.Nombre && model.UltimusStep != Constantes.ClasificacionTramites.Etapas.Asesoria.Nombre)
        //                {
        //                    model.Respuesta.CodigoSecretaria = ele.CodigoSecretaria;
        //                    model.Respuesta.Correo = ele.Correo;
        //                    model.Respuesta.EsUrgente = ele.EsUrgente;
        //                    model.Respuesta.Calificativo = ele.Calificativo;
        //                    model.Respuesta.Nombre = ele.Nombre;
        //                    model.Respuesta.Cargo = ele.Cargo;
        //                    model.Respuesta.AsuntoDocumento = ele.AsuntoDocumento;
        //                    model.Respuesta.CuerpoDocumento = ((ele.CuerpoDocumento == null) ? model.Respuesta.CuerpoDocumento : ele.CuerpoDocumento);
        //                    model.Respuesta.CodigoFormato = ele.CodigoFormato;
        //                }
        //                if (model.UltimusStep != Constantes.ClasificacionTramites.Etapas.AnalisisPeticionClasificacion.Nombre && model.UltimusStep != Constantes.ClasificacionTramites.Etapas.AnalisisPeticionClasificacion.Nombre)
        //                {
        //                    model.Respuesta.NumeroGuia = ele.NumeroGuia;
        //                }
        //                model.Respuesta.UrlParaFirma = ele.UrlParaFirma;
        //                model.Respuesta.IdDocumentoFirmado = ele.IdDocumentoFirmado;
        //                model.Respuesta.DocumentoFirmado = ele.DocumentoFirmado;
        //                model.Respuesta.RutaFisicaDocumentoSinFirma = ele.RutaFisicaDocumentoSinFirma;
        //                model.Respuesta.RutaVirtualDocumentoSinFirma = ele.RutaVirtualDocumentoSinFirma;
        //                GenerarNumeroRadicado(db, model.Respuesta);
        //                if (model.UltimusStep == Constantes.ClasificacionTramites.Etapas.AnalisisPeticionClasificacion.Nombre || model.UltimusStep == Constantes.ClasificacionTramites.Etapas.AnalisisPeticionClasificacion.Nombre || model.UltimusStep == Constantes.ClasificacionTramites.Etapas.AnalisisPeticionClasificacion.Nombre || model.UltimusStep == Constantes.ClasificacionTramites.Etapas.AnalisisPeticionClasificacion.Nombre)
        //                {
        //                    GenerarRespuestaFormato(db, model.Respuesta, model.Radicado);
        //                }
        //                else
        //                {
        //                    model.Respuesta.RutaFisicaDocumento = ele.RutaFisicaDocumento;
        //                    model.Respuesta.RutaVirtualDocumento = ele.RutaVirtualDocumento;
        //                }
        //                GuardarRespuestaDocumentos(db, model.Respuesta, model);
        //                GuardarRespuestaAdicional(db, model.Respuesta);
        //                ele.CopyValueProperties(model.Respuesta);
        //                db.Entry(ele).State = EntityState.Modified;
        //                db.SaveChanges();
        //            }
        //        }
        //        model.DescripcionRespuesta = Constantes.MensajeSatisfactorioGenerico;
        //        model.CodigoRespuesta = TipoCodigoRespuesta.EXITOSO.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        model.DescripcionRespuesta = Constantes.MensajeErrorGenerico;
        //        model.CodigoRespuesta = TipoCodigoRespuesta.ERROR.ToString();
        //        logs.Error(ex);
        //    }
        //    return model;
        //}

        //public ClasificacionTramites_RadicadoJSON Radicado_Descartar(ClasificacionTramites_RadicadoJSON model)
        //{
        //    try
        //    {
        //        using (new DbAtencionTramites())
        //        {
        //            if (model.CodigoSolicitud == 0L)
        //            {
        //                model.DescripcionRespuesta = Constantes.MensajeGenerarSolicitud;
        //                model.CodigoRespuesta = TipoCodigoRespuesta.ADVERTENCIA.ToString();
        //                return model;
        //            }
        //            if (model.UltimusStep == Constantes.ClasificacionTramites.Etapas.Asesoria.Nombre)
        //            {
        //                model.RespuestaDecision.CodigoDecision = Constantes.ClasificacionTramites.Etapas.Asesoria.Decisiones.Decision1;
        //            }
        //            else if (model.UltimusStep == Constantes.ClasificacionTramites.Etapas.Asesoria.Nombre)
        //            {
        //                model.RespuestaDecision.CodigoDecision = Constantes.ClasificacionTramites.Etapas.Asesoria.Decisiones.Decision3;
        //            }
        //            model.Respuesta.Descartado = true;
        //            //model = Radicado_Completar(model);
        //            if (model.CodigoRespuesta != TipoCodigoRespuesta.EXITOSO.ToString())
        //            {
        //                return model;
        //            }
        //        }
        //        model.DescripcionRespuesta = Constantes.MensajeSatisfactorioGenerico;
        //        model.CodigoRespuesta = TipoCodigoRespuesta.EXITOSO.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        model.DescripcionRespuesta = Constantes.MensajeErrorGenerico;
        //        model.CodigoRespuesta = TipoCodigoRespuesta.ERROR.ToString();
        //        logs.Error(ex);
        //    }
        //    return model;
        //}

        //private void GenerarNumeroRadicado(DbAtencionTramites db, Respuesta Respuesta)
        //{
        //    if (Respuesta.Descartado)
        //    {
        //        Respuesta.Secuencial = null;
        //        Respuesta.NumeroRadicado = null;
        //    }
        //    else
        //    {
        //        if (Respuesta.Secuencial.HasValue || !string.IsNullOrEmpty(Respuesta.NumeroRadicado) || !Respuesta.Fecha.HasValue || !Respuesta.CodigoEntidad.HasValue || !Respuesta.CodigoSecretaria.HasValue)
        //        {
        //            return;
        //        }
        //        Entidad Entidad = (from q in db.Entidad.AsNoTracking()
        //                           where q.Nombre == Respuesta.NombreEntidad
        //                           select q).FirstOrDefault();
        //        Secretaria Secretaria = (from q in db.Secretaria.AsNoTracking()
        //                                 where q.Nombre == Respuesta.NombreSecretaria
        //                                 select q).FirstOrDefault();
        //        if (Entidad == null)
        //        {
        //            throw new Exception(Constantes.MensajeErrorEntidadNoConfigurada);
        //        }
        //        if (Secretaria == null)
        //        {
        //            throw new Exception(Constantes.MensajeErrorSecretariaNoConfigurada);
        //        }
        //        List<int> SecuenciaList = (from q in db.Respuesta.AsNoTracking()
        //                                   where q.Secuencial != null && q.Fecha.Value.Year == Respuesta.Fecha.Value.Year && q.NombreEntidad == Entidad.Nombre
        //                                   select q.Secuencial.Value).ToList();
        //        if (SecuenciaList == null || !SecuenciaList.Any())
        //        {
        //            Respuesta.Secuencial = Entidad.SecuencialInicio;
        //        }
        //        else
        //        {
        //            int SecuencialMax = SecuenciaList.Max();
        //            int i;
        //            for (i = 1; i <= SecuencialMax; i++)
        //            {
        //                if (!SecuenciaList.Any((int q) => q == i))
        //                {
        //                    Respuesta.Secuencial = i;
        //                    break;
        //                }
        //            }
        //            if (!Respuesta.Secuencial.HasValue)
        //            {
        //                Respuesta.Secuencial = SecuencialMax + 1;
        //            }
        //        }
        //        Respuesta.NumeroRadicado = UltimusUtility.ObtenerNumeroRadicado(Entidad.Sigla, Constantes.ClasificacionTramites.Sigla, Respuesta.Fecha.Value, Secretaria.CodigoDependencia, Respuesta.Secuencial.Value);
        //    }
        //}

        //private void GenerarRespuestaFormato(DbAtencionTramites db, Respuesta Respuesta, Radicado Radicado)
        //{
        //    if (string.IsNullOrEmpty(Respuesta.NumeroRadicado) || !Respuesta.CodigoFormato.HasValue)
        //    {
        //        Respuesta.RutaFisicaDocumento = null;
        //        Respuesta.RutaVirtualDocumento = null;
        //        return;
        //    }
        //    ResultadoGeneracion ResuldatoGeneracion = null;// WCFDocumentosInterface.GenerarRespuestaFormato(db, Respuesta, Radicado, null);
        //    if (ResuldatoGeneracion.Resultado && !string.IsNullOrEmpty(ResuldatoGeneracion.RutaFisica) && !string.IsNullOrEmpty(ResuldatoGeneracion.RutaVirtual))
        //    {
        //        Respuesta.RutaFisicaDocumento = ResuldatoGeneracion.RutaFisica;
        //        Respuesta.RutaVirtualDocumento = ResuldatoGeneracion.RutaVirtual;
        //        return;
        //    }
        //    throw new Exception(Constantes.MensajeErrorGeneracionDocumento);
        //}

        //private void GuardarRespuestaDocumentos(DbAtencionTramites db, Respuesta Respuesta, UltimusJson model)
        //{
        //    List<RespuestaDocumento> DocumentoList = db.RespuestaDocumento.Where((RespuestaDocumento q) => q.CodigoSolicitud == Respuesta.CodigoSolicitud).ToList();
        //    if (Respuesta.RespuestaDocumento == null)
        //    {
        //        db.RespuestaDocumento.RemoveRange(DocumentoList);
        //        return;
        //    }
        //    foreach (RespuestaDocumento RespuestaDocumento2 in Respuesta.RespuestaDocumento)
        //    {
        //        if (!DocumentoList.Any((RespuestaDocumento q) => q.CodigoRespuestaDocumento == RespuestaDocumento2.CodigoRespuestaDocumento))
        //        {
        //            RespuestaDocumento2.CodigoSolicitud = Respuesta.CodigoSolicitud;
        //            RespuestaDocumento2.CodigoRespuestaDocumento = Guid.NewGuid();
        //            RespuestaDocumento2.Etapa = model.UltimusStep;
        //            RespuestaDocumento2.FechaCreacion = DateTime.Now;
        //            RespuestaDocumento2.IDUsuarioCreacion = model.UltimusUserID;
        //            RespuestaDocumento2.NombreUsuarioCreacion = model.UltimusUserFullName;
        //            db.RespuestaDocumento.Add(RespuestaDocumento2);
        //        }
        //    }
        //    foreach (RespuestaDocumento RespuestaDocumento in DocumentoList)
        //    {
        //        if (!Respuesta.RespuestaDocumento.Any((RespuestaDocumento q) => q.CodigoRespuestaDocumento == RespuestaDocumento.CodigoRespuestaDocumento))
        //        {
        //            db.RespuestaDocumento.Remove(RespuestaDocumento);
        //        }
        //    }
        //}

        //private void GuardarRespuestaAdicional(DbAtencionTramites db, Respuesta Respuesta)
        //{
        //    List<RespuestaAdicional> AdicionalList = db.RespuestaAdicional.Where((RespuestaAdicional q) => q.CodigoSolicitud == Respuesta.CodigoSolicitud).ToList();
        //    if (Respuesta.RespuestaAdicional == null)
        //    {
        //        db.RespuestaAdicional.RemoveRange(AdicionalList);
        //        return;
        //    }
        //    foreach (RespuestaAdicional RespuestaAdicional2 in Respuesta.RespuestaAdicional)
        //    {
        //        if (!AdicionalList.Any((RespuestaAdicional q) => q.CodigoRespuestaAdicional == RespuestaAdicional2.CodigoRespuestaAdicional))
        //        {
        //            RespuestaAdicional2.CodigoSolicitud = Respuesta.CodigoSolicitud;
        //            RespuestaAdicional2.CodigoRespuestaAdicional = Guid.NewGuid();
        //            db.RespuestaAdicional.Add(RespuestaAdicional2);
        //        }
        //    }
        //    foreach (RespuestaAdicional RespuestaAdicional in AdicionalList)
        //    {
        //        RespuestaAdicional model = Respuesta.RespuestaAdicional.Where((RespuestaAdicional q) => q.CodigoRespuestaAdicional == RespuestaAdicional.CodigoRespuestaAdicional).FirstOrDefault();
        //        if (model == null)
        //        {
        //            db.RespuestaAdicional.Remove(RespuestaAdicional);
        //            continue;
        //        }
        //        RespuestaAdicional.CopyValueProperties(model);
        //        db.Entry(RespuestaAdicional).State = EntityState.Modified;
        //    }
        //}

        //public ClasificacionTramites_SeguimientoJSON Seguimiento_Cargar(ClasificacionTramites_SeguimientoJSON model)
        //{
        //    try
        //    {
        //        using (DbAtencionTramites db = new DbAtencionTramites())
        //        {
        //            RadicadoDecisionDAL RadicadoDecisionDAL = new RadicadoDecisionDAL();
        //            RadicadoInternoDecisionDAL RadicadoInternoDecisionDAL = new RadicadoInternoDecisionDAL();
        //            RespuestaDecisionDAL RespuestaDecisionDAL = new RespuestaDecisionDAL();
        //            if (model.CodigoSolicitudOriginal != 0L)
        //            {
        //                model.RadicadoDecisionList = RadicadoDecisionDAL.ObtenerRadicadoDecisionList(db, model.CodigoSolicitudOriginal);
        //            }
        //            if (model.CodigoSolicitudInterna != 0L)
        //            {
        //                model.RadicadoInternoDecisionList = RadicadoInternoDecisionDAL.ObtenerRadicadoInternoDecisionList(db, model.CodigoSolicitudInterna);
        //            }
        //            if (model.CodigoSolicitud != 0L)
        //            {
        //                model.RespuestaDecisionList = RespuestaDecisionDAL.ObtenerRespuestaDecisionList(db, model.CodigoSolicitud);
        //            }
        //        }
        //        model.CodigoRespuesta = TipoCodigoRespuesta.EXITOSO.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        model.DescripcionRespuesta = Constantes.MensajeErrorGenerico;
        //        model.CodigoRespuesta = TipoCodigoRespuesta.ERROR.ToString();
        //        logs.Error(ex);
        //    }
        //    return model;
        //}

        //public long GuardarRadicadoPadre(RadicadoPadre model)
        //{
        //    long CodigoSolicitud;
        //    try
        //    {
        //        using (DbAtencionTramites db = new DbAtencionTramites())
        //        {
        //            Respuesta ele = db.Respuesta.Where((Respuesta q) => q.Incidente == (int?)model.Incidente && q.Incidente != (int?)0).FirstOrDefault();
        //            if (ele != null)
        //            {
        //                CodigoSolicitud = ele.CodigoSolicitud;
        //            }
        //            else
        //            {
        //                Respuesta respuesta = new Respuesta();
        //                respuesta.Incidente = model.Incidente;
        //                respuesta.CodigoSolicitud = (db.Respuesta.Any() ? (db.Respuesta.Max((Respuesta q) => q.CodigoSolicitud) + 1) : 1);
        //                respuesta.CodigoSolicitudOriginal = model.CodigoSolicitudOriginal;
        //                respuesta.Fecha = DateTime.Now;
        //                db.Respuesta.Add(respuesta);
        //                db.SaveChanges();
        //                CodigoSolicitud = respuesta.CodigoSolicitud;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CodigoSolicitud = 0L;
        //        logs.Error(ex);
        //    }
        //    return CodigoSolicitud;
        //}
    }
}