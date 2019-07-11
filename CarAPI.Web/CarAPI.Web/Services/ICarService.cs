using CarAPI.Web.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarAPI.Web.Services
{
	public interface ICarService
	{
		Task<IEnumerable<CarViewModel>> GetAllCars();

		Task<CarViewModel> GetCar(int id);

		void InsertCar(CarViewModel car);

		void UpdateCar(CarViewModel car);

		void DeleteCar(int Id);
	}
}
