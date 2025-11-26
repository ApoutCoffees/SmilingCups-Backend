using SmilingCup_Backend.Iam.Domain.Model.Aggregates;
using SmilingCup_Backend.Iam.Interfaces.REST.Resources;

namespace SmilingCup_Backend.Iam.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User entity, string token)
    {
        return new AuthenticatedUserResource(
            entity.Id,
            $"{entity.FullName.FirstName} {entity.FullName.LastName}",
            entity.Email.Address,
            token
        );
    }
}