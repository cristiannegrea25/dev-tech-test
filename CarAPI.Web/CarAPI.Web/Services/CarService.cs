using AutoMapper;
using CarAPI.Web.Models.Domain;
using CarAPI.Web.Models.Gateway;
using CarAPI.Web.Repositories;
using System.Collections.Generic;

namespace CarAPI.Web.Services
{
	public class CarService : ICarService
	{
        private readonly ICarRepository _carRepository;
		private readonly IMapper _mapper;

		public CarService(ICarRepository carRepository, IMapper mapper)
		{
			_carRepository = carRepository;
			_mapper = mapper;
		}

		public IEnumerable<CarViewModel> GetAllCars()
		{
			var gatewayCars = _carRepository.GetCars();
			return _mapper.Map<IEnumerable<CarViewModel>>(gatewayCars);
		}

		public CarViewModel GetCar(int id)
		{
			var gatewayCar = _carRepository.GetCar(id);
			return _mapper.Map<CarViewModel>(gatewayCar);
		}

		public void InsertCar(CarViewModel car)
		{
			Car gatewayCar = _mapper.Map<Car>(car);

			_carRepository.InsertCar(gatewayCar);
			_carRepository.Save();
		}

		public void UpdateCar(CarViewModel car)
		{
			Car gatewayCar = _mapper.Map<Car>(car);

			_carRepository.UpdateCar(gatewayCar);
			_carRepository.Save();
		}

		public void DeleteCar(int carId)
		{
			var car = _carRepository.GetCar(carId);

			_carRepository.DeleteCar(car);
			_carRepository.Save();
		}
	}
}
