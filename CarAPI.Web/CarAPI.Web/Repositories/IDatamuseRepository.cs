using CarAPI.Web.Models.Gateway;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarAPI.Web.Repositories
{
	public interface IDatamuseRepository
	{
		Task<List<DatamuseResponse>> GetDatamuseWords(string uriSuffix);
	}
}
