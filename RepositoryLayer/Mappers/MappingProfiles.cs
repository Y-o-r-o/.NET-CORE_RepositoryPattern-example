using AutoMapper;
using RepositoryLayer.Models;

namespace RepositoryLayer.Mappers;

public static class MappingProfiles
{
    public static WeatherForecast Map(ServiceClientLayer.Models.WeatherForecast from)
    {
        return new WeatherForecast
        {
            Coord = new Coord
            {
                Lon = from.Coord.Lon,
                Lat = from.Coord.Lat
            },
            Weather = from.Weather.ConvertAll(fromWeather => new Weather
            {
                Id = fromWeather.Id,
                Main = fromWeather.Main,
                Description = fromWeather.Description,
                Icon = fromWeather.Icon
            }),
            Base = from.Base,
            Main = new MainForecast
            {
                Temp = from.Main.Temp,
                FeelsLike = from.Main.FeelsLike,
                TempMin = from.Main.TempMin,
                TempMax = from.Main.TempMax,
                Pressure = from.Main.Pressure,
                Humidity = from.Main.Humidity
            },
            Visibility = from.Visibility,
            Wind = new Wind
            {
                Speed = from.Wind.Speed,
                Deg = from.Wind.Deg
            },
            Clouds = new Clouds
            {
                All = from.Clouds.All
            },
            Dt = from.Dt,
            Sys = new Sys
            {
                Type = from.Sys.Type,
                Id = from.Sys.Id,
                Country = from.Sys.Country,
                Sunrise = from.Sys.Sunrise,
                Sunset = from.Sys.Sunset
            },
            Timezone = from.Timezone,
            Id = from.Id,
            Name = from.Name,
            Cod = from.Cod
        };
    }
}