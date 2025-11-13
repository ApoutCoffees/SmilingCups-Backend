using SmilingCup_Backend.product.domain.model.aggregates;
using SmilingCup_Backend.product.interfaces.rest.resources;

namespace SmilingCup_Backend.product.interfaces.rest.transform;

public static class MysteryBoxResourceFromEntityAssembler
{
    public static MysteryBoxResource ToResourceFromEntity(MysteryBox entity)
    {
        return new MysteryBoxResource(
            entity.id,
            entity.totalAmount.Amount,
            entity.CreatedDate.ToString(),
            entity.UpdatedDate.ToString()
            );
    }
}