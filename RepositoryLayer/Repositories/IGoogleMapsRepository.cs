using RepositoryLayer.Interfaces;
using RepositoryLayer.Mappers;
using RepositoryLayer.Models;
using ServiceClientLayer.ServiceClients.OpenWeatherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories;
public class GoogleMapsRepository : IGoogleMapsRepository
{

    private IGoogleMapsServiceClient _googleMapsServiceClient;

    public GoogleMapsRepository(IGoogleMapsServiceClient googleMapsServiceClient)
    {
        _googleMapsServiceClient = googleMapsServiceClient;
    }

    public async Task<Location> GetCordinates(string city)
    {

        //atskiras repo
        var googleMapsResponse = await _googleMapsServiceClient.GetCordinates(city);

        Location location = null;

        if (googleMapsResponse.IsSuccess)
        {
            location = MappingProfiles.Map(googleMapsResponse.Value).Results[0].Geometry.Location;
        }

        return location;
    }

}