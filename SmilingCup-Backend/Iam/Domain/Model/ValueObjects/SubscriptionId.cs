namespace SmilingCup_Backend.Iam.Domain.Model.ValueObjects;

public record SubscriptionId(int Id)
{
    public SubscriptionId() : this(0) { }
}