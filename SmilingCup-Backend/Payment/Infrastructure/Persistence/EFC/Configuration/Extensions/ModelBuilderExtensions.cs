using Microsoft.EntityFrameworkCore;
using SmilingCup_Backend.Payment.Domain.Model.Aggregates;

namespace SmilingCup_Backend.Payment.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyProfilesConfiguration(this ModelBuilder builder)
    {
        
        //Subscription Aggregate
        
        builder.Entity<Subscription>().HasKey(s => s.Id);
        builder.Entity<Subscription>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Subscription>().Property(s => s.Status).IsRequired();
        builder.Entity<Subscription>().Property(s => s.Plan).IsRequired();
        
        
        //Order Aggregate

        builder.Entity<Order>().HasKey(o => o.Id);
        builder.Entity<Order>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<Order>().OwnsOne(o => o.UserId, u =>
        {
            u.WithOwner().HasForeignKey("Id");
            u.Property(p => p.userId).IsRequired().HasColumnName("UserId");
        });
        
        builder.Entity<Order>().OwnsOne(o => o.SubscriptionId, s =>
        {
            s.WithOwner().HasForeignKey("Id");
            s.Property(p => p.subscriptionId).IsRequired().HasColumnName("SubscriptionId");
        });
        
        builder.Entity<Order>().Property(o => o.OrderNumber).IsRequired();
        
        builder.Entity<Order>().OwnsOne(o => o.Total, t =>
        {
            t.WithOwner().HasForeignKey("Id");
            t.Property(p => p.Amount).IsRequired().HasColumnName("Amount");
            t.Property(p => p.Currency).IsRequired().HasColumnName("Currency");
        });
        
        builder.Entity<Order>().Property(o => o.Status).IsRequired();
        
        builder.Entity<Order>().Property(o => o.Type).IsRequired();
        
    }
}