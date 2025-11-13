using Microsoft.EntityFrameworkCore;
using SmilingCup_Backend.profiles.domain.model.aggregates;

namespace SmilingCup_Backend.profiles.infrastructure.persistence.efc.configuration.extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyProfilesConfiguration(this ModelBuilder builder)
    {
        //Favorite Aggregate

        builder.Entity<Favorite>().HasKey(f => f.id);
        builder.Entity<Favorite>().Property(f => f.id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<Favorite>().OwnsOne(f => f.userId, u =>
        {
            u.WithOwner().HasForeignKey("id");
            u.Property(p => p.userId)
                .HasColumnName("UserId")
                .IsRequired();
        });
        
        builder.Entity<Favorite>().OwnsOne(f => f.coffeeId, c =>
        {
            c.WithOwner().HasForeignKey("id");
            c.Property(p => p.coffeeId)
                .HasColumnName("CoffeeId")
                .IsRequired();
        });
        
        //MonthlySale Aggregate
        
        builder.Entity<MonthlySale>().HasKey(ms => ms.id);
        builder.Entity<MonthlySale>().Property(ms => ms.id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<MonthlySale>().OwnsOne(ms => ms.producerStatId, ps =>
        {
            ps.WithOwner().HasForeignKey("id");
            ps.Property(p => p.producerStatId)
                .HasColumnName("ProducerStatId")
                .IsRequired();
        });

        builder.Entity<MonthlySale>().Property(ms => ms.month)
            .HasConversion<string>()
            .HasColumnName("Month")
            .IsRequired();
        
        builder.Entity<MonthlySale>().Property(ms => ms.sales)
            .HasColumnName("Sales")
            .IsRequired();
        
        
        //Producer Stat
        
        builder.Entity<ProducerStat>().HasKey(ps => ps.id);
        builder.Entity<ProducerStat>().Property(ps => ps.id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<ProducerStat>().OwnsOne(ps => ps.userId, u =>
        {
            u.WithOwner().HasForeignKey("id");
            u.Property(p => p.userId)
                .HasColumnName("UserId")
                .IsRequired();
        });
        
        builder.Entity<ProducerStat>().Property(ps => ps.unitsSold)
            .HasColumnName("UnitsSold")
            .IsRequired();

        builder.Entity<ProducerStat>().OwnsOne(ps => ps.topCoffeeId, tc =>
        {
            tc.WithOwner().HasForeignKey("id");
            tc.Property(p => p.coffeeId)
                .HasColumnName("TopCoffeeId")
                .IsRequired();
        });
    }
}