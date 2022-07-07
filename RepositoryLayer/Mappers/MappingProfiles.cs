using RepositoryLayer.Models;

namespace RepositoryLayer.Mappers;


public class MappingProfiles
{
    private MappingProfiles() { }
    private static readonly MappingProfiles _instance = new MappingProfiles();
    public static MappingProfiles Instance { get { return _instance; } }

    public static TResult? TryMap<TSource, TResult>(TSource source)
    where TResult : new()
    where TSource : class, new()
    {
        var sourceProp = typeof(TSource).GetProperties();
        var resultMapper = typeof(MappingProfiles).GetMethods().FirstOrDefault(m =>
            m.ReturnType == typeof(TResult) &&
            m.GetParameters()[0].ParameterType == typeof(TSource));
        if (resultMapper is null)
            throw new Exception($"Mapper not found. From: {typeof(TSource)}, to: {typeof(TResult)}");

        TSource[] sources = new TSource[] { source };

        object res = resultMapper.Invoke(MappingProfiles.Instance, sources);

        return (TResult)res;
    }

    public static Geocode Map(ServiceClientLayer.Models.Geocode from)
    {
        return new Geocode
        {
            Results = from.Results.ConvertAll(fromResult => new Result
            {
                AddressComponents = fromResult.AddressComponents.ConvertAll(fromResultAddressComponent => new AddressComponent
                {
                    LongName = fromResultAddressComponent.LongName,
                    ShortName = fromResultAddressComponent.ShortName,
                    Types = fromResultAddressComponent.Types
                }),
                FormattedAddress = fromResult.FormattedAddress,
                Geometry = new Geometry
                {
                    Bounds = new Bounds
                    {
                        Northeast = new Northeast
                        {
                            Lat = fromResult.Geometry.Bounds.Northeast.Lat,
                            Lng = fromResult.Geometry.Bounds.Northeast.Lng
                        },
                        Southwest = new Southwest
                        {
                            Lat = fromResult.Geometry.Bounds.Southwest.Lat,
                            Lng = fromResult.Geometry.Bounds.Southwest.Lng
                        }
                    },
                    Location = new Location
                    {
                        Lat = fromResult.Geometry.Location.Lat,
                        Lng = fromResult.Geometry.Location.Lng
                    },
                    LocationType = fromResult.Geometry.LocationType,
                    Viewport = new Viewport
                    {
                        Northeast = new Northeast
                        {
                            Lat = fromResult.Geometry.Viewport.Northeast.Lat,
                            Lng = fromResult.Geometry.Viewport.Northeast.Lng
                        },
                        Southwest = new Southwest
                        {
                            Lat = fromResult.Geometry.Viewport.Southwest.Lat,
                            Lng = fromResult.Geometry.Viewport.Southwest.Lng
                        }
                    }
                },
                PlaceId = fromResult.PlaceId,
                Types = fromResult.Types
            }),
            Status = from.Status
        };
    }

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