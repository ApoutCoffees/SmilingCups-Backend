using SmilingCup_Backend.Iam.Domain.Model.Commands;
using SmilingCup_Backend.Iam.Interfaces.REST.Resources;

namespace SmilingCup_Backend.Iam.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(
            resource.SubscriptionId,
            resource.FullName,
            resource.Email,
            resource.Password,
            resource.Phone,
            resource.Address,
            resource.City,
            resource.Country,
            false,
            resource.Type
        );
    }
}