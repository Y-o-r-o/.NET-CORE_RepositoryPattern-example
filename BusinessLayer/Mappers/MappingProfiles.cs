using BusinessLayer.DTOs;
using RepositoryLayer.Models;

namespace BusinessLayer.Mappers;

public static class MappingProfiles
{
    public static MainForecastDTO Map(MainForecast from)
    {
        return new MainForecastDTO()
        {
            TemperatureCelsius = Helpers.Converter.KelvinToCelsius(from.Temp)
        };
    }
}