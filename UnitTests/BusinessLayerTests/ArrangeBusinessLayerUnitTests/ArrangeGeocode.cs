using RepositoryLayer.Models;

namespace UnitTests.BusinessLayerTests.ArrangeBusinessLayerUnitTests;
public static class ArrangeGeocode
{
    public static Geocode Results()
    {
        return new() { Results = ArrangeResults.Results() };
    }
}
