namespace SmilingCup_Backend.Payment.Interfaces.Rest.Resources;

public record OrderResource(
    int Id,
    int UserId,
    int SubscriptionId,
    int OrderNumber,
    decimal Total,
    string Status,
    string Type);