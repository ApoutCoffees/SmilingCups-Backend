using SmilingCup_Backend.profiles.domain.model.aggregates;
using SmilingCup_Backend.profiles.interfaces.rest.resources;

namespace SmilingCup_Backend.profiles.interfaces.rest.transform;

public static class ProducerStatResourceFromEntityAssembler
{
    public static ProducerStatResource ToResourceFromEntity(ProducerStat entity)
    {
        return new ProducerStatResource(
            entity.id,
            entity.userId.userId,
            entity.unitsSold,
            entity.topCoffeeId.coffeeId);
    }
    
}