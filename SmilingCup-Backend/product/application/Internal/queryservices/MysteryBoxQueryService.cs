using SmilingCup_Backend.product.domain.model.aggregates;
using SmilingCup_Backend.product.domain.model.queries;
using SmilingCup_Backend.product.domain.repositories;
using SmilingCup_Backend.product.domain.services;

namespace SmilingCup_Backend.product.application.Internal.queryservices;

public class MysteryBoxQueryService(IMysteryBoxRepository mysteryBoxRepository):
    IMysteryBoxQueryService
{
    public async Task<IEnumerable<MysteryBox>> Handle(GetAllMysteryBoxesQuery query)
    {
        return await mysteryBoxRepository.ListAsync();
    }

    public async Task<MysteryBox?> Handle(GetMysteryBoxByIdQuery query)
    {
        return await mysteryBoxRepository.FindByIdAsync(query.id);
    }
    
}