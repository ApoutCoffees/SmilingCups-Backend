using SmilingCup_Backend.Payment.Domain.Model.Aggregates;
using SmilingCup_Backend.Payment.Interfaces.Rest.Resources;

namespace SmilingCup_Backend.Payment.Interfaces.Rest.Transform;

public static class OrderResourceFromEntityAssembler
{
    public static OrderResource ToResourceFromEntity(Order entity)
    {
        return new OrderResource(
            entity.Id,
            entity.UserId.userId,
            entity.SubscriptionId.subscriptionId,
            entity.OrderNumber,
            entity.Total.Amount,
            entity.Status.ToString(),
            entity.Type);
    }
}