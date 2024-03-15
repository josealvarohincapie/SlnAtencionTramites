using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Ultimus.Utilitarios;
using AtencionTramites.Model.Classes;
using AtencionTramites.Model.ModelAtencionTramites;
using AtencionTramites.WCF.Classes;
using Ultimus.Interfaces;
using System.ServiceModel.Activation;

namespace AtencionTramites.WCF
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public partial class AtencionTramiteQue : IAtencionTramiteQue
    {
        UltimusLogs UltimusLogs = new UltimusLogs("AtencionTramiteQue");
        public void DoWork()
        {
        }
    }
}