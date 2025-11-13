using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using SmilingCup_Backend.product.infrastructure.persistence.efc.configuration.extensions;
using SmilingCup_Backend.profiles.infrastructure.persistence.efc.configuration.extensions;
using SmilingCup_Backend.Shared.infrastructure.persistence.efc.configuration.extensions;

namespace SmilingCup_Backend.Shared.infrastructure.persistence.efc.configuration;


public class AppDbContext(DbContextOptions options) : DbContext(options)
{

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Profiles Context
        builder.ApplyProfilesConfiguration();
        
        //Product Context
        builder.ApplyProductConfiguration();

        // General Naming Convention for the database objects
        builder.UseSnakeCaseNamingConvention();
    }
}