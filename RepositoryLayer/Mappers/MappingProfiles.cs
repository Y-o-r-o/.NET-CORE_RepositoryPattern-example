using AutoMapper;
using RepositoryLayer.Models;

namespace RepositoryLayer.Mappers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
        {
            CreateMap<MainForecast, ServiceClientLayer.Models.MainForecast>();
            
        }
}
