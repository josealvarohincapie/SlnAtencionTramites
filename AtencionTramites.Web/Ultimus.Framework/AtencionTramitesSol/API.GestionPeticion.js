$("#frmRadicadoEnviado").EnableValidationToolTip();
$("#frmDecision").EnableValidationToolTip();
$("#frmInfoRadicado").EnableValidationToolTip();
$("#frmAnexosRadicado").EnableValidationToolTip();
$("#frmRegistroPeticionarios").EnableValidationToolTip();
$("#frmClasificacionPeticion").EnableValidationToolTip();



jQuery(document).ready(function () {
    UpdateControlsSettings("FILTRO_FRM_RadicadoEnviadoAT", "RadicadoEnviadoAT", "frmRadicadoEnviado", function () {
        UpdateControlsSettings("FILTRO_FRM_RespuestaDecisionEE", "RespuestaDecisionEE", "frmDecision", function () {
            UpdateControlsSettings("FILTRO_FRM_InfoRadicadoAT", "InfoRadicadoAT", "frmInfoRadicado", function () {
                UpdateControlsSettings("FILTRO_FRM_AnexosRadicadoAT", "AnexosRadicadoAT", "frmAnexosRadicado", function () {
                    UpdateControlsSettings("FILTRO_FRM_PeticionarioAT", "PeticionarioAT", "frmRegistroPeticionarios", function () {
                        UpdateControlsSettings("FILTRO_FRM_PeticionarioTablaAT", "PeticionarioTablaAT", "frmRegistroPeticionarios", function () {
                            UpdateControlsSettings("FILTRO_FRM_PeticionarioEnfoqueAT", "PeticionarioEnfoqueAT", "frmRegistroPeticionarios", function () {
                                UpdateControlsSettings("FILTRO_FRM_ClasificacionPeticionAT", "ClasificacionPeticionAT", "frmClasificacionPeticion", function () {
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
/*
FILTRO_FRM_AnexosRadicadoAT	        FILTRO_FRM_AnexosRadicadoAT	 
FILTRO_FRM_BotonesAT	            FILTRO_FRM_BotonesAT	 
FILTRO_FRM_ClasificacionPeticionAT	FILTRO_FRM_ClasificacionPeticionAT	 
FILTRO_FRM_DecisionAT	|           FILTRO_FRM_DecisionAT	 
FILTRO_FRM_InfoRadicadoAT	        FILTRO_FRM_InfoRadicadoAT	 
FILTRO_FRM_PeticionarioEnfoqueAT	FILTRO_FRM_PeticionarioEnfoqueAT	 
FILTRO_FRM_PeticionariosAT	        FILTRO_FRM_PeticionariosAT	 
FILTRO_FRM_PeticionarioTablaAT	    FILTRO_FRM_PeticionarioTablaAT
*/

this.getDataModel = function () {
    ENDREQUEST();
    Grid_Init("AnexosRadicadoAT_AnexosLista", null, true, function (fila) {
        fila.TamanoArchivoFormatted = CustomNumberFormat(fila.TamanoArchivo);
        fila.FechaCreacionFormatted = fila.FechaCreacion == this.undefined ? null : FormatDateTime(fila.FechaCreacion, true);
        fila.NombreUsuarioCreacion = fila.NombreUsuarioCreacion == this.undefined ? null : fila.NombreUsuarioCreacion;
        fila.OpcionesRadicadoDocumento = $("#OpcionesAnexosLectura").html();
        fila.OpcionesRadicadoDocumento = replaceAll("#RutaVirtualArchivo#", fila.RutaVirtualArchivo, fila.OpcionesRadicadoDocumento);
        fila.OpcionesRadicadoDocumento = replaceAll("#CodigoDocumento#", fila.CodigoDocumento, fila.OpcionesRadicadoDocumento);
    });
    var local = ObtenerModelo();

    local.CodigoSolicitudOriginal = 5;

    Ultimus.AjaxPostData("{0}/ClasificacionTramites.svc/api/Radicado_Cargar".format(WebAplicationWCF), local, true, false, function (data) {
        debugger;
        Response(data, function () {
            CargarFormulario(data);
        });
    }, "ERROR");
    /*Ultimus.AjaxPostData("{0}/ClasificacionTramites.svc/api/CargarDocumentosRadicado".format(WebAplicationWCF), local, true, false, function (dataDocumentos) {
        

        Response(dataDocumentos, function () {
            $("#AnexosRadicadoAT_AnexosLista").Grid("RenderGrid", dataDocumentos.Documentos);
        });
    }, "ERROR");
    */
    Ultimus.AjaxPostData("{0}/ClasificacionTramites.svc/api/CargarClasificacionPeticion".format(WebAplicationWCF), local, true, false, function (dataClasificacion) {
        debugger;
        Response(dataClasificacion, function () {
            CargarClasificacionPeticion(dataClasificacion);
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

    }
}

this.CargarClasificacionPeticion = function (data) {

    //CargarRelacionCampos();
   
    //RelacionCamposFramework.Cargar(data);

    if (data.ClasificacionPeticion != null) {

        $("#hiddenClasificacionPeticionAT_TipoPeticion").val(data.ClasificacionPeticion.TipoPeticion.Codigo);
        $("#txtClasificacionPeticionAT_TipoPeticion").val(data.ClasificacionPeticion.TipoPeticion.Nombre);

        $("#hiddenClasificacionPeticionAT_AreaDerechos").val(data.ClasificacionPeticion.AreaDerecho.Codigo);
        $("#txtClasificacionPeticionAT_AreaDerechos").val(data.ClasificacionPeticion.AreaDerecho.Nombre);

        $("#txtClasificacionPeticionAT_Descripcion").val(data.ClasificacionPeticion.DescripcionAsesoria);
        $("#txtClasificacionPeticionAT_Observaciones").val(data.ClasificacionPeticion.Observaciones);
        
        /*
        radio_group_ClasificacionPeticionAT_RespuestaEscrita
        
        
        */
        if (data.ClasificacionPeticion.RespuestaEscrito == true) {
            $("#radio_ClasificacionPeticionAT_RespuestaEscrita_0").attr('checked', true);
        } else {
            $("#radio_ClasificacionPeticionAT_RespuestaEscrita_1").attr('checked', true);
        }

        $("#hiddenClasificacionPeticionAT_ConclusionAsesoria").val(data.ClasificacionPeticion.ConclusionAsesoria.Codigo);
        $("#txtClasificacionPeticionAT_ConclusionAsesoria").val(data.ClasificacionPeticion.ConclusionAsesoria.Nombre);
    }
}
