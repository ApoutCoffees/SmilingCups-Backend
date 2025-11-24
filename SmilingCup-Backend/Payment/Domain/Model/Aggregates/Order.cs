using SmilingCup_Backend.Payment.Domain.Model.Commands;
using SmilingCup_Backend.Payment.Domain.Model.ValueObjects;
using SmilingCup_Backend.Shared.Domain.Model.ValueObjects;

namespace SmilingCup_Backend.Payment.Domain.Model.Aggregates;

public class Order
{
    public int Id { get; }
    public UserId UserId { get; private set; }
    public SubscriptionId SubscriptionId { get; private set; }
    public int OrderNumber { get; private set; }
    public Money Total { get; private set; }
    public OrderStatus Status { get; private set; }
    public string Type { get; private set; }

    public Order()
    {
        UserId = new  UserId();
        SubscriptionId = new  SubscriptionId();
        OrderNumber = 0;
        Total = new Money();
        Status = new OrderStatus();
        Type = "";
    }

    public Order(CreateOrderCommand command)
    {
        UserId = new UserId(command.UserId);
        SubscriptionId = new SubscriptionId(command.SubscriptionId);
        OrderNumber = command.OrderNumber;
        Total = new Money(command.Total, "PEN");
        Status = Enum.Parse<OrderStatus>(command.Status, ignoreCase: true);
        Type = command.Type;
    }
}