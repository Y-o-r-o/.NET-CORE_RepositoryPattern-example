using RepositoryLayer.Models;

namespace UnitTests.BusinessLayerTests.ArrangeBusinessLayerUnitTests;

public static class ArrangeLocation
{
    public static Location Location()
    {
        return new() { Lat = 0, Lng = 0 };
    }
}