using Net.Pandiri.Trading.Models;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;

namespace Net.Pandiri.Trading
{
	public class RobinhoodClient : IBrokerageClient
	{
		private string userName = null;
		private string password = null;
		private HttpClient client = null;
		private string deviceToken = null;

		private string AccessToken = null;
		private DateTime TokenExpiry = DateTime.MinValue;

		internal static long ExpirySeconds = 86400;
		internal static string DefaultScope = "internal";
		internal static string DefaultGrantType = "password";
		internal static string OrdersEndpointPath = "orders/";
		internal static string AccountsEndpointPath = "accounts/";
		internal static string TokenEndpointPath = "oauth2/token/";
		internal static string ApiEndpoint = "https://api.robinhood.com/";
		internal static string InstrumentsEndpointPath = "instruments/?symbol={0}";
		internal static string ClientId = "c82SH0WZOsabOXGP2sxqcj34FxkvfnWRZBKlBjFS";
		internal static string QuotesEndpointPath = "marketdata/quotes/?bounds=trading&instruments={0}";

		public RobinhoodClient(string userName,
			string password,
			string deviceToken)
		{
			client = new HttpClient();
			this.userName = userName;
			this.password = password;
			this.deviceToken = deviceToken;
		}

		public Account GetAccount()
		{
			Account defaultAccount = null;
			using (var httpRequest = new HttpRequestMessage(HttpMethod.Get, ApiEndpoint + AccountsEndpointPath))
			{
				AddCustomHeaders(httpRequest);
				AddAuthorizationHeader(httpRequest, GetAccessToken());

				using (var response = client.SendAsync(httpRequest).Result)
				{
					response.EnsureSuccessStatusCode();
					AccountsResponse accountsResponse = new DataContractJsonSerializer(typeof(AccountsResponse)).ReadObject(response.Content.ReadAsStreamAsync().Result) as AccountsResponse;
					if (accountsResponse != null)
					{
						defaultAccount = accountsResponse.Results.FirstOrDefault();
					}
				}
			}

			return defaultAccount;
		}

		public Instrument GetInstrument(string symbol)
		{
			Instrument defaultInstrument = null;
			using (var httpRequest = new HttpRequestMessage(HttpMethod.Get, ApiEndpoint + string.Format(InstrumentsEndpointPath, symbol)))
			{
				AddCustomHeaders(httpRequest);
				AddAuthorizationHeader(httpRequest, GetAccessToken());

				using (var response = client.SendAsync(httpRequest).Result)
				{
					response.EnsureSuccessStatusCode();
					InstrumentsResponse accountsResponse = new DataContractJsonSerializer(typeof(InstrumentsResponse)).ReadObject(response.Content.ReadAsStreamAsync().Result) as InstrumentsResponse;
					if (accountsResponse != null)
					{
						defaultInstrument = accountsResponse.Results.FirstOrDefault();
					}
				}
			}

			return defaultInstrument;
		}

		public Quote GetQuote(string instrumentUrl)
		{
			Quote defaultQuote = null;
			using (var httpRequest = new HttpRequestMessage(HttpMethod.Get, ApiEndpoint + string.Format(QuotesEndpointPath, instrumentUrl)))
			{
				AddCustomHeaders(httpRequest);
				AddAuthorizationHeader(httpRequest, GetAccessToken());

				using (var response = client.SendAsync(httpRequest).Result)
				{
					response.EnsureSuccessStatusCode();
					QuotesResponse quotessResponse = new DataContractJsonSerializer(typeof(QuotesResponse)).ReadObject(response.Content.ReadAsStreamAsync().Result) as QuotesResponse;
					if (quotessResponse != null)
					{
						defaultQuote = quotessResponse.Results.FirstOrDefault();
					}
				}
			}

			return defaultQuote;
		}

		public OrderResponse SendOrder(OrderRequest orderRequest)
		{
			OrderResponse orderResponse = null;
			using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, ApiEndpoint + OrdersEndpointPath))
			{
				var ms = new MemoryStream();
				new DataContractJsonSerializer(typeof(OrderRequest)).WriteObject(ms, orderRequest);
				ms.Seek(0, SeekOrigin.Begin);
				HttpContent httpContent = new StreamContent(ms);
				httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

				AddCustomHeaders(httpRequest);
				AddAuthorizationHeader(httpRequest, GetAccessToken());

				httpRequest.Content = httpContent;

				using (var response = client.SendAsync(httpRequest).Result)
				{
					response.EnsureSuccessStatusCode();
					orderResponse = new DataContractJsonSerializer(typeof(OrderResponse)).ReadObject(response.Content.ReadAsStreamAsync().Result) as OrderResponse;
				}
			}

			return orderResponse;
		}

		private string GetAccessToken()
		{
			if (this.TokenExpiry > DateTime.UtcNow)
			{
				return this.AccessToken;
			}

			LoginResponse loginResponse = null;
			LoginRequest loginRequest = new LoginRequest()
			{
				UserName = this.userName,
				Password = this.password,
				DeviceToken = this.deviceToken,
				ClientId = ClientId,
				GrantType = DefaultGrantType,
				Scope = DefaultScope,
				SecondsToExpiry = ExpirySeconds,
			};

			var ms = new MemoryStream();
			new DataContractJsonSerializer(typeof(LoginRequest)).WriteObject(ms, loginRequest);
			ms.Seek(0, SeekOrigin.Begin);
			HttpContent httpContent = new StreamContent(ms);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, ApiEndpoint + TokenEndpointPath))
			{
				AddCustomHeaders(httpRequest);
				httpRequest.Content = httpContent;
				using (var response = client.SendAsync(httpRequest).Result)
				{
					response.EnsureSuccessStatusCode();
					loginResponse = new DataContractJsonSerializer(typeof(LoginResponse)).ReadObject(response.Content.ReadAsStreamAsync().Result) as LoginResponse;
					if (loginResponse != null)
					{
						this.AccessToken = loginResponse.AccessToken;
						this.TokenExpiry = DateTime.UtcNow.AddSeconds(loginResponse.Expiry);
					}
				}
			}

			return this.AccessToken;
		}

		private void AddCustomHeaders(HttpRequestMessage httpRequest)
		{
			httpRequest.Headers.Add("X-Robinhood-API-Version", "1.315.0");
			httpRequest.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36");
			httpRequest.Headers.Add("Origin", "https://robinhood.com");
			httpRequest.Headers.Add("Sec-Fetch-Site", "same-site");
			httpRequest.Headers.Add("Sec-Fetch-Mode", "cors");
			httpRequest.Headers.Add("Sec-Fetch-Dest", "empty");
			httpRequest.Headers.Add("Referer", "https://robinhood.com/");
			httpRequest.Headers.Add("Accept-Language", "en-US,en;q=0.9,te;q=0.8");
		}

		private void AddAuthorizationHeader(HttpRequestMessage httpRequest, string accessToken)
		{
			httpRequest.Headers.Add("Authorization", "Bearer " + accessToken);
		}
	}
}
