using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ultimus.Interfaces.UltimusForm;
using Ultimus.Utilitarios;

namespace AtencionTramites.Controllers
{
    public class ClasificacionTramitesController : BaseController
    {
        UltimusLogs UltimusLogs = new UltimusLogs("ClasificacionTramitesController");

        public ActionResult Radicado()
        {
            InitControllers();

            return View();
        }

        public ActionResult Seguimiento()
        {
            InitControllers();

            return View();
        }

        public ActionResult ClasificacionTramite()
        {
            InitControllers();

            return View();
        }
    }
}