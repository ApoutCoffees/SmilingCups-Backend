using Microsoft.EntityFrameworkCore;
using SmilingCup_Backend.Iam.Domain.Model.Aggregates;
using SmilingCup_Backend.Iam.Domain.Model.ValueObjects;

namespace SmilingCup_Backend.Iam.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyIamConfiguration(this ModelBuilder builder)
    {
        
        builder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            
            entity.OwnsOne(u => u.FullName, fn =>
            {
                fn.WithOwner().HasForeignKey("Id");
                fn.Property(p => p.FirstName).HasColumnName("first_name");
                fn.Property(p => p.LastName).HasColumnName("last_name");
            });

            entity.OwnsOne(u => u.Email, e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(p => p.Address)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);
                
                e.HasIndex(p => p.Address)
                    .IsUnique();
            });

            
            
            entity.Property(u => u.Password)
                .HasConversion(p => p.Value, dbVal => new Password(dbVal))
                .HasColumnName("password") 
                .IsRequired()
                .HasMaxLength(255); 
            
            entity.Property(u => u.Address)
                .HasConversion(a => a.Value, dbVal => new Address(dbVal))
                .HasColumnName("address")
                .HasMaxLength(150);
            
            entity.Property(u => u.SubscriptionId)
                .HasConversion(s => s.Id, dbVal => new SubscriptionId(dbVal))
                .HasColumnName("subscription_id");
            
            entity.Property(u => u.Phone).IsRequired();
            entity.Property(u => u.City).HasMaxLength(50);
            entity.Property(u => u.Country).HasMaxLength(50);
            entity.Property(u => u.IsVerified).IsRequired();
            entity.Property(u => u.Type)
                .HasConversion<string>()
                .HasMaxLength(20);
        });
    }
}
