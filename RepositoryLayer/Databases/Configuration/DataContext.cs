using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases.Entities;

namespace RepositoryLayer.Databases.Configuration;

public class DataContext : IdentityDbContext<AppUser>
{

    public DbSet<RefreshToken> RefreshTokens { get; set; }


    public DataContext()
    {
    }
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

}
