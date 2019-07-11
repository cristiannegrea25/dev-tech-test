using AutoFixture;
using AutoMapper;
using AutoMapper.Configuration;
using CarAPI.Web.Mapping;
using CarAPI.Web.Models.Domain;
using CarAPI.Web.Models.Gateway;
using NUnit.Framework;

namespace CarAPI.Web.Tests.Mapping
{
	[TestFixture]
	public class CarProfileMappingTests
	{
		private Fixture _referenceFixture;

		[SetUp]
		public void Setup()
		{
			Mapper.Reset();
			var config = new MapperConfigurationExpression();
			config.AddProfile(new CarProfile());

			Mapper.Initialize(config);

			_referenceFixture = new Fixture();
		}

		[Test]
		public void CarViewModel_To_CarGatewayModel()
		{
			// Arrange
			CarViewModel viewModel = _referenceFixture.Create<CarViewModel>();

			// Act
			Car gatewayModel = Mapper.Map<Car>(viewModel);

			// Assert
			Assert.Multiple(() => {
				Assert.AreEqual(viewModel.Id, gatewayModel.Id);
				Assert.AreEqual(viewModel.Make.Name, gatewayModel.Make);
				Assert.AreEqual(viewModel.Make.Model, gatewayModel.Model);
				Assert.AreEqual(viewModel.Colour, gatewayModel.Colour);
				Assert.AreEqual(viewModel.Year, gatewayModel.Year);
			});
		}

		[Test]
		public void CarGatewayModel_To_CarViewModel()
		{
			// Arrange
			Car viewModel = _referenceFixture.Create<Car>();

			// Act
			CarViewModel gatewayModel = Mapper.Map<CarViewModel>(viewModel);

			// Assert
			Assert.Multiple(() => {
				Assert.AreEqual(viewModel.Id, gatewayModel.Id);
				Assert.AreEqual(viewModel.Make, gatewayModel.Make.Name);
				Assert.AreEqual(viewModel.Model, gatewayModel.Make.Model);
				Assert.AreEqual(viewModel.Colour, gatewayModel.Colour);
				Assert.AreEqual(viewModel.Year, gatewayModel.Year);
			});
		}
	}
}
