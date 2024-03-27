var serverLocal = window.location.protocol + "//" + window.location.hostname + "/";
var WebAplication = serverLocal + "AtencionTramites.Web";
var WebAplicationWCF = serverLocal + "AtencionTramites.WCF";
var UltimusAttachmentUrl = $("#hiddenUltimusAttachmentUrl").val();
var modelo = {};

var WebUrl = $("#hiddenWebUrl").val();
var WCFUrl = $("#hiddenWCFUrl").val();

var ButtonSwicthGuardado = function (Valor) { return (IsNullOrEmpty(Valor) ? null : (Valor == 0 ? true : false)); }

var ButtonSwicthCarga = function (Valor) { return (IsNullOrEmpty(Valor) ? null : (Valor == true ? 0 : 1)); }

function IsDoubleClicked(element) {
    //If already clicked return TRUE to indicate this click is not allowed
    if (element.data("IsDoubleClicked")) return true;

    //Mark as clicked for 5 second (5000)
    element.data("IsDoubleClicked", true);
    setTimeout(function () {
        element.removeData("IsDoubleClicked");
    }, 5000);

    //Return FALSE to indicate this click was allowed
    return false;
}

this.SetearAccordion = function () {
    $(".TituloAcordeon").unbind("click");
    $(".TituloAcordeon").click(function () {
        var h3 = $(this);
        var i = h3.find("i");
        var div = null;
        if (h3.parent().is("span")) {
            div = h3.parent().parent().nextAll("div");
        }
        else {
            div = h3.nextAll("div");
        }
        var visible = div.is(":visible");
        if (visible) {
            i.removeClass("fa fa-chevron-circle-down");
            i.addClass("fa fa-chevron-circle-up");
            div.slideUp(100);
        }
        else {
            i.removeClass("fa fa-chevron-circle-up");
            i.addClass("fa fa-chevron-circle-down");
            div.slideDown(100);
        }
    });
}

this.ObtenerModelo = function () {
  
    if (modelo == null)
        modelo = {};
    modelo.UltimusTaskId = $("#hiddenTaskId").val();
    modelo.UltimusUserID = $("#hiddenUserID").val();
    modelo.UltimusProcess = $("#hiddenProcess").val();
    modelo.UltimusStep = $("#hiddenStep").val();
    modelo.UltimusIncident = $("#hiddenIncident").val();
    modelo.UltimusIpAdress = $("#hiddenIpAdress").val();
    modelo.UltimusMachineName = $("#hiddenMachineName").val();
    modelo.UltimusActivityType = $("#hiddenActivityType").val();
    modelo.UltimusJobFunction = $("#hiddenJobFunction").val();
    modelo.UltimusUserFullName = $("#hiddenUserFullName").val();
    modelo.UltimusUserEmail = $("#hiddenUserEmail").val();
    modelo.UltimusSupervisor = $("#hiddenSupervisor").val();
    modelo.UltimusSupervisorFullName = $("#hiddenSupervisorFullName").val();
    modelo.UltimusBrowserName = $("#hiddenBrowserName").val();
    modelo.UltimusBrowserVersion = $("#hiddenBrowserVersion").val();
    modelo.UltimusVersion = $("#hiddenVersion").val();
    modelo.UltimusTaskStartTime = $("#hiddenStartTime").val();
    modelo.UltimusTaskStatus = $("#hiddenTaskStatus").val();
    modelo.HostResponse = $("#hiddenHostResponse").val();
    modelo.CodigoSolicitud = $("#hiddenCodigoSolicitud").val();
    modelo.CodigoSolicitudOriginal = $("#hiddenCodigoSolicitudOriginal").val();
    modelo.CodigoSolicitudInterna = $("#hiddenCodigoSolicitudInterna").val();
    return modelo;
}

this.Response = function (data, callback) {
    ENDREQUEST();
    if (data.CodigoRespuesta == "EXITOSO") {
        if (!IsNullOrEmpty(data.DescripcionRespuesta)) {
            toastr.success(data.DescripcionRespuesta, Message_Success);
        }
        if (callback != null && callback != undefined) {
            callback(data);
        }
    }
    else if (data.CodigoRespuesta == "ADVERTENCIA") {
        toastr.warning(data.DescripcionRespuesta, Message_Warning);
    }
    else if (data.CodigoRespuesta == "ERROR") {
        toastr.error(data.DescripcionRespuesta, Message_Error);
    }
}

this.FormatDateTime = function (value, showTime) {
    if (showTime)
        return moment(value).format("DD-MMMM-YYYY HH:mm:ss");
    else
        return moment(value).format("DD-MMMM-YYYY");
}

this.FormatBoolean = function (value, enable, name) {
    var checked = value == true ? "checked='checked'" : "";
    var disabled = enable == true ? "" : "disabled='disabled'";
    return "<input type='checkbox' {0} {1} data-name='{2}' />".format(checked, disabled, name);
}

this.CloseForm = function () {
    if (window.top == window.self) {
        window.parent.close();
    }
    else {
        parent.window.close();
        window.parent.LoadInboxTask();
    }
}

//**********************GRID INICIO**********************//
this.Grid_Init = function (grid, property, orderable, loadCallback) {
    if (grid == undefined || grid == null)
        return;

    $("#{0}".format(grid)).Grid("Set", {
        setCustomSettings: function (Settings) {
            if (Settings.data != null) {
                $.each(Settings.data, function (index, item) {
                    item.index = index;
                    item.Opciones = $("#Opciones").html();
                    //Llamo el metodo
                    if (loadCallback != undefined && loadCallback != null && $.isFunction(loadCallback)) {
                        loadCallback(item);
                    }
                });
                $.each(Settings.ColumnDefinition, function (index, item) {
                    //Orderable
                    if (orderable != undefined && orderable != null) {
                        Settings.ColumnDefinition[index].orderable = orderable;
                    }
                });
            }
            return Settings;
        }
    });

    $("#{0}".format(grid)).attr("data-property", property);
    $("#{0}".format(grid)).attr("data-index", null);
}

this.Grid_Add = function (grid, property, fieldsToCheck) {
    if (grid == undefined || grid == null)
        return;

    //Valido el formulario
    if (!$("#frm{0}".format(property)).valid()) {
        toastr.warning(MensajeValidarFormulario, Message_Warning);
        return false;
    }
    //CargarRelacionCampos
    CargarRelacionCampos(property);
    var model = RelacionCamposFramework.Guardar(model);

    var list = $("#{0}".format(grid)).Grid("Get");
    var index = $("#{0}".format(grid)).attr("data-index");
    if (index == null) {
        var existe = false;
        //Recorro el grid
        $.each(list, function (indexGrid, itemGrid) {
            //Valido si el elemento ya existe
            if (fieldsToCheck != null) {
                $.each(fieldsToCheck, function (indexFieldToCheck, itemFieldToCheck) {
                    if (itemGrid[itemFieldToCheck] == model[property][itemFieldToCheck]) {
                        existe = true;
                        return;
                    }
                });
            }
        });
        if (existe) {
            toastr.warning("¡Ya existe!", Message_Warning);
            return;
        }
        else {
            //Agregar
            $("#{0}".format(grid)).Grid("Add", model[property]);
        }
    }
    else {
        //Editar solo las propriedades que tienen un valor y es diferente
        $.each(model[property], function (name, value) {
            if (list[index][name] != value) {
                list[index][name] = value;
            }
        });
        $("#{0}".format(grid)).Grid("RenderGrid", list);
        //Seteo el index y el botón
        $("#btn{0}_Agregar span".format(property)).text(" Agregar");
        $("#{0}".format(grid)).attr("data-index", null);
    }
    //Reset del formulario
    $("#frm{0}".format(property)).reset();
    //Validación del formulario
    $("#frm{0}".format(property)).valid();
}

this.Grid_Clean = function (grid, property) {
    if (grid == undefined || grid == null)
        return;

    //Seteo el index y el botón
    $("#btn{0}_Agregar span".format(property)).text(" Agregar");
    $("#{0}".format(grid)).attr("data-index", null);
    //Reset del formulario
    $("#frm{0}".format(property)).reset();
    //Validación del formulario
    $("#frm{0}".format(property)).valid();
}

this.Grid_Edit = function (obj) {
    //Registro seleccionado
    var tr = $(obj).closest('tr');
    var table = $(obj).closest('table');
    var dataTable = table.DataTable();
    var index = dataTable.row(tr).index();
    var property = table.attr("data-property");

    var list = table.Grid("Get");
    var model = {};
    model[property] = list[index];

    //CargarRelacionCampos
    CargarRelacionCampos(property);
    RelacionCamposFramework.Cargar(model);

    $("#btn{0}_Agregar span".format(property)).text(" Editar");
    table.attr("data-index", index);

    if (property != null && property != "") {
        //Validación del formulario
        $("#frm{0}".format(property)).valid();
    }
}

this.Grid_Delete = function (obj) {
    //Registro seleccionado
    var tr = $(obj).closest('tr');
    var table = $(obj).closest('table');
    var dataTable = table.DataTable();
    var index = dataTable.row(tr).index();
    var property = table.attr("data-property");

    if (confirm(MensajeEliminar)) {
        table.Grid("Remove", index);

        if (property != null && property != "") {
            //Reset del formulario
            $("#frm{0}".format(property)).reset();
            //Validación del formulario
            $("#frm{0}".format(property)).valid();
        }
    }
}
//**********************GRID FIN**********************//

//**********************FILE INPUT INICIO**********************//
this.FileInput_Init = function (catalog) {
    if (catalog == undefined || catalog == null)
        return;
    if (!window.FileReader)
        return;

    var control = $("<input id='in{0}' type='file' class='file'>".format(catalog));
    $("#btn{0}".format(catalog)).addClass("btn-file");
    $("#btn{0}".format(catalog)).append(control);

    var multiple = $("#hidden{0}_FileInputMultiple".format(catalog)).val();
    if (multiple == "true") {
        $("#in{0}".format(catalog)).attr("multiple", "multiple");
    }

    $("#in{0}".format(catalog)).unbind("change");
    $("#in{0}".format(catalog)).change(function () {
        var input = $("#in{0}".format(catalog))[0];

        if (input.files && input.files.length > 0) {
            var files = [];
            var names = "";
            var extensions = FileInputExtension.split(';');

            $.each(input.files, function (index, item) {
                var extension = item.name.toLowerCase().split('.').pop();
                var isAllowed = extensions.indexOf(extension) > -1;
                if (!isAllowed) {
                    toastr.warning(MensajeArchivoNoPermitido.format(item.name, extension, FileInputExtension), Message_Warning);
                    return;
                }
                else if (item.size > FileInputMaxSize) {
                    toastr.warning(MensajeArchivoMuyPesado.format(item.name, CustomNumberFormat(item.size), CustomNumberFormat(FileInputMaxSize)), Message_Warning);
                    return;
                }
                else if (item.size == 0) {
                    toastr.warning(MensajeArchivoVacio.format(item.name), Message_Warning);
                    return;
                }
                var fr = new FileReader();
                fr.onload = function () {
                    var local = {};
                    local.NombreProceso = $("#hiddenProcess").val();
                    local.NombreCarpeta = CarpetaAdjuntos;
                    local.TamanoArchivo = item.size;
                    local.TituloArchivo = item.name;
                    local.Data = fr.result;
                    Ultimus.AjaxPostData("{0}/api/UltimusFormAPI/CargarArchivo".format(WebUrl), local, true, false, function (data) {
                        Response(data, function () {
                            files.push(data);
                            names += "{0}; ".format(data.TituloArchivo);
                            if (index == input.files.length - 1) {
                                var json = JSON.stringify(files);
                                $("#hidden{0}".format(catalog)).val(json);
                                $("#txt{0}".format(catalog)).val(names);
                                $("#txt{0}".format(catalog)).trigger("change");
                            }
                        });
                    }, "ERROR");
                }
                fr.readAsDataURL(item);
            });
        }
    });

    $("#in{0}".format(catalog)).unbind("click");
    $("#in{0}".format(catalog)).click(function () {
        $("#in{0}".format(catalog)).val("");
        $("#hidden{0}".format(catalog)).val("");
        $("#txt{0}".format(catalog)).val("");
        $("#txt{0}".format(catalog)).trigger("change");
    });
}

this.FileInput_Get = function (catalog) {
    var json = $("#hidden{0}".format(catalog)).val();
    if (json == "")
        return null;
    else
        return JSON.parse(json);
}
//**********************FILE INPUT FIN**********************//

//**********************CONFIRM INICIO**********************//
this.Confirm_Show = function (text, callback) {
    $("#modalConfirm").modal("show");
    $("#modalConfirm .modal-body").text(text);
    //Llamo el metodo
    if (callback != undefined && callback != null && $.isFunction(callback)) {
        $("#modal-btn-si").unbind("click");
        $("#modal-btn-si").click(function () {
            $("#modalConfirm").modal("hide");
            callback(true);
        });

        $("#modal-btn-no").unbind("click");
        $("#modal-btn-no").click(function () {
            $("#modalConfirm").modal("hide");
            callback(false);
        });
    }
}
//**********************CONFIRM FIN**********************//

//**********************ALERT INICIO**********************//
this.Alert_Show = function (text, callback) {
    $("#modalAlert").modal("show");
    $("#modalAlert .modal-body").text(text);
    //Llamo el metodo
    if (callback != undefined && callback != null && $.isFunction(callback)) {
        $("#modal-btn-ok").unbind("click");
        $("#modal-btn-ok").click(function () {
            $("#modalAlert").modal("hide");
        });
        $('#modalAlert').on('hidden.bs.modal', function () {
            callback(true);
        });
    }
}
//**********************ALERT FIN**********************//

this.CargarRelacionCampos = function (form) {
    RelacionCamposFramework.ListaControles = [];
    //Clasificación Trámites
    //AnexosRadicadoAT
    if (form == undefined || form == "AnexosRadicadoAT") {
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "AnexosRadicadoAT_AnexosLista", valor: "AnexosLista" });
    }
    //BotonesAT
    if (form == undefined || form == "BotonesAT") {
    }
    //ClasificacionPeticionAT
    if (form == undefined || form == "ClasificacionPeticionAT") {
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "ClasificacionPeticionAT_ConclusionAsesoria", codigo: "ClasificacionPeticionAT.CodigoConclusionAsesoria", valor: "ClasificacionPeticionAT.NombreConclusionAsesoria" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "ClasificacionPeticionAT_Descripcion", valor: "ClasificacionPeticionAT.Descripcion" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "ClasificacionPeticionAT_Asesorias", valor: "ClasificacionPeticionAT.Asesorias" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "ClasificacionPeticionAT_TipoPeticion", codigo: "ClasificacionPeticionAT.CodigoTipoPeticion", valor: "ClasificacionPeticionAT.NombreTipoPeticion" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "ClasificacionPeticionAT_AreaDerechos", codigo: "ClasificacionPeticionAT.CodigoAreaDerechos", valor: "ClasificacionPeticionAT.NombreAreaDerechos" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "ClasificacionPeticionAT_Derechos", codigo: "ClasificacionPeticionAT.CodigoDerechos", valor: "ClasificacionPeticionAT.NombreDerechos" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "ClasificacionPeticionAT_Observaciones", valor: "ClasificacionPeticionAT.Observaciones" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "ClasificacionPeticionAT_DerechosLista", valor: "DerechosLista" });
    }
    //DecisionAT
    if (form == undefined || form == "DecisionAT") {
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "DecisionAT_Decision", codigo: "DecisionAT.CodigoDecision", valor: "DecisionAT.NombreDecision" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "DecisionAT_Comentarios", valor: "DecisionAT.Comentarios" });
    }
    //InfoRadicadoAT
    if (form == undefined || form == "InfoRadicadoAT") {

        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "InfoRadicadoAT_NumeroRadicado", valor: "InfoRadicadoAT.NumeroRadicado" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "InfoRadicadoAT_CanalAtencion", codigo: "InfoRadicadoAT.CodigoCanalAtencion", valor: "InfoRadicadoAT.NombreCanalAtencion" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "InfoRadicadoAT_Fecha", valor: "InfoRadicadoAT.Fecha" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "InfoRadicadoAT_TipoSolicitante", codigo: "InfoRadicadoAT.CodigoTipoSolicitante", valor: "InfoRadicadoAT.NombreTipoSolicitante" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "InfoRadicadoAT_TipoDocId", codigo: "InfoRadicadoAT.CodigoTipoDocId", valor: "InfoRadicadoAT.NombreTipoDocId" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "InfoRadicadoAT_NumIdentificacion", valor: "InfoRadicadoAT.NumIdentificacion" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "InfoRadicadoAT_Remitente", valor: "InfoRadicadoAT.Remitente" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "InfoRadicadoAT_MiembroGrupoEtnico", codigo: "InfoRadicadoAT.CodigoMiembroGrupoEtnico", valor: "InfoRadicadoAT.NombreMiembroGrupoEtnico" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "InfoRadicadoAT_SexoAsignado", codigo: "InfoRadicadoAT.CodigoSexoAsignado", valor: "InfoRadicadoAT.NombreSexoAsignado" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "InfoRadicadoAT_IdentidadGenero", codigo: "InfoRadicadoAT.CodigoIdentidadGenero", valor: "InfoRadicadoAT.NombreIdentidadGenero" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "InfoRadicadoAT_OrientacionSexual", codigo: "InfoRadicadoAT.CodigoOrientacionSexual", valor: "InfoRadicadoAT.NombreOrientacionSexual" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "InfoRadicadoAT_ExpresionGenero", codigo: "InfoRadicadoAT.CodigoExpresionGenero", valor: "InfoRadicadoAT.NombreExpresionGenero" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "InfoRadicadoAT_RangoEdad", codigo: "InfoRadicadoAT.CodigoRangoEdad", valor: "InfoRadicadoAT.NombreRangoEdad" });
    }
    //PeticionarioEnfoqueAT
    if (form == undefined || form == "PeticionarioEnfoqueAT") {
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioEnfoqueAT_GrupoEtnico", codigo: "PeticionarioEnfoqueAT.CodigoGrupoEtnico", valor: "PeticionarioEnfoqueAT.NombreGrupoEtnico" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioEnfoqueAT_SexoAsignado", codigo: "PeticionarioEnfoqueAT.CodigoSexoAsignado", valor: "PeticionarioEnfoqueAT.NombreSexoAsignado" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioEnfoqueAT_IdentidadGnero", codigo: "PeticionarioEnfoqueAT.CodigoIdentidadGnero", valor: "PeticionarioEnfoqueAT.NombreIdentidadGnero" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioEnfoqueAT_Orientacionsexual", codigo: "PeticionarioEnfoqueAT.CodigoOrientacionsexual", valor: "PeticionarioEnfoqueAT.NombreOrientacionsexual" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioEnfoqueAT_RangoEdad", codigo: "PeticionarioEnfoqueAT.CodigoRangoEdad", valor: "PeticionarioEnfoqueAT.NombreRangoEdad" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioEnfoqueAT_Grupo", codigo: "PeticionarioEnfoqueAT.CodigoGrupo", valor: "PeticionarioEnfoqueAT.NombreGrupo" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioEnfoqueAT_Subgrupo", codigo: "PeticionarioEnfoqueAT.CodigoSubgrupo", valor: "PeticionarioEnfoqueAT.NombreSubgrupo" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioEnfoqueAT_Comunidad", codigo: "PeticionarioEnfoqueAT.CodigoComunidad", valor: "PeticionarioEnfoqueAT.NombreComunidad" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioEnfoqueAT_ExpresionGenero", codigo: "PeticionarioEnfoqueAT.CodigoExpresionGenero", valor: "PeticionarioEnfoqueAT.NombreExpresionGenero" });
    }
    //PeticionarioAT
    if (form == undefined || form == "PeticionarioAT") {
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_TipoSolicitante", codigo: "PeticionarioAT.CodigoTipoSolicitante", valor: "PeticionarioAT.NombreTipoSolicitante" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_TipoDocId", codigo: "PeticionarioAT.CodigoTipoDocId", valor: "PeticionarioAT.NombreTipoDocId" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_NumIdentificacion", valor: "PeticionarioAT.NumIdentificacion" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_Remitente", valor: "PeticionarioAT.Remitente" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_EstadoCivil", codigo: "PeticionarioAT.CodigoEstadoCivil", valor: "PeticionarioAT.NombreEstadoCivil" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_NivelEstudio", codigo: "PeticionarioAT.CodigoNivelEstudio", valor: "PeticionarioAT.NombreNivelEstudio" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_Estrato", codigo: "PeticionarioAT.CodigoEstrato", valor: "PeticionarioAT.NombreEstrato" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_NombreIdentitario", valor: "PeticionarioAT.NombreIdentitario" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_Correo", valor: "PeticionarioAT.Correo" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_Telefono", valor: "PeticionarioAT.Telefono" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_Direccion", valor: "PeticionarioAT.Direccion" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_Nacionalidad", codigo: "PeticionarioAT.CodigoNacionalidad", valor: "PeticionarioAT.NombreNacionalidad" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_Pais", codigo: "PeticionarioAT.CodigoPais", valor: "PeticionarioAT.NombrePais" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_Departamento", codigo: "PeticionarioAT.CodigoDepartamento", valor: "PeticionarioAT.NombreDepartamento" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_Ciudad", codigo: "PeticionarioAT.CodigoCiudad", valor: "PeticionarioAT.NombreCiudad" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_CentroPoblado", codigo: "PeticionarioAT.CodigoCentroPoblado", valor: "PeticionarioAT.NombreCentroPoblado" });
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioAT_SituacionDiscapacidad", codigo: "PeticionarioAT.CodigoSituacionDiscapacidad", valor: "PeticionarioAT.NombreSituacionDiscapacidad" });
    }
    //PeticionarioTablaAT
    if (form == undefined || form == "PeticionarioTablaAT") {
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "PeticionarioTablaAT_PeticionariosLista", valor: "PeticionariosLista" });
    }
    //Fin Clasificación Trámites
    //Atención Trámites Ase
    //BotonesEE
    if (form == undefined || form == "BotonesEE") {
    }
    //RadicadoDocumentoEE
    if (form == undefined || form == "RadicadoDocumentoEE") {
        RelacionCamposFramework.AgregarRelacion("basico", { IdControl: "RadicadoDocumento_AnexoList", valor: "AnexoList" });
    }
    //Fin Atención Trámites Ase
}