namespace SmilingCup_Backend.Payment.Interfaces.Rest.Resources;

public record CreateOrderResource(
    int UserId,
    int SubscriptionId,
    int OrderNumber,
    decimal Total,
    string Status,
    string Type);