using Microsoft.AspNetCore.Mvc;
using CarAPI.Web.Infrastructure.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarAPI.Web.Services;
using CarAPI.Web.Models.Domain;

namespace CarAPI.Web.Controllers
{
	[Route("api/[controller]")]
	public class CarController : Controller
	{
		private readonly ICarService _carService;
		private readonly ILogger<CarController> _logger;

		public CarController(ICarService carService, ILogger<CarController> logger)
		{
			_carService = carService;
			_logger = logger;
		}

		[HttpGet]
		public async Task<List<CarViewModel>> GetCars()
		{
			_logger.Info("Getting cars...");

			return new List<CarViewModel>();
		}

		[HttpPost]
		public async void InsertCar()
		{
			_logger.Info("Inserting car record...");
		}

		[HttpPut]
		public async void UpdateCar()
		{
			_logger.Info("Updating car record...");
		}

		[HttpDelete]
		public async void DeleteCar(int id)
		{
			_logger.Info("Deleting car record...");
		}
	}
}
