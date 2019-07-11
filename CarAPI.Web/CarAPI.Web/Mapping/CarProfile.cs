using AutoMapper;
using CarAPI.Web.Models.Domain;
using CarAPI.Web.Models.Gateway;

namespace CarAPI.Web.Mapping
{
	public class CarProfile : Profile
	{
		public CarProfile()
		{
			CreateMap<CarViewModel, Car>()
				.ForMember(d => d.Make, m => m.MapFrom(s => s.Make.Name))
				.ForMember(d => d.Model, m => m.MapFrom(s => s.Make.Model));

			CreateMap<Car, CarViewModel>()
				.ForPath(d => d.Make.Name, m => m.MapFrom(s => s.Make))
				.ForPath(d => d.Make.Model, m => m.MapFrom(s => s.Model));
		}
	}
}
