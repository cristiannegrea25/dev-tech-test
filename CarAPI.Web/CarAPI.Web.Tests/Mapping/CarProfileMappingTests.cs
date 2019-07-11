using AutoFixture;
using AutoMapper;
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
			Mapper.Initialize(x => x.AddProfile(new CarProfile()));

			_referenceFixture = new Fixture();
		}

		[Test]
		public void CarViewModel_To_CarGatewayModel()
		{
			CarViewModel viewModel = _referenceFixture.Create<CarViewModel>();

			Car gatewayModel = Mapper.Map<Car>(viewModel);

			Assert.Multiple(() => {
				Assert.AreEqual(viewModel.Id, gatewayModel.Id);
				Assert.AreEqual(viewModel.Make, gatewayModel.Make);
				Assert.AreEqual(viewModel.Model, gatewayModel.Model);
				Assert.AreEqual(viewModel.Colour, gatewayModel.Colour);
				Assert.AreEqual(viewModel.Year, gatewayModel.Year);
			});
		}

		[Test]
		public void CarGatewayModel_To_CarViewModel()
		{
			Car viewModel = _referenceFixture.Create<Car>();

			CarViewModel gatewayModel = Mapper.Map<CarViewModel>(viewModel);

			Assert.Multiple(() => {
				Assert.AreEqual(viewModel.Id, gatewayModel.Id);
				Assert.AreEqual(viewModel.Make, gatewayModel.Make);
				Assert.AreEqual(viewModel.Model, gatewayModel.Model);
				Assert.AreEqual(viewModel.Colour, gatewayModel.Colour);
				Assert.AreEqual(viewModel.Year, gatewayModel.Year);
			});
		}
	}
}
