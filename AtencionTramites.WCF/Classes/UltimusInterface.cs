using AtencionTramites.Model.Classes;
using System;
using System.Collections.Generic;
using Ultimus.Interfaces;
using Ultimus.Interfaces.UltimusIntegration;

namespace AtencionTramites.WCF.Classes
{
    public class UltimusInterface
    {
        public static int EnviarIncidente(long CodigoSolicitud, string CodigoDecision, string UltimusTaskId, string UltimusUserID, string Summary)
        {
            List<NodeVariables> NodeVariablesList = new List<NodeVariables>();
            UltimusIntegrationAPIController UltimusIntegrationAPIController = new UltimusIntegrationAPIController();

            UltimusIncident UltimusIncident = UltimusIntegrationAPIController.GetTaskBasic(UltimusUserID, UltimusTaskId);
            if (UltimusIncident.Status != 1)
                throw new CustomException("La tarea no esta activa");

            #region VARIABLES ULTIMUS
            NodeVariablesList.Add(new NodeVariables() { NodeName = "TaskData.Global.CodigoSolicitud", NodeValue = CodigoSolicitud });
            NodeVariablesList.Add(new NodeVariables() { NodeName = "TaskData.Global.CodigoDecision", NodeValue = CodigoDecision });
            #endregion

            CompleteTaskJson CompleteTaskJson = new CompleteTaskJson();
            CompleteTaskJson.summary = Summary;
            CompleteTaskJson.taskId = UltimusTaskId;
            CompleteTaskJson.user = UltimusUserID;
            CompleteTaskJson.variables = NodeVariablesList;
            CompleteTaskJson = UltimusIntegrationAPIController.CompleteTaskV2(CompleteTaskJson);
            return CompleteTaskJson.incident;
        }
    }
}