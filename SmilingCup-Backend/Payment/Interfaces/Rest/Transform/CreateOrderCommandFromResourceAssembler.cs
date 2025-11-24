using SmilingCup_Backend.Payment.Domain.Model.Commands;
using SmilingCup_Backend.Payment.Interfaces.Rest.Resources;

namespace SmilingCup_Backend.Payment.Interfaces.Rest.Transform;

public static class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderCommand ToCommandFromResource(CreateOrderResource resource)
    {
        return new CreateOrderCommand(
            resource.UserId,
            resource.SubscriptionId,
            resource.OrderNumber,
            resource.Total,
            resource.Status,
            resource.Type);
    }
}