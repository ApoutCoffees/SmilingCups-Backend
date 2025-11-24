using SmilingCup_Backend.Payment.Domain.Model.Commands;
using SmilingCup_Backend.Payment.Interfaces.Rest.Resources;

namespace SmilingCup_Backend.Payment.Interfaces.Rest.Transform;

public static class CreateSubscriptionCommandFromResourceAssembler
{
    public static CreateSubscriptionCommand ToCommandFromResource(CreateSubscriptionResource resource)
    {
        return new CreateSubscriptionCommand(
            resource.Plan,
            resource.Status);
    }
}