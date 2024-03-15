using AtencionTramites.Model.Classes;
using AtencionTramites.Model.ModelAtencionTramites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Configuration;
using Ultimus.Interfaces;
using Ultimus.Interfaces.UltimusForm;
using Ultimus.Interfaces.UltimusIntegration;
using Ultimus.Utilitarios;
using AtencionTramites.Model.DAL;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace AtencionTramites.Controllers
{
    public class BaseController : BaseMvcController
    {
        private UltimusLogs UltimusLogs = new UltimusLogs("BaseController");

        public string co_solicitud
        {
            get
            {
                string ret = "0";
                if (!string.IsNullOrEmpty(base.Request.QueryString["co_solicitud"]))
                {
                    ret = base.Request.QueryString["co_solicitud"];
                }
                return ret;
            }
        }

        public string co_solicitud_original
        {
            get
            {
                string ret = "0";
                if (!string.IsNullOrEmpty(base.Request.QueryString["co_solicitud_original"]))
                {
                    ret = base.Request.QueryString["co_solicitud_original"];
                }
                return ret;
            }
        }

        public string co_solicitud_interna
        {
            get
            {
                string ret = "0";
                if (!string.IsNullOrEmpty(base.Request.QueryString["co_solicitud_interna"]))
                {
                    ret = base.Request.QueryString["co_solicitud_interna"];
                }
                return ret;
            }
        }

        public ThemeJSON ThemeJSON
        {
            get
            {
                if (base.Session["ThemeJSON"] != null)
                {
                    return base.Session["ThemeJSON"] as ThemeJSON;
                }
                return null;
            }
            set
            {
                base.Session["ThemeJSON"] = value;
            }
        }

        public void InitControllers()
        {
            try
            {
                Variables Variables = new Variables();
                string QueryString = string.Empty;
                if (base.Process == Variables.CorrExtRecibida_NombreProceso)
                {
                    QueryString = "&co_solicitud=" + co_solicitud;
                }
                else if (base.Process == Variables.CorrExtEnviada_NombreProceso)
                {
                    QueryString = "&co_solicitud=" + co_solicitud + "&co_solicitud_original=" + co_solicitud_original + "&co_solicitud_interna=" + co_solicitud_interna;
                }
                else if (base.Process == Variables.CorrInterna_NombreProceso)
                {
                    QueryString = "&co_solicitud=" + co_solicitud + "&co_solicitud_original=" + co_solicitud_original + "&co_solicitud_interna=" + co_solicitud_interna;
                }
                List<StepFormsList> MenuList = ObtenerFormularios(base.Process, base.Step, base.UserID, base.TaskID, base.Incident, base.JobFunction, base.UserFullName, base.UserEmail, base.Supervisor, base.SupervisorFullName, base.TaskStatus, base.Version, base.StartTime, QueryString);
                if (MenuList == null || MenuList.Count == 0)
                {
                    MenuList = new List<StepFormsList>
                {
                    new StepFormsList
                    {
                        FormName = "OFFLINE"
                    }
                };
                }
                CargarViewState(MenuList, QueryString);
                base.ViewBag.WebUrl = Variables.WebUrl;
                base.ViewBag.WCFUrl = Variables.WCFUrl;
                base.ViewBag.ExtensionesPermitidas = Variables.ExtensionesPermitidas;
                base.ViewBag.UltimusAttachmentMaxSize = Convert.ToInt32(Variables.UltimusAttachmentMaxSize) * 1000000;
                base.ViewBag.IntegracionDozzierWebUrl = Variables.IntegracionDozzierWebUrl + "Home/MigracionExpediente?UserID=" + base.Request.QueryString["UserID"] + "&Process=" + base.Request.QueryString["Process"] + "&Step=" + base.Request.QueryString["Step"] + "&Incident=" + base.Request.QueryString["Incident"] + "&UserFullName=" + base.Request.QueryString["UserFullName"] + "&TaskStatus=" + base.Request.QueryString["TaskStatus"] + "&OcultarMenu=" + new Crypt().EncryptString("true") + "&co_solicitud=" + co_solicitud;
                base.ViewBag.CodigoSolicitud = co_solicitud;
                base.ViewBag.CodigoSolicitudOriginal = co_solicitud_original;
                base.ViewBag.CodigoSolicitudInterna = co_solicitud_interna;
            }
            catch (Exception ex)
            {
                UltimusLogs.Error(ex);
            }
        }

        public void InitImageStatus()
        {
            try
            {
                using (UltimusIntegrationAPIController UltimusIntegrationAPI = new UltimusIntegrationAPIController())
                {
                    if (!string.IsNullOrEmpty(base.Incident) && !string.IsNullOrEmpty(base.Version) && base.Incident != "0" && base.Version != "0")
                    {
                        string src = UltimusIntegrationAPI.GetIncidentImage(base.Process, Convert.ToInt32(base.Incident), Convert.ToInt32(base.Version));
                        base.ViewBag.ImageStatus = src;
                    }
                }
            }
            catch (Exception ex)
            {
                UltimusLogs.Error(ex);
            }
        }

        protected Dictionary<string, string> ObtenerVariables(UltimusIncident Tarea)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            Variables Variables = new Variables();
            UltimusIntegrationAPIController UltimusIntegrationAPIController = new UltimusIntegrationAPIController();
            string valor = string.Empty;
            string co_solicitud = "0";
            string co_solicitud_original = "0";
            string co_solicitud_interna = "0";
            if (Tarea.Incident > 0 && !string.IsNullOrEmpty(Tarea.TaskId))
            {
                if (Tarea.Process == Variables.CorrExtRecibida_NombreProceso)
                {
                    UltimusIntegrationAPIController.GetNodeValue(Tarea.User, Tarea.TaskId, "TaskData.Global.CodigoSolicitud", out valor);
                    co_solicitud = valor;
                }
                else if (Tarea.Process == Variables.CorrExtEnviada_NombreProceso)
                {
                    UltimusIntegrationAPIController.GetNodeValue(Tarea.User, Tarea.TaskId, "TaskData.Global.CodigoSolicitud", out valor);
                    co_solicitud = valor;
                    UltimusIntegrationAPIController.GetNodeValue(Tarea.User, Tarea.TaskId, "TaskData.Global.CodigoSolicitudOriginal", out valor);
                    co_solicitud_original = valor;
                    UltimusIntegrationAPIController.GetNodeValue(Tarea.User, Tarea.TaskId, "TaskData.Global.CodigoSolicitudInterna", out valor);
                    co_solicitud_interna = valor;
                    if ((co_solicitud == "0" || string.IsNullOrEmpty(co_solicitud)) && co_solicitud_original != "0")
                    {
                        RespuestaDAL RespuestaDAL = new RespuestaDAL();
                        DbAtencionTramites db = new DbAtencionTramites();
                        try
                        {
                            Respuesta respuesta = RespuestaDAL.ObtenerRespuestaSolucitudPrincipal(db, long.Parse(co_solicitud_original));
                            co_solicitud = respuesta.CodigoSolicitud.ToString();
                        }
                        finally
                        {
                            ((IDisposable)db)?.Dispose();
                        }
                    }
                }
                else if (Tarea.Process == Variables.CorrInterna_NombreProceso)
                {
                    UltimusIntegrationAPIController.GetNodeValue(Tarea.User, Tarea.TaskId, "TaskData.Global.CodigoSolicitud", out valor);
                    co_solicitud = valor;
                    UltimusIntegrationAPIController.GetNodeValue(Tarea.User, Tarea.TaskId, "TaskData.Global.CodigoSolicitudOriginal", out valor);
                    co_solicitud_original = valor;
                    try
                    {
                        UltimusIntegrationAPIController.GetNodeValue(Tarea.User, Tarea.TaskId, "TaskData.Global.CodigoSolicitudInterna", out valor);
                        co_solicitud_interna = valor;
                    }
                    catch
                    {
                    }
                }
            }
            if (Tarea.Process == Variables.CorrExtRecibida_NombreProceso)
            {
                ret.Add("co_solicitud", string.IsNullOrEmpty(co_solicitud) ? "0" : co_solicitud);
            }
            else if (Tarea.Process == Variables.CorrExtEnviada_NombreProceso)
            {
                ret.Add("co_solicitud", string.IsNullOrEmpty(co_solicitud) ? "0" : co_solicitud);
                ret.Add("co_solicitud_original", string.IsNullOrEmpty(co_solicitud_original) ? "0" : co_solicitud_original);
                ret.Add("co_solicitud_interna", string.IsNullOrEmpty(co_solicitud_interna) ? "0" : co_solicitud_interna);
            }
            else if (Tarea.Process == Variables.CorrInterna_NombreProceso)
            {
                ret.Add("co_solicitud", string.IsNullOrEmpty(co_solicitud) ? "0" : co_solicitud);
                ret.Add("co_solicitud_original", string.IsNullOrEmpty(co_solicitud_original) ? "0" : co_solicitud_original);
                ret.Add("co_solicitud_interna", string.IsNullOrEmpty(co_solicitud_interna) ? "0" : co_solicitud_interna);
            }
            return ret;
        }

        protected List<StepFormsList> ObtenerFormularios(UltimusIncident Tarea, string QueryString)
        {
            return ObtenerFormularios(Tarea.Process, Tarea.Step, Tarea.User, Tarea.TaskId, Convert.ToString(Tarea.Incident), Tarea.JobFunction, Tarea.UserFullName, Tarea.UserEmail, Tarea.Supervisor, Tarea.SupervisorFullName, Convert.ToString(Tarea.Status), Convert.ToString(Tarea.Version), Tarea.StartTime.ToString("yyyy-MM-dd hh:mm:ss tt"), QueryString);
        }

        protected List<StepFormsList> ObtenerFormularios(string Process, string Step, string User, string TaskId, string Incident, string JobFunction, string UserFullName, string UserEmail, string Supervisor, string SupervisorFullName, string Status, string Version, string StartTime, string QueryString)
        {
            UltimusFormAPIController UltimusFormAPIController = new UltimusFormAPIController();
            List<StepFormsList> menu = UltimusFormAPIController.ObtenerFormularios(Process, Step);
            if (menu == null || menu.Count == 0)
            {
                throw new Exception("No se encontró formularios en el BPMComplement para el proceso " + Process + " en la etapa " + Step);
            }
            foreach (StepFormsList StepFormsList in menu)
            {
                string OcultarMenu = "0";
                string SoloLectura = "0";
                StringBuilder ret = new StringBuilder();
                Crypt crypt = new Crypt();
                ret.AppendFormat(StepFormsList.FormPath);
                ret.AppendFormat("?UserID={0}", crypt.EncryptString(User));
                ret.AppendFormat("&TaskID={0}", crypt.EncryptString(TaskId));
                ret.AppendFormat("&Process={0}", crypt.EncryptString(Process));
                ret.AppendFormat("&Step={0}", crypt.EncryptString(Step));
                ret.AppendFormat("&Incident={0}", crypt.EncryptString(Incident));
                ret.AppendFormat("&JobFunction={0}", crypt.EncryptString(JobFunction));
                ret.AppendFormat("&UserFullName={0}", crypt.EncryptString(UserFullName));
                ret.AppendFormat("&UserEmail={0}", crypt.EncryptString(UserEmail));
                ret.AppendFormat("&Supervisor={0}", crypt.EncryptString(Supervisor));
                ret.AppendFormat("&SupervisorFullName={0}", crypt.EncryptString(SupervisorFullName));
                ret.AppendFormat("&TaskStatus={0}", crypt.EncryptString(Status));
                ret.AppendFormat("&Version={0}", crypt.EncryptString(Version));
                ret.AppendFormat("&StartTime={0}", crypt.EncryptString(StartTime));
                ret.AppendFormat("&OcultarMenu={0}", crypt.EncryptString(OcultarMenu));
                ret.AppendFormat("&SoloLectura={0}", crypt.EncryptString(SoloLectura));
                ret.AppendFormat(QueryString);
                StepFormsList.FormPath = ret.ToString();
            }
            return menu;
        }
    }
}