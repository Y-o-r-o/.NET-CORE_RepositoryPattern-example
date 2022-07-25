using RepositoryLayer.Databases.Entities;

namespace UnitTests.BusinessLayerTests.ArrangeBusinessLayerUnitTests;

public static class ArrangeUsers
{
    public static List<AppUser> Users()
    {
        return new List<AppUser>(){
            new AppUser()
            {
                DisplayName = "TomTom"
            },
            new AppUser()
            {
                DisplayName = "DziugDziug"
            },
            new AppUser()
            {
                DisplayName = "LukLuk"
            }
        };
    }

    public static AppUser User()
    {
        return new AppUser()
        {
            DisplayName = "TomTom",
            Id = "123",
            Email = "test@test.test",
            UserName = "TomTom"
        };
    }

    public static AppUser UserWithNullDisplayName()
    {
        return new AppUser()
        {
            DisplayName = null,
            Id = "123",
            Email = "test@test.test",
            UserName = "TomTom"
        };
    }
}