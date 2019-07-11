using CarAPI.Web.Models.Domain;
using System.Collections.Generic;

namespace CarAPI.Web.Services
{
	public interface ICarService
	{
		IEnumerable<CarViewModel> GetAllCars();

		CarViewModel GetCar(int id);

		void InsertCar(CarViewModel car);

		void UpdateCar(CarViewModel car);

		void DeleteCar(int Id);
	}
}
