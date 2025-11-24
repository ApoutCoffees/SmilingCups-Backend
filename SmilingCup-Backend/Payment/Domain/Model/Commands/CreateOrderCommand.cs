namespace SmilingCup_Backend.Payment.Domain.Model.Commands;

public record CreateOrderCommand(
    int UserId,
    int SubscriptionId,
    int OrderNumber,
    decimal Total,
    string Status,
    string Type);