BPMComplementFramework
=====================================
Atención

1. El proyecto que use este paquete debe usar el .Net Framework 4.5.1

2. El desarrollador debe agregar al archivo _Layout.cshtml o _Layout.vbhtml el siguiente código
   @Scripts.Render("~/Scripts/Ultimus-Framework")
   @Html.Raw(new Ultimus.Framework.ResourceTrasform().GetTemplateHTML())
   <link href="~/Scripts/summernote/summernote.css" rel="stylesheet" />
   
3. Luego de instalado el paquete, debe registrar el archivo UltimusFramework.intellisense.js en el IDE de Visual Studio.

	A. Ir a TOOLS->Options->

    B. En la lista de opciones seleccionar TextEditor->Javascript->Intellisense->references	

    C. En “Reference Group” seleccionar “Implicit Web”
	
	D. En agregue la referencia : **~/Scripts/ UltimusFramework.intellisense.js**
	
	E. Presione OK y listo.
	
	
	
	
ULTIMUS PANAMA Y LATINOAMERICA