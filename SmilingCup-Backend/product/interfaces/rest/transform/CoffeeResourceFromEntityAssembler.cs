using SmilingCup_Backend.product.domain.model.aggregates;
using SmilingCup_Backend.product.interfaces.rest.resources;

namespace SmilingCup_Backend.product.interfaces.rest.transform;

public static class CoffeeResourceFromEntityAssembler
{
    public static CoffeeResource ToResourceFromEntity(Coffee entity)
    {
        return new CoffeeResource(
            entity.id,
            entity.mysteryBoxId.mysteryBoxId,
            entity.producerId.userId,
            entity.name.name,
            entity.kind.kind,
            entity.notes.notes,
            entity.place.originPlace,
            entity.price.Amount,
            entity.toasted.roastLevel,
            entity.description,
            entity.imageUrl,
            entity.originKey,
            entity.minSubscription);
    }
}