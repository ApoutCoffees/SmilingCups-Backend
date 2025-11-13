using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using SmilingCup_Backend.Shared.infrastructure.persistence.efc.configuration.extensions;
using SmilingCup_Backend.Iam.Domain.Model.Aggregates; 
using SmilingCup_Backend.Iam.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace SmilingCup_Backend.Shared.infrastructure.persistence.efc.configuration;


public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyIamConfiguration();


        builder.UseSnakeCaseNamingConvention();
        
    }
}