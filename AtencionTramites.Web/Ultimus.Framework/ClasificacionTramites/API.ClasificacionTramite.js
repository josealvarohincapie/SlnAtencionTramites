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
    ENDREQUEST();
    SetearAccordion();
    $("#btnBotonesAT_ImprimirPantalla").unbind("click");
    $("#btnBotonesAT_ImprimirPantalla").click(function () {
        window.print();
        return false;
    });
	
	$("#chkPeticionarioAT_Contacto").unbind("click");
    $("#chkPeticionarioAT_Contacto").click(function () {
        OcultarCamposContactoPeticionario()
    });
    
    $("#txtClasificacionPeticionAT_TipoPeticion").unbind("change");
    $("#txtClasificacionPeticionAT_TipoPeticion").change(function () {
        RefrescarDescripcionTipoPeticion();
        
    });

    $("#btnClasificacionPeticionAT_AgregarDerecho").unbind("click");
    $("#btnClasificacionPeticionAT_AgregarDerecho").click(function () {
        AgregarDerecho();
        return false;
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
        fila.Derecho = fila.Derecho.Nombre;
        fila.Opciones = $("#OpcionesEditarFila").html();        
    });
    
    $("#radio_ClasificacionPeticionAT_RespuestaEscrita_0").unbind("click");
    $("#radio_ClasificacionPeticionAT_RespuestaEscrita_0").click(function () {
        //debugger;
        OcultarCampoConclusionAsesoria();
    });

    $("#radio_ClasificacionPeticionAT_RespuestaEscrita_1").unbind("click");
    $("#radio_ClasificacionPeticionAT_RespuestaEscrita_1").click(function () {
        //debugger;
        OcultarCampoConclusionAsesoria();
    });
    
    $("#lblPeticionarioAT_Correo").hide();
    $("#lblPeticionarioAT_Telefono").hide();
    $("#lblPeticionarioAT_Direccion").hide();
    $("#txtPeticionarioAT_Correo").hide();
    $("#txtPeticionarioAT_Telefono").hide();
    $("#txtPeticionarioAT_Direccion").hide();
    
    $("#lblClasificacionPeticionAT_ConclusionAsesoria").hide();
    $("#txtClasificacionPeticionAT_ConclusionAsesoria").hide();
    $("#btn_eliminarClasificacionPeticionAT_ConclusionAsesoria").hide();
    $("#btnClasificacionPeticionAT_ConclusionAsesoria").hide();

	$("#btnBotonesAT_Completar").unbind("click");
    $("#btnBotonesAT_Completar").click(function () {
        debugger;
        Radicado_Completar();
    });

    $("#btnRadicadoDecision_Decision").unbind("click");
    $("#btnRadicadoDecision_Decision").click(function () {
        var local = ObtenerModelo();
        local.CodigoTipoDocumento = $("#hiddenRadicado_TipoDocumento").val();
        local.CodigoSubTipoDocumento = $("#hiddenRadicado_SubTipoDocumento").val();
        SelectedCatalog = "RadicadoDecision_Decision";
        Ultimus.CargarDataCatalogo(null, null, local);
    });

	var local = ObtenerModelo();

    local.CodigoSolicitudOriginal = 5;
    
    Ultimus.AjaxPostData("{0}/ClasificacionTramites.svc/api/Radicado_Cargar".format(WebAplicationWCF), local, true, false, function (data) {
        //debugger;
        Response(data, function () {
            CargarFormulario(data);
        });
    }, "ERROR");
}

this.Radicado_Completar = function () {
    debugger;
    //if (IsDoubleClicked($(this))) return;
    //if (!$("#frmRespuesta").valid() || !$("#frmRadicadoDecision").valid()) {
    //    toastr.warning(MensajeValidarFormulario, Message_Warning);
    //    return;
    //}

    //$(":input").each(function () {
    //    if (!$(this).is(":hidden")) {
    //        this.value = this.value.toUpperCase();
    //    }
    //});

    var local = ObtenerModelo();
    //CargarRelacionCampos();
  
 
    //if (confirm("¿Desea enviar esta solicitud a la siguiente etapa?")) {
        //$("#btnBotones_Descartar").prop("disabled", true);
        //$("#btnBotones_Completar").prop("disabled", true);
        //local.Hash = $("#lblRespuestaDecision_FirmaHash").text();
        //local.Radicado.RadicadoDocumento = $("#RadicadoDocumento_AnexoList").Grid("Get");
        //local.RadicadoInterno = {};
        //local.RadicadoInterno.RadicadoInternoDocumento = $("#RadicadoInternoDocumento_AnexoList").Grid("Get");
        //local.RadicadoInternoRespuesta = {};
        //local.RadicadoInternoRespuesta.RadicadoInternoDocumento = $("#RadicadoInternoRespuestaDocumento_AnexoList").Grid("Get");
        //local.Respuesta.RespuestaDocumento = $("#RespuestaDocumento_AnexoList").Grid("Get");
        //local.Respuesta.RespuestaAdicional = $("#RespuestaAdicional_RespuestaAdicionalList").Grid("Get");
    Ultimus.AjaxPostData("{0}/ClasificacionTramites.svc/api/Radicado_Completar".format(WebAplicationWCF), local, true, false, function (data) {
            //$("#btnBotones_Descartar").prop("disabled", false);
            //$("#btnBotones_Completar").prop("disabled", false);
            debugger;
            if (data != null) { alert(data); }
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
    //}
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

        $("#txtClasificacionPeticionAT_DescripcionTipoPeticion").val(ClasificacionPeticion.TipoPeticion.Descripcion);
        
        $("#hiddenClasificacionPeticionAT_AreaDerechos").val(ClasificacionPeticion.AreaDerecho.Codigo);
        $("#txtClasificacionPeticionAT_AreaDerechos").val(ClasificacionPeticion.AreaDerecho.Nombre);

        $("#txtClasificacionPeticionAT_Descripcion").val(ClasificacionPeticion.DescripcionAsesoria);
        $("#txtClasificacionPeticionAT_Observaciones").val(ClasificacionPeticion.Observaciones);

        if (ClasificacionPeticion.RespuestaEscrito == true) {
            $("#radio_ClasificacionPeticionAT_RespuestaEscrita_0").attr('checked', true);

            $("#lblClasificacionPeticionAT_ConclusionAsesoria").hide();
            $("#txtClasificacionPeticionAT_ConclusionAsesoria").hide();
            $("#btn_eliminarClasificacionPeticionAT_ConclusionAsesoria").hide();
            $("#btnClasificacionPeticionAT_ConclusionAsesoria").hide();

        } else {
            $("#radio_ClasificacionPeticionAT_RespuestaEscrita_1").attr('checked', true);

            $("#lblClasificacionPeticionAT_ConclusionAsesoria").show();
            $("#txtClasificacionPeticionAT_ConclusionAsesoria").show();
            $("#btn_eliminarClasificacionPeticionAT_ConclusionAsesoria").show();
            $("#btnClasificacionPeticionAT_ConclusionAsesoria").show();
        }

        $("#hiddenClasificacionPeticionAT_ConclusionAsesoria").val(ClasificacionPeticion.ConclusionAsesoria.Codigo);
        $("#txtClasificacionPeticionAT_ConclusionAsesoria").val(ClasificacionPeticion.ConclusionAsesoria.Nombre);
    }
}

this.RefrescarDescripcionTipoPeticion = function () {
    /*
    var params = {};
    params.CodigoTipoPeticion = $("#hiddenClasificacionPeticionAT_TipoPeticion").val();
    
    Ultimus.AjaxPostData("{0}/Catalogos.svc/api/ObtenerCatalogoTipoPeticion".format(WebAplicationWCF), params, true, false, function (data) {
        setTimeout(() => {
            console.log("1 Segundo esperado");
            Response(data, function () {
                cargarDescripcionTipoPeticion(data)
            });
        }, 3000);
        
    }, "ERROR");
    */
}

this.cargarDescripcionTipoPeticion = function (dataTipoPeticion) {
    debugger;
    alert(dataTipoPeticion[0].Descripcion);
    $("#txtClasificacionPeticionAT_DescripcionTipoPeticion").val(dataTipoPeticion[0].Descripcion);
}
this.OcultarCamposContactoPeticionario = function () {

    var isChecked = $('#chkPeticionarioAT_Contacto').attr('checked') ? true : false;

    if (isChecked) {

        $("#lblPeticionarioAT_Correo").show();
        $("#lblPeticionarioAT_Telefono").show();
        $("#lblPeticionarioAT_Direccion").show();
        $("#txtPeticionarioAT_Correo").show();
        $("#txtPeticionarioAT_Telefono").show();
        $("#txtPeticionarioAT_Direccion").show();
    } else {

        $("#lblPeticionarioAT_Correo").hide();
        $("#lblPeticionarioAT_Telefono").hide();
        $("#lblPeticionarioAT_Direccion").hide();
        $("#txtPeticionarioAT_Correo").hide();
        $("#txtPeticionarioAT_Telefono").hide();
        $("#txtPeticionarioAT_Direccion").hide();

        $("#txtPeticionarioAT_Direccion").val("");
        $("#txtPeticionarioAT_Correo").val("");
        $("#txtPeticionarioAT_Telefono").val("");
    }
}

this.OcultarCampoConclusionAsesoria = function () {
    var isChecked = $('#radio_ClasificacionPeticionAT_RespuestaEscrita_1').attr('checked') ? true : false;
    
    if (isChecked) {

        $("#lblClasificacionPeticionAT_ConclusionAsesoria").show();
        $("#txtClasificacionPeticionAT_ConclusionAsesoria").show();
        $("#btn_eliminarClasificacionPeticionAT_ConclusionAsesoria").show();
        $("#btnClasificacionPeticionAT_ConclusionAsesoria").show();
    } else {

        $("#lblClasificacionPeticionAT_ConclusionAsesoria").hide();
        $("#txtClasificacionPeticionAT_ConclusionAsesoria").hide();
        $("#btn_eliminarClasificacionPeticionAT_ConclusionAsesoria").hide();
        $("#btnClasificacionPeticionAT_ConclusionAsesoria").hide();

        $("#hiddenClasificacionPeticionAT_ConclusionAsesoria").val("");
        $("#txtClasificacionPeticionAT_ConclusionAsesoria").val("");
    }
}


this.GuardarClasificacion = function () {
    if (IsDoubleClicked($(this))) return;

    $(":input").each(function () {
        if (!$(this).is(":hidden")) {
            this.value = this.value.toUpperCase();
        }
    });

    if (!$("#frmClasificacionPeticion").valid()) {
        toastr.warning(MensajeValidarFormulario, Message_Warning);
        return;
    }

    var local = ObtenerModelo();
    CargarRelacionCampos();

    local = RelacionCamposFramework.Guardar(local);

    /*
    local.Radicado.RadicadoDocumento = $("#RadicadoDocumento_AnexoList").Grid("Get");
    local.RadicadoInterno = {};
    local.RadicadoInterno.RadicadoInternoDocumento = $("#RadicadoInternoDocumento_AnexoList").Grid("Get");
    local.RadicadoInternoRespuesta = {};
    local.RadicadoInternoRespuesta.RadicadoInternoDocumento = $("#RadicadoInternoRespuestaDocumento_AnexoList").Grid("Get");
    local.Respuesta.RespuestaDocumento = $("#RespuestaDocumento_AnexoList").Grid("Get");
    local.Respuesta.RespuestaAdicional = $("#RespuestaAdicional_RespuestaAdicionalList").Grid("Get");
    Ultimus.AjaxPostData("{0}/AtencionTramiteAse.svc/api/GuardarClasificacion".format(WCFUrl), local, true, false, function (data) {
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
    */
}

this.AgregarDerecho = function () {
    
    var paramsDerecho = {};
    paramsDerecho.CodigoSolicitud = 5;
    paramsDerecho.DerechosClasificacion = [];
    paramsDerecho.DerechosClasificacion[0] = {};
    paramsDerecho.DerechosClasificacion[0].CodigoSolicitud = 5;
    paramsDerecho.DerechosClasificacion[0].CodigoDerecho = $("#hiddenClasificacionPeticionAT_Derechos").val();
    paramsDerecho.DerechosClasificacion[0].NombreUsuarioCreacion = "xxx";
    paramsDerecho.DerechosClasificacion[0].IDUsuarioCreacion = "yyy";
    debugger;
    Ultimus.AjaxPostData("{0}/ClasificacionTramites.svc/api/GuardarDerechosClasificacion".format(WebAplicationWCF), paramsDerecho, true, false, function (data) {
            Response(data, function () {
                alert(data.CodigoRespuesta);
            });
    }, "ERROR");

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