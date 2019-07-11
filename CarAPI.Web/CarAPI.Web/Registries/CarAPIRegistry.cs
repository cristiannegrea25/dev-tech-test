using AutoMapper;
using Microsoft.Extensions.Configuration;
using StructureMap;

namespace CarAPI.Web.Registries
{
	public class CarAPIRegistry : Registry
	{
		public CarAPIRegistry(IConfiguration configuration)
		{
			Scan(_ =>
			{
				_.AssemblyContainingType<Startup>();
				_.LookForRegistries();
				_.AddAllTypesOf<Profile>();
				_.WithDefaultConventions();
			});
		}
	}
}
