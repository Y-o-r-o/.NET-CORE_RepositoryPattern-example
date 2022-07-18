using RepositoryLayer.Models;


namespace UnitTests.BusinessLayerTests.ArrangeBusinessLayerUnitTests;
public static class ArrangeGeometry
{
    public static Geometry Geometry()
    {
        return new() { Location = ArrangeLocation.Location() };
    }
}
