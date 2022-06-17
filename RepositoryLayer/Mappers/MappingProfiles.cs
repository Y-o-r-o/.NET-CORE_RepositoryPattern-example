using AutoMapper;
using RepositoryLayer.Models;

namespace RepositoryLayer.Mappers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<WeatherForecast, ServiceClientLayer.Models.WeatherForecast>()
            .ForMember(d => d.MainForecast, o => o.MapFrom(s => s.MainForecast));
        CreateMap<ServiceClientLayer.Models.WeatherForecast, WeatherForecast>()
            .ForMember(d => d.MainForecast, o => o.MapFrom(s => s.MainForecast));
    }
}
