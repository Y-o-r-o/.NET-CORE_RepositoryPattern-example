using BusinessLayer.DTOs;
using RepositoryLayer.Models;

namespace BusinessLayer.Mappers;

public static class MappingProfiles
{
    public static MainForecastDTO Map(Main from)
    {
        return new MainForecastDTO()
        {
            TemperatureCelsius = from.Temp - 272.15
        };
    }
}