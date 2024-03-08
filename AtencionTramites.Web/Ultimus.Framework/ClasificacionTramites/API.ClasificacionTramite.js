$("#frmInfoRadicado").EnableValidationToolTip();
$("#frmAnexosRadicado").EnableValidationToolTip();
$("#frmRegistroPeticionarios").EnableValidationToolTip();
$("#frmClasificacionPeticion").EnableValidationToolTip();
$("#frmConclusionPeticion").EnableValidationToolTip();

jQuery(document).ready(function () {
    UpdateControlsSettings("FILTRO_FRM_BotonesAT", "BotonesAT", "frmBotones", function () {
        UpdateControlsSettings("FILTRO_FRM_AnexosRadicadoAT", "AnexosRadicadoAT", "frmAnexosRadicado", function () {
            UpdateControlsSettings("FILTRO_FRM_BotonesAT", "BotonesAT", "frmBotones", function () {
                UpdateControlsSettings("FILTRO_FRM_ClasificacionPeticionAT", "ClasificacionPeticionAT", "frmClasificacionPeticion", function () {
                    UpdateControlsSettings("FILTRO_FRM_DecisionAT", "DecisionAT", "frmConclusionPeticion", function () {
                        UpdateControlsSettings("FILTRO_FRM_InfoRadicadoAT", "InfoRadicadoAT", "frmInfoRadicado", function () {
                            UpdateControlsSettings("FILTRO_FRM_PeticionarioEnfoqueAT", "PeticionarioEnfoqueAT", "frmRegistroPeticionarios", function () {
                                UpdateControlsSettings("FILTRO_FRM_PeticionariosAT", "PeticionariosAT", "frmRegistroPeticionarios", function () {
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
}