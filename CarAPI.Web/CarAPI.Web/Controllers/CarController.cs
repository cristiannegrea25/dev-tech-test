using Microsoft.AspNetCore.Mvc;
using CarAPI.Web.Infrastructure.Logging;
using System.Collections.Generic;
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
		public IEnumerable<CarViewModel> GetCars()
		{
			_logger.Info("Getting cars...");

			return _carService.GetAllCars();
		}

		[HttpPost]
		public void InsertCar(CarViewModel car)
		{
			_logger.Info("Inserting car record...");

			_carService.InsertCar(car);
		}

		[HttpPut]
		public void UpdateCar(CarViewModel car)
		{
			_logger.Info("Updating car record...");

			_carService.UpdateCar(car);
		}

		[HttpDelete]
		public void DeleteCar(int carId)
		{
			_logger.Info("Deleting car record...");

			_carService.DeleteCar(carId);
		}
	}
}
