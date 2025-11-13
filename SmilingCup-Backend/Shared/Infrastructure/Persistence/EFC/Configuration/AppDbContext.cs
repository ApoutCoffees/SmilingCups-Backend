using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using SmilingCup_Backend.Shared.infrastructure.persistence.efc.configuration.extensions;

namespace SmilingCup_Backend.Shared.infrastructure.persistence.efc.configuration;


public class AppDbContext(DbContextOptions options) : DbContext(options)
{

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.UseSnakeCaseNamingConvention();
    }
}