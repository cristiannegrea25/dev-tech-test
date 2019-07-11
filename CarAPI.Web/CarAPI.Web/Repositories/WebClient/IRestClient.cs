using System.Threading.Tasks;

namespace CarAPI.Web.Repositories.WebClient
{
	public interface IRestClient
    {
		Task<T> GetAsync<T>(string uri);
	}
}
