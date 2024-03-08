using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ultimus.Interfaces.UltimusForm;
using Ultimus.Utilitarios;

namespace AtencionTramites.Controllers
{
    public class GenerarCartaController : BaseController
    {
        UltimusLogs UltimusLogs = new UltimusLogs("GenerarCartaController");

        public ActionResult Index()
        {
            ActionResult ret = null;
            try
            {
                LeerTarea();

                #region VARIABLES
                Dictionary<string, string> Variables = ObtenerVariables(Tarea);
                #endregion

                #region CARGA MENU TABS
                string QueryString = string.Empty;
                foreach (KeyValuePair<string, string> Variable in Variables)
                {
                    QueryString += string.Format("&{0}={1}", Variable.Key, Variable.Value);
                }
                List<StepFormsList> MenuList = ObtenerFormularios(Tarea, QueryString);
                if (MenuList == null || MenuList.Count == 0)
                {
                    throw new Exception(string.Format("Error en la configuración del BPM Complement para el proceso: {0} - etapa: {1}", Tarea.Process, Tarea.Step));
                }
                else
                {
                    ret = Redirect(MenuList.First().FormPath);
                }
                #endregion

                Session["ThemeJSONProceso"] = null;
                Session["CheckLicense"] = null;
            }
            catch (Exception ex)
            {
                UltimusLogs.Error(ex);
            }
            return ret;
        }

        public ActionResult GenerarCarta()
        {
            InitControllers();

            return View();
        }

        public ActionResult Seguimiento()
        {
            InitControllers();

            return View();
        }
    }
}