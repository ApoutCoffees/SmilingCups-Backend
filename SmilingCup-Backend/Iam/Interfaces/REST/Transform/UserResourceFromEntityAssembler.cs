using SmilingCup_Backend.Iam.Domain.Model.Aggregates;
using SmilingCup_Backend.Iam.Interfaces.REST.Resources;

namespace SmilingCup_Backend.Iam.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(
            entity.Id,
            entity.SubscriptionId.Id, 
            $"{entity.FullName.FirstName} {entity.FullName.LastName}",
            entity.Email.Address,
            entity.Phone,
            entity.Address.Value,
            entity.City,
            entity.Country,
            entity.IsVerified,
            entity.Type.ToString()
        );
    }
}