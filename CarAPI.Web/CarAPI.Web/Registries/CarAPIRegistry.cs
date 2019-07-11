using AutoMapper;
using CarAPI.Web.Repositories.Context;
using Microsoft.EntityFrameworkCore;
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

			For<CarAPIContext>().Use(new CarAPIContext(new DbContextOptions<CarAPIContext>()));
		}
	}
}
