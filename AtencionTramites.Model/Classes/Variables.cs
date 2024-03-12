using System;
using System.Configuration;
using System.Text;
using Ultimus.Utilitarios;

namespace AtencionTramites.Model.Classes
{
	public class Variables
	{
		private string RegeditKey;

		public string UserManagerUrl => new ObtieneParametros().GetValueKeyRegedit("UserManagerUrl", Decrypt: false);

		public string UltimusDocumentsUrl => new ObtieneParametros().GetValueKeyRegedit("UltimusDocumentsUrl", Decrypt: false);

		public string UltimusAttachmentUrl => new ObtieneParametros().GetValueKeyRegedit("UltimusAttachmentUrl", Decrypt: false);

		public string UltimusAttachmentPath => new ObtieneParametros().GetValueKeyRegedit("UltimusAttachmentPath", Decrypt: false);

		public string UltimusAttachmentMaxSize => new ObtieneParametros().GetValueKeyRegedit("UltimusAttachmentMaxSize", Decrypt: false);

		public string DbAtencionTramites => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("DbAtencionTramites", Decrypt: true);

		public string DbUltimus => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("DbUltimus", Decrypt: true);

		public string DbUltimusOC => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("DbUltimusOC", Decrypt: true);

		public string CorrExtRecibida_NombreProceso => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("CorrExtRecibida_NombreProceso", Decrypt: false);

		public string CorrExtRecibida_InitiateUserID => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("CorrExtRecibida_InitiateUserID", Decrypt: false);

		public string CorrExtEnviada_NombreProceso => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("CorrExtEnviada_NombreProceso", Decrypt: false);

		public string CorrInterna_NombreProceso => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("CorrInterna_NombreProceso", Decrypt: false);

		public string CorrInterna_InitiateUserID => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("CorrInterna_InitiateUserID", Decrypt: false);

		public string CorrUtilitarios_NombreProceso => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("CorrUtilitarios_NombreProceso", Decrypt: false);

		public string PQRSD_NombreProceso => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("PQRSD_NombreProceso", Decrypt: false);

		public string PQRSD_AdjuntosRequeridos => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("PQRSD_AdjuntosRequeridos", Decrypt: false);

		public string PQRSD_Entidad => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("PQRSD_EntidadPorDefecto", Decrypt: false);

		public string PQRSD_Secretaria => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("PQRSD_SecretariaPorDefecto", Decrypt: false);

		public string PQRSD_CodigoEntidad => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("PQRSD_EntidadCodigoPorDefecto", Decrypt: false);

		public string PQRSD_CodigoSecretaria => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("PQRSD_SecretariaCodigoPorDefecto", Decrypt: false);

		public string RutaDocumentos => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("RutaDocumentos", Decrypt: false);

		public string ExtensionesPermitidas => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("ExtensionesPermitidas", Decrypt: false);

		public bool MostrarFirmasEscaneadas => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("MostrarFirmasEscaneadas", Decrypt: false) == "true";

		public string FirmaElectronicaRazon => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("FirmaElectronicaRazon", Decrypt: false);

		public string FirmaElectronicaUbicacion => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("FirmaElectronicaUbicacion", Decrypt: false);

		public string FirmaElectronicaApi => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("FirmaElectronicaApi", Decrypt: false);

		public string FirmaElectronicaApiKey => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("FirmaElectronicaApiKey", Decrypt: false);

		public string EmailCertificadoUsuario => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("EmailCertificadoUsuario", Decrypt: false);

		public string EmailCertificadoPassword => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("EmailCertificadoPassword", Decrypt: true);

		public string EmailCertificadoEndPoint => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("EmailCertificadoEndPoint", Decrypt: false);

		public string EmailCertificadoCodigosValidos => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("EmailCertificadoCodigosValidos", Decrypt: false);

		public string WebUrl => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("WebUrl", Decrypt: false);

		public string WCFUrl => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("WCFUrl", Decrypt: false);

		public string IntegracionDozzierWebUrl => new ObtieneParametros("IntegracionDozzier").GetValueKeyRegedit("WebUrl", Decrypt: false);

		public string IntegracionDozzierWCFUrl => new ObtieneParametros("IntegracionDozzier").GetValueKeyRegedit("WCFUrl", Decrypt: false);

		public string Outlook365ClientId => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("Outlook365ClientId", Decrypt: false);

		public string Outlook365TenantId => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("Outlook365TenantId", Decrypt: false);

		public string Outlook365ClientSecret => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("Outlook365ClientSecret", Decrypt: false);

		public string Outlook365Email => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("Outlook365Email", Decrypt: false);

		public string InitiateUserID => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("Initiate.UserID", Decrypt: false);

		public string InitiateUserFullName => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("Initiate.UserFullName", Decrypt: false);

		public string PorcentajeTareaUrgente => new ObtieneParametros(RegeditKey).GetValueKeyRegedit("PorcentajeTareaUrgente", Decrypt: false);

		public string ExternalServiceSecretKey => Convert.ToBase64String(Encoding.UTF8.GetBytes(new ObtieneParametros(RegeditKey).GetValueKeyRegedit("ExternalServiceSecretKey", Decrypt: true)));

		public int ExternalServiceMinutesExpires => int.Parse(new ObtieneParametros(RegeditKey).GetValueKeyRegedit("ExternalServiceMinutesExpires", Decrypt: false));

		public int ExternalServiceRefreshMinutesExpires => int.Parse(new ObtieneParametros(RegeditKey).GetValueKeyRegedit("ExternalServiceRefreshMinutesExpires", Decrypt: false));

		public Variables()
		{
			RegeditKey = ConfigurationManager.AppSettings["ULA.RegeditKey"];
		}
	}
}
