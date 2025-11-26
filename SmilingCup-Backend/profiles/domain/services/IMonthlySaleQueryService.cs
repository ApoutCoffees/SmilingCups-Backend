using SmilingCup_Backend.profiles.domain.model.aggregates;
using SmilingCup_Backend.profiles.domain.model.queries;

namespace SmilingCup_Backend.profiles.domain.services;

public interface IMonthlySaleQueryService
{
    Task<IEnumerable<MonthlySale>> Handle(GetAllMonthlySalesQuery query);
    
    Task<MonthlySale?> Handle(GetMonthlySaleByIdQuery query);
}