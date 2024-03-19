using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ultimus.Interfaces.UltimusForm;
using Ultimus.Utilitarios;

namespace AtencionTramites.Controllers
{
    public class AtencionTramiteSolController : BaseController
    {
        UltimusLogs UltimusLogs = new UltimusLogs("AtencionTramiteSolController");
       
        public ActionResult Seguimiento()
        {
            InitControllers();

            return View();
        }

        public ActionResult GestionPeticion()
        {
            InitControllers();

            return View();
        }
        public ActionResult SeguimientoPeticion()
        {
            InitControllers();

            return View();
        }
        public ActionResult GenerarDocumento()
        {
            InitControllers();

            return View();
        }
        public ActionResult RevisionVistoBueno()
        {
            InitControllers();

            return View();
        }
        public ActionResult EtapaAprobar()
        {
            InitControllers();

            return View();
        }
        public ActionResult EtapaVerificar()
        {
            InitControllers();

            return View();
        }
        public ActionResult EtapaArchivar()
        {
            InitControllers();

            return View();
        }
    }
}