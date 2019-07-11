using AutoMapper;
using CarAPI.Web.Infrastructure.ExceptionHandling;
using CarAPI.Web.Models;
using CarAPI.Web.Registries;
using CarAPI.Web.Repositories.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using StructureMap;
using System;

namespace CarAPI.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddAutoMapper(typeof(Startup));
			services.AddHttpClient();

			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.Configure<ServerConfig>(Configuration.GetSection(nameof(ServerConfig)));

			services.AddMvc(options =>
				{
					var serviceProvider = services.BuildServiceProvider();
					var logger = serviceProvider.GetService<ILogger<UnhandledExceptionFilter>>();
					options.Filters.Add(new UnhandledExceptionFilter(logger));
				}).SetCompatibilityVersion(CompatibilityVersion.Version_2_2); ;

			var container = ConfigureIOC(services);
			return container;
		}

		private IServiceProvider ConfigureIOC(IServiceCollection services)
		{
			var container = new Container(new CarAPIRegistry(Configuration));
			container.Populate(services);

			return container.GetInstance<IServiceProvider>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			env.ConfigureNLog("nlog.config");

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
