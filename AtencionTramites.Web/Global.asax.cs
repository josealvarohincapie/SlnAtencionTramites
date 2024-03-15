using AtencionTramites;
using System;
using System.Collections.Generic;
using System;
using System.Web;
using System.Web.Http;
using AtencionTramites;

public class Global : HttpApplication
{
    private void Application_Start(object sender, EventArgs e)
    {
        GlobalConfiguration.Configure(WebApiConfig.Register);
    }
}