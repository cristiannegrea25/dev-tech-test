using CarAPI.Web.Models.Gateway;
using System.Collections.Generic;

namespace CarAPI.Web.Repositories
{
	public interface ICarRepository
	{
		Car GetCar(int id);

		IEnumerable<Car> GetCars();

		void InsertCar(Car car);

		void UpdateCar(Car car);

		void DeleteCar(Car car);

		void Save();
	}
}
