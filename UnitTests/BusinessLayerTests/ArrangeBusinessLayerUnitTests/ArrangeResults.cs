using RepositoryLayer.Models;

namespace UnitTests.BusinessLayerTests.ArrangeBusinessLayerUnitTests;

public static class ArrangeResults
{
    public static List<Result> Results()
    {
        List<Result> results = new();
        results.Add(new() { Geometry = ArrangeGeometry.Geometry() });
        return results;
    }
}