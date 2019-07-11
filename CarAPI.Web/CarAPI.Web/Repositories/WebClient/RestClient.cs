using CarAPI.Web.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarAPI.Web.Repositories.WebClient
{
	public class RestClient : IRestClient
    {
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILogger<RestClient> _logger;

		public RestClient(IHttpClientFactory clientFactory, IOptions<ServerConfig> serverConfig, ILogger<RestClient> logger)
        {
			_httpClientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
			_logger = logger;
        }

		public async Task<T> GetAsync<T>(string uri)
		{
			using (var client = _httpClientFactory.CreateClient())
			{
				HttpResponseMessage response = null;
				try
				{
					response = await client.GetAsync(uri);

					response.EnsureSuccessStatusCode();

					var stringResponse = await response.Content.ReadAsStringAsync();

					return JsonConvert.DeserializeObject<T>(stringResponse);
				}
				catch (HttpRequestException e)
				{
					string message = $"Get request failed, due to status code: {response?.StatusCode ?? System.Net.HttpStatusCode.SeeOther}, Error: {e.GetBaseException().Message}";
					_logger.LogError(e, message);
					throw;
				}
				catch (TaskCanceledException e)
				{
					string message = $"Get request failed, due to TaskCanceledException";
					_logger.LogError(e, message);
					throw;
				}
				catch (TimeoutException e)
				{
					string message = $"Get request failed, due to TimeoutException";
					_logger.LogError(e, message);
					throw;
				}
			}
		}
	}
}
