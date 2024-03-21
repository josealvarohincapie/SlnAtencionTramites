$("#frmRadicadoEnviado").EnableValidationToolTip();
$("#frmDecision").EnableValidationToolTip();


jQuery(document).ready(function () {
    UpdateControlsSettings("FILTRO_FRM_RadicadoEnviadoAT", "RadicadoEnviadoAT", "frmRadicadoEnviado", function () {
        UpdateControlsSettings("FILTRO_FRM_RespuestaDecisionEE", "RespuestaDecisionEE", "frmDecision", function () {
            
                                        getDataModel();
                                    
        });
    });
});

this.getDataModel = function () {
    ENDREQUEST();
    SetearAccordion();

    $("#btnBotones_ImprimirPantalla").unbind("click");
    $("#btnBotones_ImprimirPantalla").click(function () {
        window.print();
        return false;
    });
}