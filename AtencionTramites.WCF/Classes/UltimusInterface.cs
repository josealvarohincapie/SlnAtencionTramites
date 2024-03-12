using AtencionTramites.Model.Classes;
using AtencionTramites.Model.ModelAtencionTramites;
using System;
using System.Collections.Generic;
using Ultimus.Interfaces;
using Ultimus.Interfaces.UltimusIntegration;
using AtencionTramites.Model.DAL;
using System.Linq;

namespace AtencionTramites.WCF.Classes
{
    public class UltimusInterface
    {
        //public static int EnviarIncidente(long CodigoSolicitud, string CodigoDecision, string UltimusTaskId, string UltimusUserID, string Summary)
        //{
        //    List<NodeVariables> NodeVariablesList = new List<NodeVariables>();
        //    UltimusIntegrationAPIController UltimusIntegrationAPIController = new UltimusIntegrationAPIController();

        //    UltimusIncident UltimusIncident = UltimusIntegrationAPIController.GetTaskBasic(UltimusUserID, UltimusTaskId);
        //    if (UltimusIncident.Status != 1)
        //        throw new CustomException("La tarea no esta activa");

        //    #region VARIABLES ULTIMUS
        //    NodeVariablesList.Add(new NodeVariables() { NodeName = "TaskData.Global.CodigoSolicitud", NodeValue = CodigoSolicitud });
        //    NodeVariablesList.Add(new NodeVariables() { NodeName = "TaskData.Global.CodigoDecision", NodeValue = CodigoDecision });
        //    #endregion

        //    CompleteTaskJson CompleteTaskJson = new CompleteTaskJson();
        //    CompleteTaskJson.summary = Summary;
        //    CompleteTaskJson.taskId = UltimusTaskId;
        //    CompleteTaskJson.user = UltimusUserID;
        //    CompleteTaskJson.variables = NodeVariablesList;
        //    CompleteTaskJson = UltimusIntegrationAPIController.CompleteTaskV2(CompleteTaskJson);
        //    return CompleteTaskJson.incident;
        //}

        //Clasificación Tramites

        internal void EnviarClasificacionTramites(ClasificacionTramites_RadicadoJSON model)
        {
            UltimusIntegrationAPIController UltimusIntegrationAPIController = new UltimusIntegrationAPIController();
            if (model.Radicado == null)
            {
                model.Radicado = new Radicado();
            }
            CompleteTaskJson CompleteTaskJson = new CompleteTaskJson();
            if (string.IsNullOrEmpty(model.Respuesta.NumeroRadicado))
            {
                CompleteTaskJson.summary = "DESCARTADO";
            }
            else if (string.IsNullOrEmpty(model.Radicado.NumeroRadicado))
            {
                CompleteTaskJson.summary = model.Respuesta.Nombre + " (RADICADO No. " + model.Respuesta.NumeroRadicado + ") " + model.Respuesta.AsuntoDocumento;
            }
            else
            {
                CompleteTaskJson.summary = model.Respuesta.Nombre + " (RADICADO No. " + model.Respuesta.NumeroRadicado + " REF. RADICADO No. " + model.Radicado.NumeroRadicado + ") " + model.Respuesta.AsuntoDocumento + " - " + model.Radicado.NumeroDocumentoIdentificacion;
            }
            CompleteTaskJson.taskId = model.UltimusTaskId;
            CompleteTaskJson.user = model.UltimusUserID;
            CompleteTaskJson.variables = ObtenerVariablesClasificacionTramites(model);
            CompleteTaskJson = UltimusIntegrationAPIController.CompleteTaskV2(CompleteTaskJson);
            if (model.UltimusIncident == 0)
            {
                model.UltimusIncident = CompleteTaskJson.incident;
            }
        }

        private List<NodeVariables> ObtenerVariablesClasificacionTramites(ClasificacionTramites_RadicadoJSON model)
        {
            List<NodeVariables> list = new List<NodeVariables>();
            UltimusDAL UltimusDAL = new UltimusDAL();
            string RecipienteSecretaria = null;
            string RecipienteFuncionario = null;
            string RecipienteAbogado = null;
            string RecipienteAprobador = null;
            string RecipienteVentanilla = null;
            string RecipienteArchivar = null;
            if (model.Respuesta.CodigoRecipienteSecretaria.HasValue)
            {
                string Departamento = UltimusDAL.ObtenerDepartamento(model.Respuesta.CodigoRecipienteSecretaria.Value).NAME;
                RecipienteSecretaria = "GRP:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.RepartoInterno;
                RecipienteAprobador = "GRP:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.Aprobadores;
                RecipienteVentanilla = "GRP:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.VentanillaSecretaria;
                RecipienteArchivar = "QUEUE:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.ArchivoSecretaria;
            }
            if (model.Respuesta.CodigoRecipienteFuncionario.HasValue)
            {
                string Usuario2 = UltimusDAL.ObtenerUsuario(model.Respuesta.CodigoRecipienteFuncionario.Value).NAME;
                RecipienteFuncionario = "USER:org=Business Organization,user=" + Usuario2;
            }
            if (model.Respuesta.CodigoRecipienteAbogado.HasValue)
            {
                string Usuario = UltimusDAL.ObtenerUsuario(model.Respuesta.CodigoRecipienteAbogado.Value).NAME;
                RecipienteAbogado = "USER:org=Business Organization,user=" + Usuario;
            }
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.CodigoSolicitud",
                NodeValue = model.Respuesta.CodigoSolicitud
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.CodigoDecision",
                NodeValue = model.RespuestaDecision.CodigoDecision
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteSecretaria",
                NodeValue = RecipienteSecretaria
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteFuncionario",
                NodeValue = RecipienteFuncionario
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteAbogado",
                NodeValue = RecipienteAbogado
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteAprobador",
                NodeValue = RecipienteAprobador
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteVentanilla",
                NodeValue = RecipienteVentanilla
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteArchivar",
                NodeValue = RecipienteArchivar
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.EsUrgente",
                NodeValue = model.Respuesta.EsUrgente
            });
            return list;
        }

        //Atención Tramites Ase
        internal void EnviarAtencionTramiteAse(AtencionTramiteAse_RadicadoJSON model)
        {
            UltimusIntegrationAPIController UltimusIntegrationAPIController = new UltimusIntegrationAPIController();
            if (model.Radicado == null)
            {
                model.Radicado = new Radicado();
            }
            CompleteTaskJson CompleteTaskJson = new CompleteTaskJson();
            if (string.IsNullOrEmpty(model.Respuesta.NumeroRadicado))
            {
                CompleteTaskJson.summary = "DESCARTADO";
            }
            else if (string.IsNullOrEmpty(model.Radicado.NumeroRadicado))
            {
                CompleteTaskJson.summary = model.Respuesta.Nombre + " (RADICADO No. " + model.Respuesta.NumeroRadicado + ") " + model.Respuesta.AsuntoDocumento;
            }
            else
            {
                CompleteTaskJson.summary = model.Respuesta.Nombre + " (RADICADO No. " + model.Respuesta.NumeroRadicado + " REF. RADICADO No. " + model.Radicado.NumeroRadicado + ") " + model.Respuesta.AsuntoDocumento + " - " + model.Radicado.NumeroDocumentoIdentificacion;
            }
            CompleteTaskJson.taskId = model.UltimusTaskId;
            CompleteTaskJson.user = model.UltimusUserID;
            CompleteTaskJson.variables = ObtenerVariablesEnviarAtencionTramiteAse(model);
            CompleteTaskJson = UltimusIntegrationAPIController.CompleteTaskV2(CompleteTaskJson);
            if (model.UltimusIncident == 0)
            {
                model.UltimusIncident = CompleteTaskJson.incident;
            }
        }

        private List<NodeVariables> ObtenerVariablesEnviarAtencionTramiteAse(AtencionTramiteAse_RadicadoJSON model)
        {
            List<NodeVariables> list = new List<NodeVariables>();
            UltimusDAL UltimusDAL = new UltimusDAL();
            string RecipienteSecretaria = null;
            string RecipienteFuncionario = null;
            string RecipienteAbogado = null;
            string RecipienteAprobador = null;
            string RecipienteVentanilla = null;
            string RecipienteArchivar = null;
            if (model.Respuesta.CodigoRecipienteSecretaria.HasValue)
            {
                string Departamento = UltimusDAL.ObtenerDepartamento(model.Respuesta.CodigoRecipienteSecretaria.Value).NAME;
                RecipienteSecretaria = "GRP:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.RepartoInterno;
                RecipienteAprobador = "GRP:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.Aprobadores;
                RecipienteVentanilla = "GRP:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.VentanillaSecretaria;
                RecipienteArchivar = "QUEUE:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.ArchivoSecretaria;
            }
            if (model.Respuesta.CodigoRecipienteFuncionario.HasValue)
            {
                string Usuario2 = UltimusDAL.ObtenerUsuario(model.Respuesta.CodigoRecipienteFuncionario.Value).NAME;
                RecipienteFuncionario = "USER:org=Business Organization,user=" + Usuario2;
            }
            if (model.Respuesta.CodigoRecipienteAbogado.HasValue)
            {
                string Usuario = UltimusDAL.ObtenerUsuario(model.Respuesta.CodigoRecipienteAbogado.Value).NAME;
                RecipienteAbogado = "USER:org=Business Organization,user=" + Usuario;
            }
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.CodigoSolicitud",
                NodeValue = model.Respuesta.CodigoSolicitud
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.CodigoDecision",
                NodeValue = model.RespuestaDecision.CodigoDecision
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteSecretaria",
                NodeValue = RecipienteSecretaria
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteFuncionario",
                NodeValue = RecipienteFuncionario
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteAbogado",
                NodeValue = RecipienteAbogado
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteAprobador",
                NodeValue = RecipienteAprobador
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteVentanilla",
                NodeValue = RecipienteVentanilla
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteArchivar",
                NodeValue = RecipienteArchivar
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.EsUrgente",
                NodeValue = model.Respuesta.EsUrgente
            });
            return list;
        }

        //Atención Tramites Sol
        internal void EnviarEnviarAtencionTramiteSol(AtencionTramiteSol_RadicadoJSON model)
        {
            UltimusIntegrationAPIController UltimusIntegrationAPIController = new UltimusIntegrationAPIController();
            if (model.Radicado == null)
            {
                model.Radicado = new Radicado();
            }
            CompleteTaskJson CompleteTaskJson = new CompleteTaskJson();
            if (string.IsNullOrEmpty(model.Respuesta.NumeroRadicado))
            {
                CompleteTaskJson.summary = "DESCARTADO";
            }
            else if (string.IsNullOrEmpty(model.Radicado.NumeroRadicado))
            {
                CompleteTaskJson.summary = model.Respuesta.Nombre + " (RADICADO No. " + model.Respuesta.NumeroRadicado + ") " + model.Respuesta.AsuntoDocumento;
            }
            else
            {
                CompleteTaskJson.summary = model.Respuesta.Nombre + " (RADICADO No. " + model.Respuesta.NumeroRadicado + " REF. RADICADO No. " + model.Radicado.NumeroRadicado + ") " + model.Respuesta.AsuntoDocumento + " - " + model.Radicado.NumeroDocumentoIdentificacion;
            }
            CompleteTaskJson.taskId = model.UltimusTaskId;
            CompleteTaskJson.user = model.UltimusUserID;
            CompleteTaskJson.variables = ObtenerVariablesEnviarAtencionTramiteSol(model);
            CompleteTaskJson = UltimusIntegrationAPIController.CompleteTaskV2(CompleteTaskJson);
            if (model.UltimusIncident == 0)
            {
                model.UltimusIncident = CompleteTaskJson.incident;
            }
        }

        private List<NodeVariables> ObtenerVariablesEnviarAtencionTramiteSol(AtencionTramiteSol_RadicadoJSON model)
        {
            List<NodeVariables> list = new List<NodeVariables>();
            UltimusDAL UltimusDAL = new UltimusDAL();
            string RecipienteSecretaria = null;
            string RecipienteFuncionario = null;
            string RecipienteAbogado = null;
            string RecipienteAprobador = null;
            string RecipienteVentanilla = null;
            string RecipienteArchivar = null;
            if (model.Respuesta.CodigoRecipienteSecretaria.HasValue)
            {
                string Departamento = UltimusDAL.ObtenerDepartamento(model.Respuesta.CodigoRecipienteSecretaria.Value).NAME;
                RecipienteSecretaria = "GRP:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.RepartoInterno;
                RecipienteAprobador = "GRP:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.Aprobadores;
                RecipienteVentanilla = "GRP:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.VentanillaSecretaria;
                RecipienteArchivar = "QUEUE:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.ArchivoSecretaria;
            }
            if (model.Respuesta.CodigoRecipienteFuncionario.HasValue)
            {
                string Usuario2 = UltimusDAL.ObtenerUsuario(model.Respuesta.CodigoRecipienteFuncionario.Value).NAME;
                RecipienteFuncionario = "USER:org=Business Organization,user=" + Usuario2;
            }
            if (model.Respuesta.CodigoRecipienteAbogado.HasValue)
            {
                string Usuario = UltimusDAL.ObtenerUsuario(model.Respuesta.CodigoRecipienteAbogado.Value).NAME;
                RecipienteAbogado = "USER:org=Business Organization,user=" + Usuario;
            }
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.CodigoSolicitud",
                NodeValue = model.Respuesta.CodigoSolicitud
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.CodigoDecision",
                NodeValue = model.RespuestaDecision.CodigoDecision
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteSecretaria",
                NodeValue = RecipienteSecretaria
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteFuncionario",
                NodeValue = RecipienteFuncionario
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteAbogado",
                NodeValue = RecipienteAbogado
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteAprobador",
                NodeValue = RecipienteAprobador
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteVentanilla",
                NodeValue = RecipienteVentanilla
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteArchivar",
                NodeValue = RecipienteArchivar
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.EsUrgente",
                NodeValue = model.Respuesta.EsUrgente
            });
            return list;
        }

        //Atención Tramites Que
        internal void EnviarEnviarAtencionTramiteQue(AtencionTramiteQue_RadicadoJSON model)
        {
            UltimusIntegrationAPIController UltimusIntegrationAPIController = new UltimusIntegrationAPIController();
            if (model.Radicado == null)
            {
                model.Radicado = new Radicado();
            }
            CompleteTaskJson CompleteTaskJson = new CompleteTaskJson();
            if (string.IsNullOrEmpty(model.Respuesta.NumeroRadicado))
            {
                CompleteTaskJson.summary = "DESCARTADO";
            }
            else if (string.IsNullOrEmpty(model.Radicado.NumeroRadicado))
            {
                CompleteTaskJson.summary = model.Respuesta.Nombre + " (RADICADO No. " + model.Respuesta.NumeroRadicado + ") " + model.Respuesta.AsuntoDocumento;
            }
            else
            {
                CompleteTaskJson.summary = model.Respuesta.Nombre + " (RADICADO No. " + model.Respuesta.NumeroRadicado + " REF. RADICADO No. " + model.Radicado.NumeroRadicado + ") " + model.Respuesta.AsuntoDocumento + " - " + model.Radicado.NumeroDocumentoIdentificacion;
            }
            CompleteTaskJson.taskId = model.UltimusTaskId;
            CompleteTaskJson.user = model.UltimusUserID;
            CompleteTaskJson.variables = ObtenerVariablesEnviarAtencionTramitQue(model);
            CompleteTaskJson = UltimusIntegrationAPIController.CompleteTaskV2(CompleteTaskJson);
            if (model.UltimusIncident == 0)
            {
                model.UltimusIncident = CompleteTaskJson.incident;
            }
        }

        private List<NodeVariables> ObtenerVariablesEnviarAtencionTramitQue(AtencionTramiteQue_RadicadoJSON model)
        {
            List<NodeVariables> list = new List<NodeVariables>();
            UltimusDAL UltimusDAL = new UltimusDAL();
            string RecipienteSecretaria = null;
            string RecipienteFuncionario = null;
            string RecipienteAbogado = null;
            string RecipienteAprobador = null;
            string RecipienteVentanilla = null;
            string RecipienteArchivar = null;
            if (model.Respuesta.CodigoRecipienteSecretaria.HasValue)
            {
                string Departamento = UltimusDAL.ObtenerDepartamento(model.Respuesta.CodigoRecipienteSecretaria.Value).NAME;
                RecipienteSecretaria = "GRP:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.RepartoInterno;
                RecipienteAprobador = "GRP:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.Aprobadores;
                RecipienteVentanilla = "GRP:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.VentanillaSecretaria;
                RecipienteArchivar = "QUEUE:org=Business Organization,grp=" + Departamento + "*" + Constantes.Grupos.ArchivoSecretaria;
            }
            if (model.Respuesta.CodigoRecipienteFuncionario.HasValue)
            {
                string Usuario2 = UltimusDAL.ObtenerUsuario(model.Respuesta.CodigoRecipienteFuncionario.Value).NAME;
                RecipienteFuncionario = "USER:org=Business Organization,user=" + Usuario2;
            }
            if (model.Respuesta.CodigoRecipienteAbogado.HasValue)
            {
                string Usuario = UltimusDAL.ObtenerUsuario(model.Respuesta.CodigoRecipienteAbogado.Value).NAME;
                RecipienteAbogado = "USER:org=Business Organization,user=" + Usuario;
            }
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.CodigoSolicitud",
                NodeValue = model.Respuesta.CodigoSolicitud
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.CodigoDecision",
                NodeValue = model.RespuestaDecision.CodigoDecision
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteSecretaria",
                NodeValue = RecipienteSecretaria
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteFuncionario",
                NodeValue = RecipienteFuncionario
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteAbogado",
                NodeValue = RecipienteAbogado
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteAprobador",
                NodeValue = RecipienteAprobador
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteVentanilla",
                NodeValue = RecipienteVentanilla
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.RecipienteArchivar",
                NodeValue = RecipienteArchivar
            });
            list.Add(new NodeVariables
            {
                NodeName = "TaskData.Global.EsUrgente",
                NodeValue = model.Respuesta.EsUrgente
            });
            return list;
        }
    }
}