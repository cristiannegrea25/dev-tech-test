using CarAPI.Web.Models;
using CarAPI.Web.Models.Gateway;
using CarAPI.Web.Repositories.WebClient;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarAPI.Web.Repositories
{
	public class DatamuseRepository: IDatamuseRepository
	{
        private readonly ServerConfig _serverConfig;
		private readonly IRestClient _webClient;
		private const string SoundsLikeTag = "sl";

		public DatamuseRepository(IRestClient webClient, IOptions<ServerConfig> serverConfig)
		{
			_webClient = webClient;
			_serverConfig = serverConfig.Value;
		}

		public async Task<List<DatamuseResponse>> GetDatamuseWords(string uriSuffix)
		{
			var requestUrl = $"{_serverConfig.ServerUrl}?{SoundsLikeTag}={uriSuffix}";
			var responseModel = await _webClient.GetAsync<List<DatamuseResponse>>(requestUrl);

			return responseModel;
		}
	}
}
