
//#region EXTENSIONES

jQuery.fn.disable = function () {
    /// <signature>
    ///   <summary>inhabilita un control. Ejemplo: $("#IDControl").disable();</summary>
    ///   <returns type="jQuery" />
    /// </signature>
}

jQuery.fn.enable = function () {
    /// <signature>
    ///   <summary>habilita un control. Ejemplo: $("#IDControl").enable();</summary>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.reset = function () {
    /// <signature>
    ///   <summary> limpia  un formulario. Ejemplo= $("#IDForm").reset();</summary>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.EnableValidationToolTip = function () {
    /// <signature>
    ///   <summary> habilita el tooltip para los controles requeridos contenido en el formulario</summary>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.required = function () {
    /// <signature>
    ///   <summary>coloca un control como requerido. Ejemplo= $("#IDControl").required();</summary>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.noRequired = function () {
    /// <signature>
    ///   <summary>coloca un control como no requerido. Ejemplo= $("#IDControl").noRequired();</summary>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.validateElement = function (controlId) {
    /// <signature>
    ///   <summary> verifica un objeto requerido. Ejemplo= $("#IDForm").validateElement("#IDControl");</summary>
    ///   <param name="controlId" type="string"> Id del control  </param>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.setByText = function (value) {
    /// <signature>
    ///   <summary> coloca como seleccionado un item de la lista del un control tipo "select" por descripción. Ejemplo= $("#IDControl").setByText();</summary>
    ///   <param name="value" type="string">   </param>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.addCustomRule = function (CustomValidation) {
    /// <signature>
    ///   <summary> agrega una regla personalizada a un control en especifico.  </summary>
    ///   <param name="CustomValidation" type="function">función que valida, correcto retorna un string en vácio y cuando no el mensaje</param>
    ///   <returns type="void" />
    /// </signature> 
}

jQuery.fn.dateFormatNoTime = function (value, format) {
    /// <signature>
    ///   <summary> formatea una fecha proveniente de del WebAPI o servicio a string sin las horas, minutos y segundos. Ejemplo=  $("#IDControl").dateFormatNoTime(objeto.fecha,formato); </summary>
    ///   <param name="value" type="Date"> fecha </param>
    ///   <param name="format" type="string">opcional. formato por defecto "DD-MMMM-YYYY" </param>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.dotNetFormat = function (formato) {
    /// <signature>
    ///   <summary> lee el texto de un control y retorna un string en formato "MM-DD-YYYY" </summary>
    ///   <param name="format" type="string">opcional. el formato por defecto  es "DD-MMMM-YYYY" </param>
    ///   <returns type="string" />
    /// </signature>
}

jQuery.fn.Datepicker = function (params) {
    /// <signature>
    ///   <summary> lee el texto de un control y retorna un objeto Date </summary>
    ///   <param name="params" type="object">opcional. se definen sus propiedades yearRange y beforeShowDay </param>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.Grid = function (action, object, FunctionCallBack) {
    /// <signature>
    ///   <summary> permite configurar, actualizar o recargar un control tipo Grid. Ejemplo $("#IDGrid").Grid('BuildGrid') </summary>
    ///   <param name="action" type="string">acción disponibles "Get", "Set", "BuildGrid", "RenderGrid", "RowEvent", "Refresh", "Remove", "OnDraw", "OnPaginationChange", "OnAfterConfigEditGrid" o "setCustomSettings"</param>
    ///   <param name="object" type="object">opcional. Para la accion RenderGrid se requiere una lista de objetos, para las acciones RowEvent(IdTarget,data) y setCustomSettings(Settings) se requiere una función para manipular los Settings del Grid. Ejemplo $("#IDGrid").Grid('setCustomSettings',function(settings){return settings;}); </param>
    ///   <param name="FunctionCallBack" type="function">opcional. función que activará una vez termine de cargar la tabla. Ejemplo $("#IDGrid").Grid('BuildGrid',function(){}); </param>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.ButtonSwitch = function (action, value) {
    /// <signature>
    ///   <summary> permite leer, actualizar, inhabilitar o colocar como no requerido un control de tipo ButtonSwitch </summary>
    ///   <param name="action" type="string">acción a ejecutar (set,get,disable, hide o required)</param>
    ///   <param name="value" type="object">opcional. solo es requerido para el set, disable, hide y required </param>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.CargarFirma = function (UserID) {
    /// <signature>
    ///   <summary> coloca como firmado el control firma, para formularios donde ya el usuario firmó. Ejemplo= $("#divIDControlFramework").CargarFirma(); </summary>
    ///   <param name="UserID" type="string">opcional. por defecto usa el UserID actual.</param>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.Catalogo = function (action, object) {
    /// <signature>
    ///   <summary> permite habilitar un catalogo simple o multiple, colocarlo como requerido o limpiarlo. usar objeto div </summary>
    ///   <param name="action" type="string"> acciones disponible "show", "required", "clear" y "disable" </param>
    ///   <param name="object" type="object"></param>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.DropDownList = function (action, object) {
    /// <signature>
    ///   <summary> permite cargar o cambiar los párametros de entrada del web api</summary>
    ///   <param name="action" type="string"> acciones disponible load, getselected, getall, setselected, remove, clear, add y addlist </param>
    ///   <param name="object" type="object">con las propiedades  HttpPost, value, text y Data </param>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.Readonly = function (value) {
    /// <signature>
    ///   <summary>coloca un control como solo lectura o viceversa</summary>
    ///   <param name="value" type="bool"> valor booleano para el atributo readonly</param>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.TableInit = function (columnOrder, order, bPaginate, bFilter, bInfo, columnDefinition, data, ScrollX, bLengthMenu, fnDrawCallback, fnPaginationChange) {
    /// <signature> 
    ///   <summary> aplica las propiedades del plugin Jquery DataTable a un objeto tabla</summary>
    ///   <param name="columnOrder" type="string"> orden ascendente asc o descendente desc </param>
    ///   <param name="order" type="int"> id de la columna para el reordenamiento  </param>
    ///   <param name="bPaginate" type="bool"> permitir paginación </param>
    ///   <param name="bFilter" type="bool"> permitir filtros </param>
    ///   <param name="bInfo" type="bool"> permitir detalles </param>
    ///   <param name="columnDefinition" type="object"> objeto con la configuracion de las columnas </param>
    ///   <param name="data" type="Array"> lista de objetos </param>        
    ///   <param name="ScrollX" type="bool">opcional. habilitar el scroll en el eje X </param>        
    ///   <param name="bLengthMenu" type="Array">opcional. permite definir la cantidad mínima y máxima para filtrar la lista ejemplo: [5,25]. nota: los números desplegados será multiplos del valor mínimo.</param>        
    ///   <param name="fnDrawCallback" type="function"> funcion que se invoca al despues de renderizar la tabla </param>        
    ///   <param name="fnPaginationChange" type="function"> funcion que se invoca cuando cambia de pagina </param>        
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.CustomMask = function (mask) {
    /// <signature>
    ///   <summary>aplica una mascar. definicios especiales: #->[9], $->[aA], M->[0-9A-Za-zñÑáéíóúÁÉÍÓÚ ], L->[A-Za-zñÑáéíóúÁÉÍÓÚ ]. https://github.com/RobinHerbots/Inputmask </summary>
    ///   <param name="mask" type="object"> objeto mascara: {mask"",placeholder:""}</param>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.DocumentList = function (action, object, FunctionCallBack) {
    /// <signature>
    ///   <summary>permite leer la configuracion del control, agregar columnas y encabezado</summary>
    ///   <param name="mask" type="action">las acciones son set, get, setheader, hidecolumn, addcolumn</param>
    ///   <param name="mask" type="object"> objeto para agregar columnas o encabezado</param>
    ///   <param name="mask" type="FunctionCallBack">opcional, se invoca despues de terminar</param>
    ///   <returns type="void" />
    /// </signature>
}

jQuery.fn.DocumentsDozzier = function (action, object, FunctionCallBack) {
    /// <signature>
    ///   <summary>permite configurar, cargar, leer, limpiar o validar los documentos de Dozzier </summary>
    ///   <param name="mask" type="action">las acciones son:set, get, load, build, disable, validate y clear </param>
    ///   <param name="mask" type="object"> objeto opcional para indicar si se inhabilita, o configurar el control</param>
    ///   <param name="mask" type="FunctionCallBack">opcional, se invoca despues de terminar</param>
    ///   <returns type="void" />
    /// </signature>
}

//#endregion

this.isMobile = {
    Android: function () { }
    , BlackBerry: function () { }
    , iOS: function () { }
    , Opera: function () { }
    , Windows: function () { }
    , any: function () { }
}

this.UltimusTask = function () {

    this.Incident = null;
    this.Process = null;
    this.Status = null;
    this.Version = null;
    this.User = null;
    this.UserFullName = null;
    this.UserEmail = null;
    this.Supervisor = null;
    this.SupervisorFullName = null;
    this.JobFunction = null;
    this.Step = null;
    this.TaskId = null;
    this.NodeVariablesList = new Array();

    this.StartTime = null;
    this.EndTime = null;
    this.Memo = null;
    this.SubStatus = null;
    this.Priority = null;
    this.Summary = null;
    this.XmlData = null;
}

this.NodeVariables = function () {
    this.NodeName = null;
    this.NodeValue = null;
    this.NodeValues = null;
}

this.Ultimus = {
    // url del site formato: (protocolo/hostname/nameapplication/). Ejemplo: "http://localhost/test/"
    server: null

    // ID del catálogo a actual o a desplegar
    , SelectedCatalog: null

    // mensaje: "PROCESO COMPLETADO"
    , Message_Success: null

    // mensaje: "ADVERTENCIA DEL SISTEMA"
    , Message_Warning: null

    // mensaje: "INFORMACIÓN DEL SISTEMA"
    , Message_Info: null

    // mensaje: "ERROR INESPERADO"
    , Message_Error: null

    // mensaje: "Ha ocurrido un error inesperado. Vuelva a intentarlo mas tarde"
    , MessageFull_Error: null

     , GetControlsSettings: function (keyfiltro, keyformulario, form, DataModel) {
         /// <signature>
         ///   <summary>Obtiene la configuración de los controles por filtro y formulario desde el BPMComplement</summary>
         ///   <param name="keyfiltro" type="string">nombre filtro en el BPMComplement</param>
         ///   <param name="keyformulario" type="string">nombre formulario en el BPMComplement</param>
         ///   <param name="form" type="string">ID objeto form de la vista</param>
         ///   <param name="DataModel" type="bool">si es true llamará al método getDataModel</param>
         ///   <returns type="void" />
         /// </signature>
     }

    , UpdateControlsSettings: function (keyfiltro, keyformulario, form, FunctionCallBack, ShowLoadScreen,CustomProcess) {
        /// <signature>
        ///   <summary>Obtiene la configuración de los controles por filtro y formulario desde el BPMComplement y llama una funcion especifica</summary>
        ///   <param name="keyfiltro" type="string">nombre filtro en el BPMComplement</param>
        ///   <param name="keyformulario" type="string">nombre formulario en el BPMComplement</param>
        ///   <param name="form" type="string">ID objeto form de la vista</param>
        ///   <param name="FunctionCallBack" type="function">function que llamará una vez termine de cargar los settings</param>
        ///   <param name="ShowLoadScreen" type="bool">opcional permite habilitar el telon de carga</param>
        ///   <param name="CustomProcess" type="string">opcional nombre proceso especifico </param>
        ///   <returns type="void" />
        /// </signature>
    }

    , GetControlsSettingsByParam: function (form, KeyFormulario, params, FunctionCallBack, NombreTipoEvaluacion) {
        /// <signature>
        ///   <summary>Obtiene la configuración de los controles por filtro y formulario en base a las reglas del validador de parametros desde el BPMComplement y llama una funcion especifica. las reglas se deben configurar con el tipo de evaluacion "BPMComplementControlSettings"</summary>
        ///   <param name="form" type="string">ID objeto form de la vista</param>
        ///   <param name="KeyFormulario" type="object">nombre del KeyFormulario en el bpmcomplement</param>     
        ///   <param name="params" type="list">opcional: lista de parametros= [ {NombreParametro:"Param1" Valor:"A"}  ] </param>     
        ///   <param name="FunctionCallBack" type="function">opcional: function que llamará una vez termine de cargar los settings</param>
        ///   <param name="NombreTipoEvaluacion" type="string">opcional: si desea usar un tipo de evaluacion personalizado. por defecto su valor es "BPMComplementControlSettings"</param>
        ///   <returns type="void" />
        /// </signature>
    }

     , getDataModel: function () {
         /// <signature>
         ///   <summary>se activa una vez termina de cargar el método GetControlsSettings y su párametro DataModel sea igual a true.</summary>
         ///   <returns type="void" />
         /// </signature>
     }

     , DataCatalogo: function (SelectedCatalog, data) {
         /// <signature>
         ///   <summary>Evento que se activa al seleccionar un item de la lista del catálogo</summary>
         ///   <param name="SelectedCatalog" type="string">ID del catálogo</param>
         ///   <param name="data" type="object">objeto fila del DataTable</param>
         ///   <returns type="void" />
         /// </signature>
     }

     , CargarDataCatalogo: function (Direccion, filtro, n) {
         /// <signature>
         ///   <summary>Carga el WebAPi y despliega el catálogo en cuestion</summary>
         ///   <param name="Direccion" type="string">Url del WebAPI, esta en los atributos del boton del catálogo. Ejemplo: $('#btnIDcatálogo').attr("Direccion_API");</param>
         ///   <param name="filtro" type="string">opcional, se puede emitir un filtro para una busqueda más personalizada</param>
         ///   <param name="n" type="string">opcional, despúes del párametro filtro puede recibir n paraemtros que se incluirán dinamicamente en el request. para una lista larga de pármetros se recomienda usar un objeto compuesto.</param>
         ///   <returns type="void" />
         /// </signature>
     }

     , DisableCatalog: function (Id, disable) {
         /// <signature>
         ///   <summary>Inhabilita o viceversa un catálogo</summary>
         ///   <param name="Id" type="string">Id del catálogo registrado en el BPMComplement</param>
         ///   <param name="disable" type="bool"></param>
         ///   <returns type="void" />
         /// </signature>
     }

     , BuildGrid: function (ModelTabla, model, FunctionCallBack) {
         /// <signature>
         ///   <summary>Carga los datos del Grid desde el WebAPI</summary>
         ///   <param name="ModelTabla" type="object">propiedades y settings del Grid, estas se pueden obetener con el evento getSettingsGrid</param>    
         ///   <param name="model" type="object">objeto que será enviado como parámetro al WebAPI</param>    
         ///   <param name="model" type="function">opcional, una vez termine de cargar se llamará a esta funcion</param>    
         ///   <returns type="void" />
         /// </signature>
     }

     , RenderGrid: function (ModelTabla) {
         /// <signature>
         ///   <summary>renderiza o actualiza el Grid con los nuevos settings o datos seteados en (ModelTabla.GridSettings.data)</summary>
         ///   <param name="ModelTabla" type="object">propiedades y settings del Grid, estas se pueden obetener con el evento getSettingsGrid</param>     
         ///   <returns type="void" />
         /// </signature>
     }

     , getSettingsGrid: function (ModelTabla) {
         /// <signature>
         ///   <summary>se activa en por cada evento que ocurre en una fila del Grid</summary>
         ///   <param name="ModelTabla" type="object">propiedades y settings del Grid</param>     
         ///   <returns type="void" />
         /// </signature>
     }

     , GridRowEvent: function (IDGrid, IDTarget, Data) {
         /// <signature>
         ///   <summary>se activa en por cada evento que ocurre en una fila del Grid</summary>
         ///   <param name="IDGrid" type="string">Id del Grid sobre cual ocurrió el evento</param>     
         ///   <param name="IDTarget" type="string">Id del control dentro de la fila del Grid</param>     
         ///   <param name="Data" type="object">objeto fila con todas las propiedades del modelo</param>     
         ///   <returns type="void" />
         /// </signature>
     }

     , setCustomSettingsDataGrid: function (IDGrid, Settings) {
         /// <signature>
         ///   <summary>se activa justo antes de renderizar el Grid. esto permite agregar nuevos controles en las columnas y manipular la información antes de renderizar el Grid</summary>
         ///   <param name="IDGrid" type="string">Id del Grid sobre cual ocurrió</param>     
         ///   <param name="Settings" type="string">Configuración actual del Grid, la lista devuelta por el WebAPI se encuentra en la propiedad Settings.data</param>     
         ///   <returns type="void" />
         /// </signature>
     }

     , swapDataTableRows: function (id, row1Index, row2Index) {
         /// <signature>
         ///   <summary> intercambias dos filas de una misma tabla </summary>
         ///   <param name="id" type="string"> id de la tabla </param>   
         ///   <param name="row1Index" type="string"> posición fila 1  </param>   
         ///   <param name="row2Index" type="string"> posición fila 2 </param>   
         ///   <returns type="void" />
         /// </signature>
     }

     , HeaderToggle: function () {
         /// <signature>
         ///   <summary>permite colapsar o viceversa el menú de pantallas y el logo del formulario</summary>
         ///   <returns type="void" />
         /// </signature>
     }

     , LoadMessage: function (Message) {
         /// <signature>
         ///   <summary>despliega el toast de carga</summary>
         ///   <param name="Message" type="string">opcional. mensaje personalizado</param>   
         ///   <returns type="void" />
         /// </signature>
     }

     , ENDREQUEST: function () {
         /// <signature>
         ///   <summary>oculta el toast de carga</summary>
         ///   <returns type="void" />
         /// </signature>
     }

     , IsNullOrEmpty: function (value) {
         /// <signature>
         ///   <summary>verifica si un string es nulo o vacio o con espacios en blanco</summary>
         ///   <param name="value" type="string"></param>   
         ///   <returns type="bool" />
         /// </signature>
     }

     , replaceAll: function (find, replace, str) {
         /// <signature>
         ///   <summary> reemplaza un texto por otro en una cadena especifica</summary>
         ///   <param name="find" type="string"> texto a reemplazar </param>   
         ///   <param name="replace" type="string"> texto nuevo </param>   
         ///   <param name="str" type="string"> cadena donde se realizará el reemplazo </param>   
         ///   <returns type="string" />
         /// </signature>
     }

     , getUrlParameter: function (sParam) {
         /// <signature>
         ///   <summary> lee un parametro especifico del request </summary>
         ///   <param name="sParam" type="string"> ID del parámetro  </param>   
         ///   <returns type="string" />
         /// </signature>
     }

     , UpdateRequestParam: function (param, value, url) {
         /// <signature>
         ///   <summary> actualiza un parametro especifico del request y retorna la url para su redirección </summary>
         ///   <param name="param" type="string"> ID del parámetro  </param>   
         ///   <param name="value" type="string"> valor nuevo  </param>  
         ///   <param name="url" type="string">opcional.  url personalizado. si es nulo automáticamente por defecto usa el del request </param>   
         ///   <returns type="string" />
         /// </signature>
     }

     , GetInternetExplorerVersion: function () {
         /// <signature>
         ///   <summary> retorna la version de IE(..8,9,10,etc.), sino es IE devolverá -1 </summary>  
         ///   <returns type="int" />
         /// </signature>
     }

     , OmitirAcentos: function (text) {
         /// <signature>
         ///   <summary> recorre una cadena y reemplaza las vocales acentuadas </summary>  
         ///   <param name="text" type="string">  </param>   
         ///   <returns type="string" />
         /// </signature>
     }

     , RedirectToAction: function (Controller, View, customUrl) {
         /// <signature>
         ///   <summary> redirecciona a un controller y vista en especifico </summary>  
         ///   <param name="Controller" type="string"> nombre del controlador </param>   
         ///   <param name="View" type="string"> nombre de la vista </param>   
         ///   <param name="customUrl" type="string"> opcional, utiliza esta url como base para redireccionar </param>   
         ///   <returns type="void" />
         /// </signature>
     }

     , GetDateFormatNoTime: function (value, format) {
         /// <signature>
         ///   <summary> formatea una fecha proveniente de del WebAPI o servicio a string sin las horas, minutos y segundos. Ejemplo: GetDateFormatNoTime(objeto.fecha,formato); </summary>
         ///   <param name="value" type="Date"> fecha </param>
         ///   <param name="format" type="string">opcional. formato por defecto "DD-MMMM-YYYY" </param>
         ///   <returns type="string" />
         /// </signature>
     }

     , CompleteTask: function (Task, FunctionCallBack) {
         /// <signature>
         ///   <summary> completa una tarea de Ultimus </summary>
         ///   <param name="Task" type="UltimusTask"> objteto tarea, que permite enviar un summary o memo. por defecto ya carga cargado el UserID y el TaskID </param>
         ///   <param name="FunctionCallBack" type="function">opcional. permite llamar una función personalizada al terminar de completar la tarea. </param>
         ///   <returns type="void" />
         /// </signature>
     }

      , GetTaskWithVariables: function (Task, FunctionCallBack) {
          /// <signature>
          ///   <summary> obtiene una tarea en especifico y una lista de variables especifica </summary>
          ///   <param name="Task" type="UltimusTask"> objteto tarea, que permite definir en la propiedad NodeVariablesList que variables del mapa deseamos leer. por defecto ya carga cargado el UserID y el TaskID </param>
          ///   <param name="FunctionCallBack" type="function">permite llamar una función personalizada al terminar de completar la carga de la tarea. </param>
          ///   <returns type="void" />
          /// </signature>
      }

      , IsMemberOfGroup: function (Group, FunctionCallBack, UserID) {
          /// <signature>
          ///   <summary> permite verificar si el usuario actual o uno en especifico pertenece a un grupo del OrgChart. está función es sincrona. </summary>
          ///   <param name="Group" type="string"> nombre del grupo en el OrgChar</param>
          ///   <param name="UserID" type="string">opcional. sirve para validar un usuario que no es el actual </param>
          ///   <returns type="bool" />
          /// </signature>
      }

      , AjaxPostData: function (url, model, IsASync, CheckCodRespuesta, FunctionCallBack, minCallLevel, CustomMessageExitoso) {
          /// <signature>
          ///   <summary> permite hacer una petición tipo POST con AJax a un WebAPI o Servicio </summary>
          ///   <param name="url" type="string"> ruta del WebAPI o Servicio. cuando es WebAPI debe concatenar la variable server+url del WebAPI </param>
          ///   <param name="model" type="object"> objeto a enviar al servicio </param>
          ///   <param name="IsASync" type="bool"> indica si la petición de Ajax es asincrona o no</param>
          ///   <param name="CheckCodRespuesta" type="bool"> indica si emite mensaje de EXITOSO , ADVERTENCIA o ERROR según respuesta del servicio. </param>
          ///   <param name="FunctionCallBack" type="function">opcional. funcion que activará una vez responda el servicio </param>
          ///   <param name="minCallLevel" type="string">opcional. indica el nivel minimo para llamar a la función ya se a EXITOSO , ADVERTENCIA o ERROR. al ser null se asume como el nivel EXITOSO  </param>
          ///   <param name="CustomMessageExitoso" type="string">opcional. mensaje personalizado para respuesta EXITOSO  </param>
          ///   <returns type="object" />
          /// </signature>
      }

      , AjaxGetData: function (url, IsASync, CheckCodRespuesta, FunctionCallBack, minCallLevel, CustomMessageExitoso) {
          /// <signature>
          ///   <summary> permite hacer una petición tipo GET con AJax a un WebAPI o Servicio </summary>
          ///   <param name="url" type="string"> ruta del WebAPI o Servicio. cuando es WebAPI debe concatenar la variable server+url del WebAPI </param>
          ///   <param name="model" type="object"> objeto a enviar al servicio </param>
          ///   <param name="IsASync" type="bool"> indica si la petición de Ajax es asincrona o no</param>
          ///   <param name="CheckCodRespuesta" type="bool"> indica si emite mensaje de EXITOSO , ADVERTENCIA o ERROR según respuesta del servicio. </param>
          ///   <param name="FunctionCallBack" type="function">opcional. funcion que activará una vez responda el servicio </param>
          ///   <param name="minCallLevel" type="string">opcional. indica el nivel minimo para llamar a la función ya se a EXITOSO , ADVERTENCIA o ERROR. al ser null se asume como el nivel EXITOSO  </param>
          ///   <param name="CustomMessageExitoso" type="string">opcional. mensaje personalizado para respuesta EXITOSO  </param>
          ///   <returns type="object" />
          /// </signature>
      }

      , GetAge: function (fecha, formato) {
          /// <signature>
          ///   <summary>calcula el total de años, meses y días, devuelve un objeto con las propiedades (Date, Years, Months, TotalMonths y TotalDays )</summary>
          ///   <param name="fecha" type="string">fecha</param>   
          ///   <param name="formato" type="string">formato de la fecha suministrada</param>   
          ///   <returns type="object" />
          /// </signature>
      }

    , CustomNumberFormat: function (value, decimal_places, symbol, thousand_separator, decimal_separator) {
        /// <signature>
        ///   <summary>permite personalizar el formato de un número</summary>
        ///   <param name="value" type="string">valor a formatear</param>   
        ///   <param name="decimal_places" type="int">número de digitos despues del punto</param>    
        ///   <param name="symbol" type="string">opcional, simbolo personalizado, por ejemplo para monedas o porcentajes</param>   
        ///   <param name="thousand_separator" type="string">opcional, por defecto es una coma [,]</param>   
        ///   <param name="decimal_separator" type="string">opcional, por defecto es un punto [.]</param>   
        ///   <returns type="string" />
        /// </signature>
    }

      , SetMaxCharacter: function (id, MaxLength) {
          /// <signature>
          ///   <summary>define el limite de caracteres permitidos en una textbox</summary>
          ///   <param name="id" type="string">id del control</param>   
          ///   <param name="MaxLength" type="int">longitud máxima</param>   
          ///   <returns type="void" />
          /// </signature>
      }

       , SetPopoverMaxCharacter: function (id, MaxLength) {
           /// <signature>
           ///   <summary>define el limite de caracteres permitidos en una textbox y coloca un tooltip flotante indicando cuantos cáracteres restan</summary>
           ///   <param name="id" type="string">id del control</param>   
           ///   <param name="MaxLength" type="int">longitud máxima</param>   
           ///   <returns type="void" />
           /// </signature>
       }

    , InitPopover: function (param) {
        /// <signature>
        ///   <summary>agrega un tooltip personalizado a un control</summary>
        ///   <param name="param" type="object">entre las propiedades de este control estan IdControl y Options. para la propiedad Options consultar la siguiente URL' http://v4-alpha.getbootstrap.com/components/popovers/' </param>    
        ///   <returns type="void" />
        /// </signature>
    }
       , UpdateContentPopover: function (id, content) {
           /// <signature>
           ///   <summary>actualiza el contenido de un tooltip personalizado</summary>
           ///   <param name="id" type="string">id del control</param>   
           ///   <param name="content" type="string">nuevo contenido</param>   
           ///   <returns type="void" />
           /// </signature>
       }

      , padding_left: function (s, c, n) {
          /// <signature>
          ///   <summary>rellena un texto al principio ej: AAA -> RRRAAA</summary>
          ///   <param name="s" type="string">texto</param>   
          ///   <param name="c" type="string">caracter de relleno</param>   
          ///   <param name="n" type="string">total de relleno</param>   
          ///   <returns type="string" />
          /// </signature>
      }

       , padding_right: function (s, c, n) {
           /// <signature>
           ///   <summary>rellena un texto al final ej: AAA -> AAARRR</summary>
           ///   <param name="s" type="string">texto</param>   
           ///   <param name="c" type="string">caracter de relleno</param>   
           ///   <param name="n" type="string">total de relleno</param>   
           ///   <returns type="string" />
           /// </signature>
       }

        , setNullEmptyProperties: function (modelo) {
            /// <signature>
            ///   <summary>coloca en null todas las propiedades vacias de un objeto</summary>
            ///   <param name="modelo" type="object">objeto</param>     
            ///   <returns type="object" />
            /// </signature>
        }

      , format: function (n) {
          /// <signature>
          ///   <summary> versión del string.format de C#  ej: "nombre {0}".format("test"); </summary>
          ///   <param name="n" type="string">n... páramtros</param>     
          ///   <returns type="string" />
          /// </signature>
      }

      , ExecuteParamValidator: function (params, FunctionCallBack) {
          /// <signature>
          ///   <summary>invoca al servicio del validador de páramtros del BPMComplement</summary>
          ///   <param name="params" type="object">parametros: {NombreTipoEvaluacion:"", ListaParametros:[]}</param>     
          ///   <param name="FunctionCallBack" type="function"> una vez termine la validación ejecuta esta funcion</param>     
          ///   <returns type="void" />
          /// </signature>
      }

      , UpdateBoostrapColum: function (Control, NewCol) {
          /// <signature>
          ///   <summary>invoca al servicio del validador de páramtros del BPMComplement</summary>
          ///   <param name="Control" type="object">objeto del selector de JQUERY</param>     
          ///   <param name="NewCol" type="int"> nuevo valor de la columna min:1 - max:12</param>     
          ///   <returns type="void" />
          /// </signature>
      }

          , NotificarEstadoControlesDependientesFramework: function (IdControl) {
              /// <signature>
              ///   <summary>notificca a los controles dependientes sus que ha cambiado</summary>
              ///   <param name="Control" type="string">id del control</param>     
              ///   <returns type="void" />
              /// </signature>
          }

    
    ,DelayAction : function (action, time) {
        /// <signature>
        ///   <summary>un delay para invocar una funcion despues del tiempo definido</summary>
        ///   <param name="action" type="function">funcion a invocar</param>     
        ///   <param name="time" type="int">tiempo en milisegundos</param>     
        ///   <returns type="void" />
        /// </signature>
    }



}

this.RelacionCamposFramework = {
    // lista de controles registrados por formulario
    ListaControles: []
    , AgregarRelacion: function (nivel, relacion) {
        /// <signature>
        ///   <summary>permite leer y escribir cualquier tipo de control registrado en el BPMComplement, sin necesidad de crear logica correspondiente</summary>
        ///   <param name="nivel" type="string">nivel basico o avanzado</param>
        ///   <param name="relacion" type="object"> definicion de control y propiedad del WebAPI: {IdControl:"", valor:"",codigo:"", GuardadoPersonalizado:function, CargaPersonalizada:function}</param>
        ///   <returns type="void" />
        /// </signature>
    }
    , Guardar: function (objeto) {
        /// <signature>
        ///   <summary>popula un objeto segun las relaciones definidas</summary>
        ///   <param name="objeto" type="object">objeto a popular </param>
        ///   <returns type="object" />
        /// </signature>
    }

     , Cargar: function (objeto) {
         /// <signature>
         ///   <summary>permite escribir en cualquier tipo de control que se agrego en la relacion, sin necesidad de crear logica correspondiente</summary>
         ///   <param name="objeto" type="object">objeto a leer sus propiedades segun las relaciones definidas</param>
         ///   <returns type="object" />
         /// </signature>
     }
}

intellisense.annotate(window, {
    // Clase Task con propiedades básicas de Utlimus
    UltimusTask: null

    // Clase Varaible de ultimus, para la propidad NodeVariablesList de la clase UltimusTask
, NodeVariables: null

    // identifica si el formulario está siendo visualizado desde un dispositivo móvil
, isMobile: null

    // ULA Framework
, Ultimus: null

    // permite relacionar controles con una estructura compleja sin desarrollar codio para guardar o cargar
, RelacionCamposFramework: null
});

intellisense.annotate(window, Ultimus);