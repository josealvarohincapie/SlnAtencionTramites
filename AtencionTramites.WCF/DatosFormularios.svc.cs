using AtencionTramites.Model.Classes;
using AtencionTramites.Model.ModelAtencionTramites;
using AtencionTramites.WCF.Classes;
using System;
using Ultimus.Interfaces;
using Ultimus.Utilitarios;

namespace AtencionTramites.WCF
{
    public partial class DatosFormularios : IDatosFormularios
    {
        UltimusLogs UltimusLogs = new UltimusLogs("DatosFormularios");
    }
}
