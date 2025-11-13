using SmilingCup_Backend.product.domain.model.aggregates;
using SmilingCup_Backend.product.domain.model.queries;

namespace SmilingCup_Backend.product.domain.services;

public interface IMysteryBoxQueryService
{
    Task<IEnumerable<MysteryBox>> Handle(GetAllMysteryBoxesQuery query);
    
    Task<MysteryBox> Handle(GetMysteryBoxByIdQuery query);
}