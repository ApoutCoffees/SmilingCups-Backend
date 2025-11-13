using SmilingCup_Backend.profiles.domain.model.aggregates;
using SmilingCup_Backend.profiles.interfaces.rest.resources;

namespace SmilingCup_Backend.profiles.interfaces.rest.transform;

public static class MonthlySaleResourceFromEntityAssembler
{
    public static MonthlySaleResource ToResourceFromEntity(MonthlySale entity)
    {
        return new MonthlySaleResource(
            entity.id,
            entity.producerStatId.producerStatId,
            entity.month.ToString(),
            entity.sales);
    }
}