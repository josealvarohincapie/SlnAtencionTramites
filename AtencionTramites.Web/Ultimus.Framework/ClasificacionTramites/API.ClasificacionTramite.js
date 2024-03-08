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
	SetearAccordion()

	$("#btnBotonesAT_ImprimirPantalla").unbind("click");
	$("#btnBotonesAT_ImprimirPantalla").click(function () {
		window.print();
		return false;
	});

	$("#btnBotonesAT_GuardarRadicado").unbind("click");
	$("#btnBotonesAT_GuardarRadicado").click(function () {
		GuardarClasificacion();
	});
	
	$("#btnBotonesAT_Completar").unbind("click");
	$("#btnBotonesAT_Completar").click(function () {
		window.print();
		return false;
	});
	
	$("#chkPeticionarioAT_Contacto").unbind("click");
	$("#chkPeticionarioAT_Contacto").click(function () {
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
		}
	});

	$("#chkClasificacionPeticionAT_RespuestaEscrita").unbind("click");
	$("#chkClasificacionPeticionAT_RespuestaEscrita").click(function () {
		var isChecked = $('#chkClasificacionPeticionAT_RespuestaEscrita').attr('checked') ? true : false;

		if (isChecked) {

			$("#lblClasificacionPeticionAT_ConclusionAsesoria").show();
			$("#txtClasificacionPeticionAT_ConclusionAsesoria").show();
		} else {

			$("#lblClasificacionPeticionAT_ConclusionAsesoria").hide();
			$("#txtClasificacionPeticionAT_ConclusionAsesoria").hide();
		}
	});

	$("#lblPeticionarioAT_Correo").hide();
	$("#lblPeticionarioAT_Telefono").hide();
	$("#lblPeticionarioAT_Direccion").hide();
	$("#txtPeticionarioAT_Correo").hide();
	$("#txtPeticionarioAT_Telefono").hide();
	$("#txtPeticionarioAT_Direccion").hide();

	$("#lblClasificacionPeticionAT_ConclusionAsesoria").hide();
	$("#txtClasificacionPeticionAT_ConclusionAsesoria").hide();
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
