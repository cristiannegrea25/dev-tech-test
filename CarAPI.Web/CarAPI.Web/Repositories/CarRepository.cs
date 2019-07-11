using CarAPI.Web.Models.Gateway;
using CarAPI.Web.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarAPI.Web.Repositories
{
	public class CarRepository : ICarRepository
	{
		private CarAPIContext _context;

		public CarRepository(CarAPIContext context)
		{
			_context = context;
			_context.Database.EnsureCreated();
		}

		public Car GetCar(int carId)
		{
			return _context.Cars.Find(carId);
		}

		public IEnumerable<Car> GetCars()
		{
			var cars = _context.Cars.ToList();

			return cars;
		}

		public void InsertCar(Car car)
		{
			_context.Cars.Add(car);
		}

		public void UpdateCar(Car car)
		{
			_context.Entry(car).State = EntityState.Detached;
		}

		public void DeleteCar(Car car)
		{
			_context.Cars.Remove(car);
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
