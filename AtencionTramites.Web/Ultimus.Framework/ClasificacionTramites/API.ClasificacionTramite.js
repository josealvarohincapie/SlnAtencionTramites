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
    $("#btnBotonesAT_ImprimirPantalla").unbind("click");
    $("#btnBotonesAT_ImprimirPantalla").click(function () {
        window.print();
        return false;
    });

    $("#txtRadicado_TipoDocumento").unbind("change");
    $("#hiddenClasificacionPeticionAT_TipoPeticion").change(function () {
        Radicado_CargarHorasDiasVencimiento();
        //$("#hiddenClasificacionPeticionAT_TipoPeticion").val(ClasificacionPeticion.TipoPeticion.Codigo);
    });
    
    Grid_Init("AnexosRadicadoAT_AnexosLista", null, true, function (fila) {
        fila.TamanoArchivoFormatted = CustomNumberFormat(fila.TamanoArchivo);
        fila.FechaCreacionFormatted = fila.FechaCreacion == this.undefined ? null : FormatDateTime(fila.FechaCreacion, true);
        fila.NombreUsuarioCreacion = fila.NombreUsuarioCreacion == this.undefined ? null : fila.NombreUsuarioCreacion;
        fila.OpcionesRadicadoDocumento = $("#OpcionesAnexosLectura").html();
        fila.OpcionesRadicadoDocumento = replaceAll("#RutaVirtualArchivo#", fila.RutaVirtualArchivo, fila.OpcionesRadicadoDocumento);
        fila.OpcionesRadicadoDocumento = replaceAll("#CodigoDocumento#", fila.CodigoDocumento, fila.OpcionesRadicadoDocumento);
    });

    Grid_Init("ClasificacionPeticionAT_DerechosLista", null, true, function (fila) {
        debugger;
        fila.Derecho = fila.Derecho.Nombre;
        fila.Opciones = $("#OpcionesEditarFila").html();        
    });


    var local = ObtenerModelo();

    local.CodigoSolicitudOriginal = 5;
    
    Ultimus.AjaxPostData("{0}/ClasificacionTramites.svc/api/Radicado_Cargar".format(WebAplicationWCF), local, true, false, function (data) {
        debugger;
        Response(data, function () {
            CargarFormulario(data);
        });
    }, "ERROR");
    /*
    Ultimus.AjaxPostData("{0}/ClasificacionTramites.svc/api/CargarDocumentosRadicado".format(WebAplicationWCF), local, true, false, function (dataDocumentos) {
        
        Response(dataDocumentos, function () {
            $("#AnexosRadicadoAT_AnexosLista").Grid("RenderGrid", dataDocumentos.Documentos);
        });
    }, "ERROR");
    */
    /*
    Ultimus.AjaxPostData("{0}/ClasificacionTramites.svc/api/CargarClasificacionPeticion".format(WebAplicationWCF), local, true, false, function (dataClasificacion) {
        
        Response(dataClasificacion, function () {
            CargarClasificacionPeticion(dataClasificacion);
        });
    }, "ERROR");
    */

    /*
    Ultimus.AjaxPostData("{0}/Catalogos.svc/api/ObtenerAreaDerecho".format(WebAplicationWCF), local, true, false, function (data) {
        debugger;
        if (data == null) { alert('edgar'); }
        Response(data, function () {
           // CargarFormulario(data);
        });
    }, "ERROR");
    */
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

this.CargarFormulario = function (data) {

    CargarRelacionCampos();

    RelacionCamposFramework.Cargar(data);

    if (data.Radicado != null) {
        $("#txtInfoRadicadoAT_NumeroRadicado").val(data.Radicado.NumeroRadicado);
        
        $("#hiddenInfoRadicadoAT_CanalAtencion").val(data.Radicado.CodigoFuente);
        $("#txtInfoRadicadoAT_CanalAtencion").val(data.Radicado.NombreFuente);

        //alert(data.Radicado.Fecha);
        $("#txtInfoRadicadoAT_Fecha").val(data.Radicado.Fecha);

        $("#hiddenInfoRadicadoAT_TipoSolicitante").val(data.Radicado.CodigoTipoSolicitante);
        $("#txtInfoRadicadoAT_TipoSolicitante").val(data.Radicado.NombreTipoSolicitante);

        if (data.Radicado.EsAnonimo == true) {
            $('#chkInfoRadicadoAT_EsAnonimo').prop('checked', true);                 
        } else {
            $('#chkInfoRadicadoAT_EsAnonimo').prop('checked', false);
        }
        
        $("#hiddenInfoRadicadoAT_TipoDocId").val(data.Radicado.CodigoTipoDocumentoIdentificacion);
        $("#txtInfoRadicadoAT_TipoDocId").val(data.Radicado.NombreTipoDocumentoIdentificacion);
        
        $("#txtInfoRadicadoAT_NumIdentificacion").val(data.Radicado.NumeroDocumentoIdentificacion);
        $("#txtInfoRadicadoAT_Remitente").val(data.Radicado.Remitente);
        
        $("#hiddenInfoRadicadoAT_MiembroGrupoEtnico").val(data.Radicado.CodigoGrupoEtnico);
        $("#txtInfoRadicadoAT_MiembroGrupoEtnico").val(data.Radicado.NombreGrupoEtnico);
        
        $("#hiddenInfoRadicadoAT_SexoAsignado").val(data.Radicado.CodigoSexo);
        $("#txtInfoRadicadoAT_SexoAsignado").val(data.Radicado.NombreSexo);
        
        $("#hiddenInfoRadicadoAT_IdentidadGenero").val(data.Radicado.CodigoGenero);
        $("#txtInfoRadicadoAT_IdentidadGenero").val(data.Radicado.NombreGenero);
        
        $("#hiddenInfoRadicadoAT_OrientacionSexual").val(data.Radicado.CodigoOrientacionSexual);
        $("#txtInfoRadicadoAT_OrientacionSexual").val(data.Radicado.NombreOrientacionSexual);
        
        $("#hiddenInfoRadicadoAT_ExpresionGenero").val(data.Radicado.CodigoExpresionGenero);
        $("#txtInfoRadicadoAT_ExpresionGenero").val(data.Radicado.NombreExpresionGenero);
        
        $("#hiddenInfoRadicadoAT_RangoEdad").val(data.Radicado.CodigoRangoEdad);
        $("#txtInfoRadicadoAT_RangoEdad").val(data.Radicado.NombreRangoEdad);

        $("#AnexosRadicadoAT_AnexosLista").Grid("RenderGrid", data.Radicado.RadicadoDocumento);
        debugger;
        CargarClasificacionPeticion(data.Radicado.ClasificacionPeticion);

        $("#ClasificacionPeticionAT_DerechosLista").Grid("RenderGrid", data.Radicado.DerechosClasificacion);
    }

    
    /*
        $("#txtRadicado_Remitente").val(data.Radicado.Remitente);
    
        if (data.Respuesta != null && data.Respuesta.RutaVirtualDocumento != null) {
            $("#ifrDocumento").prop("src", data.Respuesta.RutaVirtualDocumento);
        }    
    */
}

this.CargarClasificacionPeticion = function (ClasificacionPeticion) {

    //CargarRelacionCampos();

    //RelacionCamposFramework.Cargar(data);
    
    if (ClasificacionPeticion != null) {

        $("#hiddenClasificacionPeticionAT_TipoPeticion").val(ClasificacionPeticion.TipoPeticion.Codigo);
        $("#txtClasificacionPeticionAT_TipoPeticion").val(ClasificacionPeticion.TipoPeticion.Nombre);

        $("#hiddenClasificacionPeticionAT_AreaDerechos").val(ClasificacionPeticion.AreaDerecho.Codigo);
        $("#txtClasificacionPeticionAT_AreaDerechos").val(ClasificacionPeticion.AreaDerecho.Nombre);

        $("#txtClasificacionPeticionAT_Descripcion").val(ClasificacionPeticion.DescripcionAsesoria);
        $("#txtClasificacionPeticionAT_Observaciones").val(ClasificacionPeticion.Observaciones);

        if (ClasificacionPeticion.RespuestaEscrito == true) {
            $("#radio_ClasificacionPeticionAT_RespuestaEscrita_0").attr('checked', true);
        } else {
            $("#radio_ClasificacionPeticionAT_RespuestaEscrita_1").attr('checked', true);
        }

        $("#hiddenClasificacionPeticionAT_ConclusionAsesoria").val(ClasificacionPeticion.ConclusionAsesoria.Codigo);
        $("#txtClasificacionPeticionAT_ConclusionAsesoria").val(ClasificacionPeticion.ConclusionAsesoria.Nombre);

        /*
        $("#hiddenClasificacionPeticionAT_TipoPeticion").val(data.ClasificacionPeticion.TipoPeticion.Codigo);
        $("#txtClasificacionPeticionAT_TipoPeticion").val(data.ClasificacionPeticion.TipoPeticion.Nombre);

        $("#hiddenClasificacionPeticionAT_AreaDerechos").val(data.ClasificacionPeticion.AreaDerecho.Codigo);
        $("#txtClasificacionPeticionAT_AreaDerechos").val(data.ClasificacionPeticion.AreaDerecho.Nombre);

        $("#txtClasificacionPeticionAT_Descripcion").val(data.ClasificacionPeticion.DescripcionAsesoria);
        $("#txtClasificacionPeticionAT_Observaciones").val(data.ClasificacionPeticion.Observaciones);

        if (data.ClasificacionPeticion.RespuestaEscrito == true) {
            $("#radio_ClasificacionPeticionAT_RespuestaEscrita_0").attr('checked', true);
        } else {
            $("#radio_ClasificacionPeticionAT_RespuestaEscrita_1").attr('checked', true);
        }

        $("#hiddenClasificacionPeticionAT_ConclusionAsesoria").val(data.ClasificacionPeticion.ConclusionAsesoria.Codigo);
        $("#txtClasificacionPeticionAT_ConclusionAsesoria").val(data.ClasificacionPeticion.ConclusionAsesoria.Nombre);
        */
    }
}