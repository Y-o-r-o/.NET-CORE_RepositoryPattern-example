using BusinessLayer.DTOs;
using RepositoryLayer.Databases.Entities;
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

    public static Location Map(Geocode from)
    {
        return new Location()
        {
            Lat = from.Results[0].Geometry.Location.Lat,
            Lng = from.Results[0].Geometry.Location.Lng
        };
    }

    public static UserDTO Map(AppUser from)
    {
        return new UserDTO()
        {
            DisplayName = from.DisplayName,
            Bio = from.Bio
        };
    }
}