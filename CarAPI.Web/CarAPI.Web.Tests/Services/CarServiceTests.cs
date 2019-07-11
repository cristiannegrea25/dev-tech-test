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
using System.Threading.Tasks;

namespace CarAPI.Web.Tests.Services
{
	[TestFixture]
	public class CarServiceTests
	{
		private Mock<ICarRepository> _carRepository;
		private Mock<IDatamuseRepository> _datamuseRepository;
		private Mock<IMapper> _mapper;
		private CarService _classUnderTest;

		[SetUp]
		public void Setup()
		{
			_mapper = new Mock<IMapper>();
			_carRepository = new Mock<ICarRepository>();
			_datamuseRepository = new Mock<IDatamuseRepository>();

			_mapper.Setup(x => x.Map<CarViewModel>(It.IsAny<Car>()))
				   .Returns(GetMockViewModelCars().First());

			_mapper.Setup(x => x.Map<IEnumerable<CarViewModel>>(It.IsAny<IEnumerable<Car>>()))
				   .Returns(GetMockViewModelCars);

			_carRepository.Setup(x => x.GetCars())
						  .Returns(GetMockCarsData);

			_datamuseRepository.Setup(x => x.GetDatamuseWords(It.IsAny<string>()))
						  .ReturnsAsync(GetMockDatamuseResponse);

			_carRepository.Setup(x => x.GetCar(It.IsAny<int>()))
						  .Returns(GetMockCarsData().First());

			_classUnderTest = new CarService(_carRepository.Object, _datamuseRepository.Object, _mapper.Object);
		}

		[Test]
		public async Task Should_Retrieve_List_Of_Cars()
		{
			// Arrange
			var expectedValue = 3;
			
			// Act
			var cars = await _classUnderTest.GetAllCars();

			// Arrange
			Assert.True(cars.Count().Equals(expectedValue));
		}

		[Test]
		public async Task Should_Retrieve_Single_Car_Based_On_Id()
		{
			var carId = 1;
			
			// Act
			var car = await _classUnderTest.GetCar(carId);

			Assert.NotNull(car);
		}

		[Test]
		public async Task Should_Retrieve_Datamuse_Responses_For_List_Of_Cars()
		{
			// Arrange
			var expectedValue = "testtttt, testttt, testt";

			// Act
			var cars = await _classUnderTest.GetAllCars();

			// Arrange
			Assert.That(cars.All(x => x.SimilarWords.Equals(expectedValue)));
		}

		[Test]
		public async Task Should_Retrieve_Datamuse_Response_For_Single_Car_Based_On_Id()
		{
			// Arrange
			var carId = 1;
			var expectedValue = "testtttt, testttt, testt";

			// Act
			var car = await _classUnderTest.GetCar(carId);

			// Assert
			Assert.AreEqual(expectedValue, car.SimilarWords);
		}

		private List<DatamuseResponse> GetMockDatamuseResponse()
		{
			var listOfDatamuseResponses = new List<DatamuseResponse> {
				new DatamuseResponse { Word = "testt", Score = 123 },
				new DatamuseResponse { Word = "testttt", Score = 1234 },
				new DatamuseResponse { Word = "testtttt", Score = 12345 }
			};

			return listOfDatamuseResponses;
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
