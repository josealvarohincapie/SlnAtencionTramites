using AtencionTramites.Model.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Configuration;
using Ultimus.Interfaces;
using Ultimus.Interfaces.UltimusForm;
using Ultimus.Interfaces.UltimusIntegration;
using Ultimus.Utilitarios;

namespace AtencionTramites.Controllers
{
    public class BaseController : BaseMvcController
    {
        UltimusLogs UltimusLogs = new UltimusLogs("BaseController");

        public string co_solicitud
        {
            get
            {
                string ret = "0";
                if (!string.IsNullOrEmpty(Request.QueryString["co_solicitud"]))
                    ret = Request.QueryString["co_solicitud"];
                return ret;
            }
        }

        public void InitControllers()
        {
            try
            {
                ParametrosAplicacion ParametrosAplicacion = new ParametrosAplicacion();

                #region QUERY STRING
                string QueryString = string.Format("&co_solicitud={0}", co_solicitud);
                #endregion

                #region MENU
                List<StepFormsList> MenuList = ObtenerFormularios(Process, Step, UserID, TaskID, Incident, JobFunction, UserFullName, UserEmail, Supervisor, SupervisorFullName, TaskStatus, Version, StartTime, QueryString);
                if (MenuList == null)
                {
                    if (MenuList == null || MenuList.Count == 0)
                        MenuList = new List<StepFormsList> { (new StepFormsList { FormName = "OFFLINE" }) };
                }
                #endregion

                CargarViewState(MenuList, QueryString);

                ViewBag.CodigoSolicitud = co_solicitud;
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
                    if (!string.IsNullOrEmpty(Incident) && !string.IsNullOrEmpty(Version) && Incident != "0" && Version != "0")
                    {
                        string src = UltimusIntegrationAPI.GetIncidentImage(Process, Convert.ToInt32(Incident), Convert.ToInt32(Version));
                        ViewBag.ImageStatus = src;
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

            UltimusIntegrationAPIController UltimusIntegrationAPIController = new UltimusIntegrationAPIController();
            string valor = string.Empty;

            string co_solicitud = "0";
            if (Tarea.Incident > 0 && !string.IsNullOrEmpty(Tarea.TaskId))
            {
                UltimusIntegrationAPIController.GetNodeValue(Tarea.User, Tarea.TaskId, "TaskData.Global.CodigoSolicitud", out valor);
                co_solicitud = valor;
            }
            ret.Add("co_solicitud", string.IsNullOrEmpty(co_solicitud) ? "0" : co_solicitud);

            return ret;
        }

        protected List<StepFormsList> ObtenerFormularios(UltimusIncident Tarea, string QueryString)
        {
            return ObtenerFormularios(Tarea.Process, Tarea.Step, Tarea.User, Tarea.TaskId, Convert.ToString(Tarea.Incident), Tarea.JobFunction, Tarea.UserFullName, Tarea.UserEmail, Tarea.Supervisor, Tarea.SupervisorFullName, Convert.ToString(Tarea.Status), Convert.ToString(Tarea.Version), Tarea.StartTime.ToString("yyyy-MM-dd HH:mm:ss"), QueryString);
        }

        protected List<StepFormsList> ObtenerFormularios(string Process, string Step, string User, string TaskId, string Incident, string JobFunction, string UserFullName, string UserEmail, string Supervisor, string SupervisorFullName, string Status, string Version, string StartTime, string QueryString)
        {
            UltimusFormAPIController UltimusFormAPIController = new UltimusFormAPIController();
            List<StepFormsList> menu = UltimusFormAPIController.ObtenerFormularios(Process, Step);
            if (menu == null || menu.Count == 0)
                throw new Exception(string.Format("No se encontró formularios en el BPMComplement para el proceso {0} en la etapa {1}", Process, Step));

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