using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CarAPI.Web.Services;
using CarAPI.Web.Models.Domain;
using Microsoft.Extensions.Logging;

namespace CarAPI.Web.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
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
		[Route("getcars")]
		public IEnumerable<CarViewModel> GetCars()
		{
			_logger.LogInformation("Getting cars...");

			return _carService.GetAllCars();
		}

		[HttpGet]
		[Route("getcar/{carId}")]
		public CarViewModel GetCars(int carId)
		{
			_logger.LogInformation($"Getting car with Id {carId}...");

			return _carService.GetCar(carId);
		}

		[HttpPost]
		[Route("insertcar")]
		public void InsertCar([FromBody] CarViewModel car)
		{
			_logger.LogInformation("Inserting car record...");

			_carService.InsertCar(car);
		}

		[HttpPut]
		[Route("updatecar")]
		public void UpdateCar([FromBody] CarViewModel car)
		{
			_logger.LogInformation("Updating car record...");

			_carService.UpdateCar(car);
		}

		[HttpDelete]
		[Route("deletecar/{carId}")]
		public void DeleteCar(int carId)
		{
			_logger.LogInformation("Deleting car record...");

			_carService.DeleteCar(carId);
		}
	}
}
