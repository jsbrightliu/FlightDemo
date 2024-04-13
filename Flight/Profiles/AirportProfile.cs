using AutoMapper;
using Flight.Models.Entities;
using Flight.ViewModels;

namespace Flight.Profiles
{
    public class AirportProfile : Profile
    {
        public AirportProfile()
        {
            CreateMap<Airport, AirportDto>()
                .ForMember(d => d.Id, x => x.MapFrom(s => s.Id))
                .ForMember(d => d.Name, x => x.MapFrom(s => s.Name));
        }
    }
}
