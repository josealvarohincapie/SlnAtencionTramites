$("#frmGestionPeticion").EnableValidationToolTip();
$("#frmDecision").EnableValidationToolTip();
$("#frmInfoRadicado").EnableValidationToolTip();
$("#frmAnexosRadicado").EnableValidationToolTip();
$("#frmRegistroPeticionarios").EnableValidationToolTip();
$("#frmClasificacionPeticion").EnableValidationToolTip();



jQuery(document).ready(function () {
    UpdateControlsSettings("FILTRO_FRM_GestionPeticionATSol", "GestionPeticionATSol", "frmGestionPeticion", function () {
        UpdateControlsSettings("FILTRO_FRM_DecisionATSol", "DecisionATSol", "frmDecision", function () {
            UpdateControlsSettings("FILTRO_FRM_InfoRadicadoATSol", "InfoRadicadoATSol", "frmInfoRadicado", function () {
                UpdateControlsSettings("FILTRO_FRM_AnexosRadicadoATSol", "AnexosRadicadoATSol", "frmAnexosRadicado", function () {
                    UpdateControlsSettings("FILTRO_FRM_PeticionarioATSol", "PeticionarioATSol", "frmRegistroPeticionarios", function () {
                        UpdateControlsSettings("FILTRO_FRM_PeticionarioTablaATSol", "PeticionarioTablaATSol", "frmRegistroPeticionarios", function () {
                            UpdateControlsSettings("FILTRO_FRM_PeticionarioEnfoqueATSol", "PeticionarioEnfoqueATSol", "frmRegistroPeticionarios", function () {
                                UpdateControlsSettings("FILTRO_FRM_ClasificacionPeticionATSol", "ClasificacionPeticionATSol", "frmClasificacionPeticion", function () {
                                    getDataModel();
                                });
                            });
                        });
                    }); 
                }); 
            });                       
        });
    });
});


this.getDataModel = function () {
    ENDREQUEST();
    $("#btnBotonesAT_ImprimirPantalla").unbind("click");
    $("#btnBotonesAT_ImprimirPantalla").click(function () {
        window.print();
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

    Grid_Init("ClasificacionPeticionATSol_DerechosLista", null, true, function (fila) {
        fila.Derecho = fila.Derecho.Nombre;
        fila.Opciones = $("#OpcionesEditarFila").html();
    })

    var local = ObtenerModelo();

    local.CodigoSolicitudOriginal = 5;

    Ultimus.AjaxPostData("{0}/ClasificacionTramites.svc/api/Radicado_Cargar".format(WebAplicationWCF), local, true, false, function (data) {
        //debugger;
        Response(data, function () {
            CargarFormulario(data);
        });
    }, "ERROR");
    
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

        $("#ClasificacionPeticionATSol_DerechosLista").Grid("RenderGrid", data.Radicado.DerechosClasificacion);
    }
}


this.CargarClasificacionPeticion = function (ClasificacionPeticion) {

    //CargarRelacionCampos();

    //RelacionCamposFramework.Cargar(data);

    if (ClasificacionPeticion != null) {

        $("#hiddenClasificacionPeticionATSol_TipoPeticion").val(ClasificacionPeticion.TipoPeticion.Codigo);
        $("#txtClasificacionPeticionATSol_TipoPeticion").val(ClasificacionPeticion.TipoPeticion.Nombre);

        $("#txtClasificacionPeticionATSol_DescripcionTipoPeticion").val(ClasificacionPeticion.TipoPeticion.Descripcion);

        $("#hiddenClasificacionPeticionATSol_AreaDerechos").val(ClasificacionPeticion.AreaDerecho.Codigo);
        $("#txtClasificacionPeticionATSol_AreaDerechos").val(ClasificacionPeticion.AreaDerecho.Nombre);

        $("#txtClasificacionPeticionATSol_Descripcion").val(ClasificacionPeticion.DescripcionAsesoria);
        $("#txtClasificacionPeticionATSol_Observaciones").val(ClasificacionPeticion.Observaciones);

        if (ClasificacionPeticion.RespuestaEscrito == true) {
            $("#radio_ClasificacionPeticionATSol_RespuestaEscrita_0").attr('checked', true);
        } else {
            $("#radio_ClasificacionPeticionATSol_RespuestaEscrita_1").attr('checked', true);
        }

        $("#hiddenClasificacionPeticionATSol_ConclusionAsesoria").val(ClasificacionPeticion.ConclusionAsesoria.Codigo);
        $("#txtClasificacionPeticionATSol_ConclusionAsesoria").val(ClasificacionPeticion.ConclusionAsesoria.Nombre);
    }
}
