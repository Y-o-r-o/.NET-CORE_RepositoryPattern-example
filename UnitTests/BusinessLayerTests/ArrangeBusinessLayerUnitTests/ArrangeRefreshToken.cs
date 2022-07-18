using RepositoryLayer.Databases.Entities;

namespace UnitTests.BusinessLayerTests.ArrangeBusinessLayerUnitTests;

public static class ArrangeRefreshToken
{
    public static RefreshToken refreshToken() 
    {
        return new RefreshToken { UserId = "123" };
    }
}
