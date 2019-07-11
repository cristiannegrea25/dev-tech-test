using AutoMapper;
using CarAPI.Web.Models.Domain;
using CarAPI.Web.Models.Gateway;

namespace CarAPI.Web.Mapping
{
	public class CarProfile : Profile
	{
		public CarProfile()
		{
			CreateMap<CarViewModel, CarGatewayModel>();
			CreateMap<CarGatewayModel, CarViewModel>();
		}
	}
}
