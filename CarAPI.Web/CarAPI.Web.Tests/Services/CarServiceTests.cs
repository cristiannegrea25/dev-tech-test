using AutoMapper;
using CarAPI.Web.Models.Domain;
using CarAPI.Web.Models.Gateway;
using CarAPI.Web.Repositories;
using CarAPI.Web.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarAPI.Web.Tests.Services
{
	[TestFixture]
	public class CarServiceTests
	{
		private Mock<ICarRepository> _carRepository;
		private Mock<IMapper> _mapper;
		private CarService _classUnderTest;

		[SetUp]
		public void Setup()
		{
			_mapper = new Mock<IMapper>();
			_carRepository = new Mock<ICarRepository>();

			_mapper.Setup(x => x.Map<CarViewModel>(It.IsAny<Car>()))
				   .Returns(GetMockViewModelCars().First());

			_mapper.Setup(x => x.Map<IEnumerable<CarViewModel>>(It.IsAny<IEnumerable<Car>>()))
				   .Returns(GetMockViewModelCars);

			_carRepository.Setup(x => x.GetCars())
						  .Returns(GetMockCarsData);

			_carRepository.Setup(x => x.GetCar(It.IsAny<int>()))
						  .Returns(GetMockCarsData().First());

			_classUnderTest = new CarService(_carRepository.Object, _mapper.Object);
		}

		[Test]
		public void Should_Retrieve_List_Of_Cars()
		{
			var cars = _classUnderTest.GetAllCars();

			Assert.True(cars.Count().Equals(3));
		}

		[Test]
		public void Should_Retrieve_Single_Car_Based_On_Id()
		{
			var carId = 1;
			var car = _classUnderTest.GetCar(carId);

			Assert.NotNull(car);
		}

		private IEnumerable<Car> GetMockCarsData()
		{
			var listOfCars = new List<Car> {
				new Car {
					Id = 1,
					Make = "test Make",
					Model = "test Model",
					Colour = "test Colour",
					Year = DateTime.Now.Year
				},
				new Car {
					Id = 2,
					Make = "test Make 2",
					Model = "test Model 2",
					Colour = "test Colour 2",
					Year = DateTime.Now.Year
				},
				new Car {
					Id = 3,
					Make = "test Make 3",
					Model = "test Model 3",
					Colour = "test Colour 3",
					Year = DateTime.Now.Year
				}
			};

			return listOfCars;
		}

		private IEnumerable<CarViewModel> GetMockViewModelCars()
		{
			var listOfCars = new List<CarViewModel> {
				new CarViewModel {
					Id = 1,
					Make = new CarMake { Model = "test Make" },
					Colour = "test Colour",
					Year = DateTime.Now.Year
				},
				new CarViewModel {
					Id = 2,
					Make = new CarMake { Model = "test Make 2" },
					Colour = "test Colour 2",
					Year = DateTime.Now.Year
				},
				new CarViewModel {
					Id = 3,
					Make = new CarMake { Model = "test Make 3" },
					Colour = "test Colour 3",
					Year = DateTime.Now.Year
				}
			};

			return listOfCars;
		}
	}
}
