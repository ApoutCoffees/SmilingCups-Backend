using SmilingCup_Backend.Payment.Domain.Model.Aggregates;
using SmilingCup_Backend.Payment.Interfaces.Rest.Resources;

namespace SmilingCup_Backend.Payment.Interfaces.Rest.Transform;

public static class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResourceFromEntity(Subscription entity)
    {
        return new SubscriptionResource(
            entity.Id,
            entity.Plan.ToString(),
            entity.Status.ToString());
    }
}