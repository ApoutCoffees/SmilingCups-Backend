using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SmilingCup_Backend.product.domain.model.aggregates;

namespace SmilingCup_Backend.product.infrastructure.persistence.efc.configuration.extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyProductConfiguration(this ModelBuilder builder)
    {
        //MysteryBox Aggregate

        builder.Entity<MysteryBox>().HasKey(mb => mb.id);
        builder.Entity<MysteryBox>().Property(mb => mb.id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<MysteryBox>().OwnsOne(mb => mb.totalAmount, ta =>
        {
            ta.WithOwner().HasForeignKey("id");
            ta.Property(p => p.Amount)
                .HasColumnName("TotalAmount")
                .IsRequired();
            ta.Property(p => p.Currency)
                .HasColumnName("Currency")
                .IsRequired();
        });
        
        //Coffee Aggregate
        
        builder.Entity<Coffee>().HasKey(c => c.id);
        builder.Entity<Coffee>().Property(coffee => coffee.id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<Coffee>().OwnsOne(c => c.mysteryBoxId, mb =>
        {
            mb.WithOwner().HasForeignKey("id");
            mb.Property(p => p.mysteryBoxId)
                .HasColumnName("MysteryBoxId")
                .IsRequired();
        });

        builder.Entity<Coffee>().OwnsOne(c => c.producerId, p =>
        {
            p.WithOwner().HasForeignKey("id");
            p.Property(pr => pr.userId)
                .HasColumnName("ProducerId")
                .IsRequired();
        });

        builder.Entity<Coffee>().OwnsOne(c => c.name, n =>
        {
            n.WithOwner().HasForeignKey("id");
            n.Property(p => p.name)
                .HasColumnName("Name")
                .IsRequired();
        });

        builder.Entity<Coffee>().OwnsOne(c => c.kind, k =>
        {
            k.WithOwner().HasForeignKey("id");
            k.Property(p => p.kind)
                .HasColumnName("Kind")
                .IsRequired();
        });


        builder.Entity<Coffee>().OwnsOne(c => c.notes, n =>
        {
            n.WithOwner().HasForeignKey("id");
            n.Property(p => p.notes)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null)!
                )
                .HasColumnName("Notes")
                .HasColumnType("nvarchar(max)");
        });

        builder.Entity<Coffee>().OwnsOne(c => c.place, p =>
        {
            p.WithOwner().HasForeignKey("id");
            p.Property(p => p.originPlace)
                .HasColumnName("OriginPlace")
                .IsRequired();
        });

        builder.Entity<Coffee>().OwnsOne(c => c.price, p =>
        {
            p.WithOwner().HasForeignKey("id");
            p.Property(p => p.Amount)
                .HasColumnName("Amount")
                .IsRequired();
            p.Property(p => p.Currency)
                .HasColumnName("Currency")
                .IsRequired();
        });

        builder.Entity<Coffee>().OwnsOne(c => c.toasted, t =>
        {
            t.WithOwner().HasForeignKey("id");
            t.Property(p => p.roastLevel)
                .HasColumnName("RoastLevel")
                .IsRequired();
        });
        
        builder.Entity<Coffee>().Property(c => c.description)
            .HasColumnName("Description")
            .IsRequired();
        
        builder.Entity<Coffee>().Property(c => c.imageUrl)
            .HasColumnName("ImageUrl")
            .IsRequired();
        
        builder.Entity<Coffee>().Property(c => c.originKey)
            .HasColumnName("OriginKey")
            .IsRequired();
        
        builder.Entity<Coffee>().Property(c => c.minSubscription)
            .HasColumnName("MinSubscription")
            .IsRequired();

    }
    
}