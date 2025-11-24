namespace SmilingCup_Backend.Payment.Domain.Model.ValueObjects;

public record SubscriptionId(int subscriptionId)
{
    public SubscriptionId(): this(0){}
}