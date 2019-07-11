using CarAPI.Web.Repositories;

namespace CarAPI.Web.Services
{
	public class CarService : ICarService
	{
        private readonly ICarRepository _carRepository;

		public CarService(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}
	}
}
