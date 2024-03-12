using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using AtencionTramites.Model.Classes;
using Newtonsoft.Json;

namespace Correspondencia.WCF.Classes
{
	public class FirmaElectronicaInterface
	{
		public static FirmaRes FirmaSinClavePrivada(FirmaJSON firmaJSON)
		{
			Variables variables = new Variables();
			string Client_FirmaService = variables.FirmaElectronicaApi;
			string ApiKey = variables.FirmaElectronicaApiKey;
			using (HttpClient client = new HttpClient())
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("ApiKey", ApiKey);
				string currentDomain = HttpContext.Current.Request.Url.Host;
				string serviceDomain = new Uri(Client_FirmaService).Host;
				firmaJSON.TipoDocumento = ((currentDomain == serviceDomain) ? 1.ToString() : 2.ToString());
				string jsonInput = JsonConvert.SerializeObject(firmaJSON);
				HttpResponseMessage response = client.PostAsync($"{Client_FirmaService}/PKIService/FirmaSinClavePrivada", new StringContent(jsonInput, Encoding.UTF8, "application/json")).Result;
				if (response.IsSuccessStatusCode)
				{
					return response.Content.ReadAsAsync<FirmaRes>().Result;
				}
				throw new Exception(response.ReasonPhrase);
			}
		}

		public static string CargarDocumentoFirmado(string TipoDocumento, int Id)
		{
			Variables variables = new Variables();
			string Client_FirmaService = variables.FirmaElectronicaApi;
			string ApiKey = variables.FirmaElectronicaApiKey;
			using (HttpClient client = new HttpClient())
			{
				_ = HttpContext.Current.Request.Url.Host;
				_ = new Uri(Client_FirmaService).Host;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.DefaultRequestHeaders.Add("ApiKey", ApiKey);
				client.DefaultRequestHeaders.Add("TipoDocumento", TipoDocumento);
				HttpResponseMessage response = client.GetAsync($"{Client_FirmaService}/PKIService/CargarDocumentoFirmado/{Id}").Result;
				if (response.IsSuccessStatusCode)
				{
					return response.Content.ReadAsAsync<string>().Result;
				}
				throw new Exception(response.ReasonPhrase);
			}
		}
	}
}