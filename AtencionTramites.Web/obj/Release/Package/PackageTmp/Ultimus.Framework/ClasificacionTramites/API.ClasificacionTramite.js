$("#frmInfoRadicado").EnableValidationToolTip();
$("#frmAnexosRadicado").EnableValidationToolTip();
$("#frmRegistroPeticionarios").EnableValidationToolTip();
$("#frmClasificacionPeticion").EnableValidationToolTip();
$("#frmConclusionPeticion").EnableValidationToolTip();

jQuery(document).ready(function () {
    UpdateControlsSettings("FILTRO_FRM_BotonesAT", "BotonesAT", "frmBotones", function () {
        UpdateControlsSettings("FILTRO_FRM_AnexosRadicadoAT", "AnexosRadicadoAT", "frmAnexosRadicado", function () {
            UpdateControlsSettings("FILTRO_FRM_ClasificacionPeticionAT", "ClasificacionPeticionAT", "frmClasificacionPeticion", function () {
                UpdateControlsSettings("FILTRO_FRM_DecisionAT", "DecisionAT", "frmConclusionPeticion", function () {
                    UpdateControlsSettings("FILTRO_FRM_InfoRadicadoAT", "InfoRadicadoAT", "frmInfoRadicado", function () {
                        UpdateControlsSettings("FILTRO_FRM_PeticionarioEnfoqueAT", "PeticionarioEnfoqueAT", "frmRegistroPeticionarios", function () {
                            UpdateControlsSettings("FILTRO_FRM_PeticionarioAT", "PeticionarioAT", "frmRegistroPeticionarios", function () {
                                UpdateControlsSettings("FILTRO_FRM_PeticionarioTablaAT", "PeticionarioTablaAT", "frmRegistroPeticionarios", function () {
                                    getDataModel();
                                });
                            });
                        })
                    });
                });
            });
        });
    });
});

this.getDataModel = function () {
    //debugger;
    ENDREQUEST();
    //SetearAccordion();
    debugger;
    var local = ObtenerModelo();

    Ultimus.AjaxPostData("{0}/Catalogos.svc/api/ObtenerAreaDerecho".format(WebAplicationWCF), local, true, false, function (data) {
        debugger;
        if (data == null) { alert('edgar'); }
        Response(data, function () {
            CargarFormulario(data);
        });
    }, "ERROR");
}

this.Radicado_Guardar = function () {
    if (IsDoubleClicked($(this))) return;

    $(":input").each(function () {
        if (!$(this).is(":hidden")) {
            this.value = this.value.toUpperCase();
        }
    });

    if (!$("#frmRespuesta").valid()) {
        toastr.warning(MensajeValidarFormulario, Message_Warning);
        return;
    }
    var local = ObtenerModelo();
    CargarRelacionCampos();
    local = RelacionCamposFramework.Guardar(local);
    local.Radicado.RadicadoDocumento = $("#RadicadoDocumento_AnexoList").Grid("Get");
    local.RadicadoInterno = {};
    local.RadicadoInterno.RadicadoInternoDocumento = $("#RadicadoInternoDocumento_AnexoList").Grid("Get");
    local.RadicadoInternoRespuesta = {};
    local.RadicadoInternoRespuesta.RadicadoInternoDocumento = $("#RadicadoInternoRespuestaDocumento_AnexoList").Grid("Get");
    local.Respuesta.RespuestaDocumento = $("#RespuestaDocumento_AnexoList").Grid("Get");
    local.Respuesta.RespuestaAdicional = $("#RespuestaAdicional_RespuestaAdicionalList").Grid("Get");
    Ultimus.AjaxPostData("{0}/CorrExtEnviada.svc/api/Radicado_Guardar".format(WCFUrl), local, true, false, function (data) {
        Response(data, function () {
            if (local.CodigoSolicitud == 0) {
                var url = window.location.href.replace("co_solicitud=0", "co_solicitud={0}".format(data.Respuesta.CodigoSolicitud));
                window.location = url;
            }
            else {
                CargarFormulario(data);
            }
        });
    }, "ERROR");
}

this.Radicado_Completar = function () {
    if (IsDoubleClicked($(this))) return;
    if (!$("#frmRespuesta").valid() || !$("#frmRespuestaDecision").valid()) {
        toastr.warning(MensajeValidarFormulario, Message_Warning);
        return;
    }

    $(":input").each(function () {
        if (!$(this).is(":hidden")) {
            this.value = this.value.toUpperCase();
        }
    });

    var local = ObtenerModelo();
    CargarRelacionCampos();
    local = RelacionCamposFramework.Guardar(local);
    if (local.UltimusStep == "Aprobar") {
        if ($("#btnRespuestaDecision_Firma").attr("firmado") != "1" && $("#ddlRespuestaDecision_TipoFirma").val() == 1) {
            toastr.warning(MensajeFirmarFormulario, Message_Warning);
            return;
        }
    }
    if (confirm("¿Desea enviar esta solicitud a la siguiente etapa?")) {
        $("#btnBotones_Descartar").prop("disabled", true);
        $("#btnBotones_Completar").prop("disabled", true);
        local.Hash = $("#lblRespuestaDecision_FirmaHash").text();
        local.Radicado.RadicadoDocumento = $("#RadicadoDocumento_AnexoList").Grid("Get");
        local.RadicadoInterno = {};
        local.RadicadoInterno.RadicadoInternoDocumento = $("#RadicadoInternoDocumento_AnexoList").Grid("Get");
        local.RadicadoInternoRespuesta = {};
        local.RadicadoInternoRespuesta.RadicadoInternoDocumento = $("#RadicadoInternoRespuestaDocumento_AnexoList").Grid("Get");
        local.Respuesta.RespuestaDocumento = $("#RespuestaDocumento_AnexoList").Grid("Get");
        local.Respuesta.RespuestaAdicional = $("#RespuestaAdicional_RespuestaAdicionalList").Grid("Get");
        Ultimus.AjaxPostData("{0}/CorrExtEnviada.svc/api/Radicado_Completar".format(WCFUrl), local, true, false, function (data) {
            $("#btnBotones_Descartar").prop("disabled", false);
            $("#btnBotones_Completar").prop("disabled", false);
            Response(data, function () {
                if (local.UltimusIncident == 0) {
                    alert("Se ha generado el incidente No. " + data.UltimusIncident);
                    CloseForm();
                }
                else {
                    if (local.UltimusStep == "Aprobar") {
                        if (local.RespuestaDecision.CodigoTipoFirma == 2) {
                            $("#ifrFirmarDocumento").prop("src", 'about:blank');
                            setTimeout(function () {
                                $("#ifrFirmarDocumento").prop("src", data.Respuesta.UrlParaFirma);
                                $("#modalFirmarDocumento").modal("show");
                                $("#modalFirmarDocumento").on("hidden.bs.modal", function () {
                                    CloseForm();
                                });
                            }, 100);
                        } else {
                            alert("Se ha completado el incidente No. " + data.UltimusIncident);
                            CloseForm();
                        }
                    } else {
                        alert("Se ha completado el incidente No. " + data.UltimusIncident);
                        CloseForm();
                    }
                }
            });
        }, "ERROR");
    }
}

this.Radicado_Descartar = function () {
    if (IsDoubleClicked($(this))) return;
    if (confirm("¿Desea descartar esta solicitud?")) {
        $("#btnBotones_Descartar").prop("disabled", true);
        $("#btnBotones_Completar").prop("disabled", true);
        var local = ObtenerModelo();
        CargarRelacionCampos();
        local = RelacionCamposFramework.Guardar(local);
        local.Hash = $("#lblRespuestaDecision_FirmaHash").text();
        local.Radicado.RadicadoDocumento = $("#RadicadoDocumento_AnexoList").Grid("Get");
        local.RadicadoInterno = {};
        local.RadicadoInterno.RadicadoInternoDocumento = $("#RadicadoInternoDocumento_AnexoList").Grid("Get");
        local.RadicadoInternoRespuesta = {};
        local.RadicadoInternoRespuesta.RadicadoInternoDocumento = $("#RadicadoInternoRespuestaDocumento_AnexoList").Grid("Get");
        local.Respuesta.RespuestaDocumento = $("#RespuestaDocumento_AnexoList").Grid("Get");
        local.Respuesta.RespuestaAdicional = $("#RespuestaAdicional_RespuestaAdicionalList").Grid("Get");
        Ultimus.AjaxPostData("{0}/CorrExtEnviada.svc/api/Radicado_Descartar".format(WCFUrl), local, true, false, function (data) {
            $("#btnBotones_Descartar").prop("disabled", false);
            $("#btnBotones_Completar").prop("disabled", false);
            Response(data, function () {
                alert("Se ha descartado el incidente No. " + data.UltimusIncident);
                CloseForm();
            });
        }, "ERROR");
    }
}

this.Radicado_Firmar = function () {
    if (IsDoubleClicked($(this))) return;
    if (confirm("¿Seguro que desea aprobar y firmar digitalmente esta solicitud?")) {
        $("#btnRespuestaDecision_Firmar").prop("disabled", true);
        $("#btnBotones_Completar").prop("disabled", true);
        var local = ObtenerModelo();
        CargarRelacionCampos();
        local = RelacionCamposFramework.Guardar(local);
        Ultimus.AjaxPostData("{0}/CorrExtEnviada.svc/api/Radicado_Firmar".format(WCFUrl), local, true, false, function (data) {
            $("#btnRespuestaDecision_Firmar").prop("disabled", false);
            $("#btnBotones_Completar").prop("disabled", false);
            Response(data, function () {
                $("#ifrFirmarDocumento").prop("src", 'about:blank');
                setTimeout(function () {
                    $("#ifrFirmarDocumento").prop("src", data.Respuesta.UrlParaFirma);
                    $("#modalFirmarDocumento").modal("show");
                    $("#modalFirmarDocumento").on("hidden.bs.modal", function () {
                        CloseForm();
                    });
                }, 100);
            });
        }, "ERROR");
    }
}

this.CargarFormulario = function (data) {
    if (data.Radicado == null) {
        $("#liRecibido").hide();
        $("#frmRadicadoDocumento").hide();
    }
    if (data.RadicadoInterno == null) {
        $("#frmRadicadoInternoDocumento").hide();
    }
    if (data.RadicadoInternoRespuesta == null) {
        $("#frmRadicadoInternoRespuestaDocumento").hide();
    }
    $("#frmRadicado").reset();
    $("#frmRespuesta").reset();
    CargarRelacionCampos();
    RelacionCamposFramework.Cargar(data);
    if (data.Radicado != null) {
        $("#txtRadicado_Remitente").val(data.Radicado.Remitente);
    }
    $("#frmRadicado").valid();
    $("#frmRespuesta").valid();
    $("#frmRespuestaAdicional").valid();
    if (data.Respuesta != null && data.Respuesta.RutaVirtualDocumento != null) {
        $("#ifrDocumento").prop("src", data.Respuesta.RutaVirtualDocumento);
    }
    if (data.Radicado != null) {
        if (data.Radicado.CodigoFuente != 2) {
            $("#subMenu2").hide();
            $("#liCorreo").hide();
        }
        if (data.Radicado.CodigoFuente != 3) {
            $("#subMenu3").hide();
            $("#liPqrsdf").hide();
        }
        if (data.Radicado.CodigoFuente != 2 && data.Radicado.CodigoFuente != 3) {
            $("#liRadicado").hide();
        }
        $("#RadicadoDocumento_AnexoList").Grid("RenderGrid", data.Radicado.RadicadoDocumento);
        if (data.Radicado.CorreoFuente != null) {
            $("#Radicado_CuerpoCorreoFuente").html(data.Radicado.CorreoFuente.Cuerpo);
        }
        if (data.Radicado.GrupoEtnicoReconoce == true) {
            $("#radio_Radicado_GrupoEtnicoReconoce_0").attr('checked', true);
        } else {
            $("#radio_Radicado_GrupoEtnicoReconoce_1").attr('checked', true);
        }
        if (data.Radicado.GrupoEtnicoIndigenaTieneCargo == true) {
            $("#radio_Radicado_GrupoEtnicoIndigenaTieneCargo_0").attr('checked', true);
        } else {
            $("#radio_Radicado_GrupoEtnicoIndigenaTieneCargo_1").attr('checked', true);
        }
        if (data.Radicado.PqrsFuente != null) {
            if (data.Radicado.PqrsFuente.GrupoEtnicoReconoce == true) {
                $("#radio_Radicado_GrupoEtnicoReconocePqrsFuente_0").attr('checked', true);
            } else {
                $("#radio_Radicado_GrupoEtnicoReconocePqrsFuente_1").attr('checked', true);
            }
            if (data.Radicado.PqrsFuente.GrupoEtnicoIndigenaTieneCargo == true) {
                $("#radio_Radicado_GrupoEtnicoIndigenaTieneCargoPqrsFuente_0").attr('checked', true);
            } else {
                $("#radio_Radicado_GrupoEtnicoIndigenaTieneCargoPqrsFuente_1").attr('checked', true);
            }
        }
    }
    if (data.Respuesta != null) {
        $("#RespuestaAdicional_RespuestaAdicionalList").Grid("RenderGrid", data.Respuesta.RespuestaAdicional);
        $("#RespuestaDocumento_AnexoList").Grid("RenderGrid", data.Respuesta.RespuestaDocumento);
    }
    if (data.RadicadoInterno != null) {
        $("#RadicadoInternoDocumento_AnexoList").Grid("RenderGrid", data.RadicadoInterno.RadicadoInternoDocumento);
    }
    if (data.RadicadoInternoRespuesta != null) {
        $("#RadicadoInternoRespuestaDocumento_AnexoList").Grid("RenderGrid", data.RadicadoInternoRespuesta.RadicadoInternoDocumento);
    }

    EvaluarEstadosControlesFramework();
}