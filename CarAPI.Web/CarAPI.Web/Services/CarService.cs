using AutoMapper;
using CarAPI.Web.Models.Domain;
using CarAPI.Web.Models.Gateway;
using CarAPI.Web.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAPI.Web.Services
{
	public class CarService : ICarService
	{
		private readonly ICarRepository _carRepository;
		private readonly IDatamuseRepository _datamuseRepository;
		private readonly IMapper _mapper;

		public CarService(ICarRepository carRepository, IDatamuseRepository datamuseRepository, IMapper mapper)
		{
			_carRepository = carRepository;
			_datamuseRepository = datamuseRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<CarViewModel>> GetAllCars()
		{
			var gatewayCars = _carRepository.GetCars();
			var viewModelCars = _mapper.Map<IEnumerable<CarViewModel>>(gatewayCars);

			foreach (var car in viewModelCars)
			{
				var datamuseResult = await _datamuseRepository.GetDatamuseWords(string.Join("+", car.Make.Model?.Split(' ')));

				car.SimilarWords = string.Join(", ", datamuseResult?.OrderByDescending(x => x.Score).Select(x => x.Word) ?? new List<string>());
			}

			return viewModelCars;
		}

		public async Task<CarViewModel> GetCar(int id)
		{
			var gatewayCar = _carRepository.GetCar(id);
			var viewModelCar = _mapper.Map<CarViewModel>(gatewayCar);

			var datamuseResult = await _datamuseRepository.GetDatamuseWords(string.Join("+", gatewayCar.Model.Split(' ')));

			viewModelCar.SimilarWords = string.Join(", ", datamuseResult?.OrderByDescending(x => x.Score).Select(x => x.Word) ?? new List<string>());

			return viewModelCar;
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
