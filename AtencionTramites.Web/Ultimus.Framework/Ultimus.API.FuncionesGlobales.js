var serverLocal = window.location.protocol + "//" + window.location.hostname + "/";
var WebAplication = serverLocal + "AtencionTramites.Web";
var WebAplicationWCF = serverLocal + "AtencionTramites.WCF";
var UltimusAttachmentUrl = $("#hiddenUltimusAttachmentUrl").val();
var UltimusJson = {};

var Mensajes = {
    get Success() { return "DATOS ACTUALIZADOS"; },
    get Warning() { return "ADVERTENCIA"; },
    get Error() { return "ERROR"; },
    get ValidarFormulario() { return "!Validar el formulario¡"; },
    get FirmarFormulario() { return "¡Firmar el formulario!"; },
    get Editar() { return "Editar"; },
    get Eliminar() { return "Eliminar"; },
    get ArchivoNoPermitido() { return "Archivo no permitido"; },
    get ArchivoDemasiadoPesado() { return "Archivo demasiado pesado"; },
    get ArchivoVacio() { return "Archivo vacío"; },
    get NavegadorIncompatible() { return "Navegador incompatible"; },
    get Enviar() { return "¿Desea enviar esta solicitud a la siguiente etapa?"; }
}

//***ButtonSwitch
var ButtonSwicthGuardado = function (Valor) { return (IsNullOrEmpty(Valor) ? null : (Valor == 0 ? true : false)); }
var ButtonSwicthCarga = function (Valor) { return (IsNullOrEmpty(Valor) ? null : (Valor == true ? 0 : 1)); }
var TextGuardado = function (Valor) { return (IsNullOrEmpty(Valor) ? null : (Valor == "true" ? true : false)); }
var TextCarga = function (Valor) { return (IsNullOrEmpty(Valor) ? null : (Valor == true ? "true" : "false")); }
//***Fin

jQuery(document).ready(function () {
    //***IE, para que el resultado de una consulta GET AJAX no se quede en el cache
    $.ajaxSetup({ cache: false });
    //***Fin
});

this.SetearAccordion = function () {
    $(".TituloAcordeon").unbind("click");
    $(".TituloAcordeon").click(function () {
        var h3 = $(this);
        var i = h3.find("i");
        var div = h3.closest("div").next("div");
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

this.LeerControlesUltimus = function (modelo) {
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
    return modelo;
}

this.GridInit = function (form, grid, property, loadCallback, callback) {
    if (grid == undefined || grid == null)
        return false;
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
            }
            return Settings;
        },
        RowEvent: function (IdControl, DataRow) {
            if (IdControl == "btnRemover") {
                if (confirm('¿Borrar?')) {
                    $("#{0}".format(grid)).Grid("Remove", DataRow.index);
                }
            }
            else if (IdControl == "btnEditar") {
                //Lleno los campos con los valores del registro que estoy editando. La relacion entre campo y valor se define en el metodo CargarRelacionCampos
                if ($.isFunction(CargarRelacionCampos)) {
                    if (property != undefined && property != null) {
                        var list = $("#{0}".format(grid)).Grid("Get");
                        var model = {};
                        model[property] = list[DataRow.index];

                        CargarRelacionCampos(property);
                        RelacionCamposFramework.Cargar(model);
                        if (form != undefined && form != null) {
                            $("#{0}".format(form)).valid();
                        }
                    }
                }
                //Llamo el método
                if (callback != undefined && callback != null && $.isFunction(callback)) {
                    callback(DataRow.index);
                }
            }
        }
    });
}

this.GridAction = function (form, grid, property, index, fieldsToCheck, callback) {
    if (grid == undefined || grid == null)
        return false;
    //Valido el formulario
    if (!$("#{0}".format(form)).valid()) {
        toastr.warning("Ingresar todos los campos requeridos por el formulario", Mensajes.Warning);
        return false;
    }
    if ($.isFunction(CargarRelacionCampos)) {
        CargarRelacionCampos(property);
        var model = LeerControlesUltimus();
        model = RelacionCamposFramework.Guardar(model);

        var list = $("#{0}".format(grid)).Grid("Get");
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
                toastr.warning("¡Ya existe!", Mensajes.Warning);
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
        }
    }
    //Reset del formulario
    $("#{0}".format(form)).reset();
    //Validación del formulario
    $("#{0}".format(form)).valid();
    //Llamo el metodo
    if (callback != undefined && callback != null && $.isFunction(callback)) {
        callback(null);
    }
}

this.GetAutoNumeric = function (Id) {
    var valor = $("#{0}".format(Id)).autoNumeric("get");
    if (valor == "")
        valor = 0;
    return parseFloat(valor);
}

this.InicializarGeo = function (idPais, idProvincia, idDistrito, idCorregimiento) {
    if (idPais != null) {
        $("#btn" + idPais).unbind("click");
        $("#btn" + idPais).click(function () {
            CatalogosPostPais = {
                id: IdPAIS_DEFAULT
            };
            Ultimus.SelectedCatalog = idPais;
            Ultimus.CargarDataCatalogo(null, null, CatalogosPostPais);
        });

        $("#txt" + idPais).change(function () {
            if (idProvincia != null) {
                $("#div" + idProvincia).Catalogo("Clear");
            }
            if (idDistrito != null) {
                $("#div" + idDistrito).Catalogo("Clear");
            }
            if (idCorregimiento != null) {
                $("#div" + idCorregimiento).Catalogo("Clear");
            }
        });

        if (idProvincia != null) {
            $("#btn" + idProvincia).unbind("click");
            $("#btn" + idProvincia).click(function () {
                CatalogosPostPais = {
                    CodigoPais: $("#hidden" + idPais).val()
                };

                if (IsNullOrEmpty($("#hidden" + idPais).val())) {
                    toastr.warning("Debe escoger el país", Mensajes.Warning);
                    return;
                }
                Ultimus.SelectedCatalog = idProvincia;
                Ultimus.CargarDataCatalogo(null, null, CatalogosPostPais);
            });

            $("#txt" + idProvincia).change(function () {
                if (idDistrito != null) {
                    $("#div" + idDistrito).Catalogo("Clear");
                }
                if (idCorregimiento != null) {
                    $("#div" + idCorregimiento).Catalogo("Clear");
                }
            });
        }

        if (idDistrito != null) {
            $("#btn" + idDistrito).unbind("click");
            $("#btn" + idDistrito).click(function () {
                CatalogosPostPais = {
                    CodigoPais: $("#hidden" + idPais).val(),
                    CodigoProvincia: $("#hidden" + idProvincia).val()
                };

                if (IsNullOrEmpty($("#hidden" + idPais).val()) || IsNullOrEmpty($("#hidden" + idProvincia).val())) {
                    toastr.warning("Debe escoger el país y la provincia", Mensajes.Warning);
                    return;
                }
                Ultimus.SelectedCatalog = idDistrito;
                Ultimus.CargarDataCatalogo(null, null, CatalogosPostPais);
            });

            $("#txt" + idDistrito).change(function () {
                if (idCorregimiento != null) {
                    $("#div" + idCorregimiento).Catalogo("Clear");
                }
            });
        }

        if (idCorregimiento != null) {
            $("#btn" + idCorregimiento).unbind("click");
            $("#btn" + idCorregimiento).click(function () {
                CatalogosPostPais = {
                    CodigoPais: $("#hidden" + idPais).val(),
                    CodigoProvincia: $("#hidden" + idProvincia).val(),
                    CodigoDistrito: $("#hidden" + idDistrito).val()
                };

                if (IsNullOrEmpty($("#hidden" + idPais).val()) || IsNullOrEmpty($("#hidden" + idProvincia).val()) || IsNullOrEmpty($("#hidden" + idDistrito).val())) {
                    toastr.warning("Debe escoger el país, la provincia y el corregimiento", Mensajes.Warning);
                    return;
                }
                Ultimus.SelectedCatalog = idCorregimiento;
                Ultimus.CargarDataCatalogo(null, null, CatalogosPostPais);
            });
        }
    }
}

this.EvaluaFecha = function (idFecha1, idFecha2, condicion, alerta, idAnio, idMes, idDia) {
    var mensaje = null;

    var control1 = $("#" + idFecha1);
    if (control1 != null && control1 != undefined && control1.val() != "") {

        var fecha1 = new Date(moment(control1.val(), control1.attr("dateformat")));
        var fechafull1 = fecha1.getFullYear()
            + "-"
            + (fecha1.getMonth() + 1)
            + "-"
            + fecha1.getDate();
        var moment1 = moment(fechafull1, "YYYY-MM-DD");

        var fecha2 = new Date();
        var control2 = $("#" + idFecha2);
        if (control2 != null && control2 != undefined && control2.val() != "") {
            fecha2 = new Date(moment(control2.val(), control2.attr("dateformat")));
        }
        var fechafull2 = fecha2.getFullYear()
            + "-"
            + (fecha2.getMonth() + 1)
            + "-"
            + fecha2.getDate();
        var moment2 = moment(fechafull2, "YYYY-MM-DD");

        var resultado = false;
        if (condicion == "=" || condicion == "==") {
            resultado = Date.parse(fechafull1) == Date.parse(fechafull2);
        }
        else if (condicion == "<") {
            resultado = Date.parse(fechafull1) < Date.parse(fechafull2);
        }
        else if (condicion == "<=") {
            resultado = Date.parse(fechafull1) <= Date.parse(fechafull2);
        }
        else if (condicion == ">") {
            resultado = Date.parse(fechafull1) > Date.parse(fechafull2);
        }
        else if (condicion == ">=") {
            resultado = Date.parse(fechafull1) >= Date.parse(fechafull2);
        }

        if (resultado) {
            mensaje = alerta;
            if (idAnio != null && idAnio != undefined && idMes != null && idMes != undefined && idDia != null && idDia != undefined) {
                $("#" + idAnio).val("");
                $("#" + idMes).val("");
                $("#" + idDia).val("");
            }
        }
        else {
            if (idAnio != null && idAnio != undefined && idMes != null && idMes != undefined && idDia != null && idDia != undefined) {
                var diff = moment.preciseDiff(moment1, moment2, true);
                $("#" + idAnio).val(diff.years);
                $("#" + idMes).val(diff.months);
                $("#" + idDia).val(diff.days);
            }
        }
    }

    return mensaje;
}

if (!String.prototype.startsWith) {
    String.prototype.startsWith = function (searchString, position) {
        position = position || 0;
        return this.substr(position, searchString.length) === searchString;
    };
}

if (!String.prototype.endsWith) {
    String.prototype.endsWith = function (suffix) {
        return this.indexOf(suffix, this.length - suffix.length) !== -1;
    };
}