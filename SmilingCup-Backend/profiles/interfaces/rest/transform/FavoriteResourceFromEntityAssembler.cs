using SmilingCup_Backend.profiles.domain.model.aggregates;
using SmilingCup_Backend.profiles.interfaces.rest.resources;

namespace SmilingCup_Backend.profiles.interfaces.rest.transform;

public static class FavoriteResourceFromEntityAssembler
{
    public static FavoriteResource ToResourceFromEntity(Favorite entity)
    {
        return new FavoriteResource(entity.id, entity.userId.userId, entity.coffeeId.coffeeId);
    }
}