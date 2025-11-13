using SmilingCup_Backend.profiles.domain.model.aggregates;
using SmilingCup_Backend.profiles.domain.model.queries;
using SmilingCup_Backend.profiles.domain.repositories;
using SmilingCup_Backend.profiles.domain.services;

namespace SmilingCup_Backend.profiles.application.Internal.queryservices;

public class MonthlySaleQueryService(IMonthlySaleRepository monthlySaleRepository)
    : IMonthlySaleQueryService
{
    public async Task<IEnumerable<MonthlySale>> Handle(GetAllMonthlySalesQuery query)
    {
        return await monthlySaleRepository.ListAsync();
    }

    public async Task<MonthlySale?> Handle(GetMonthlySaleByIdQuery query)
    {
        return await monthlySaleRepository.FindByIdAsync(query.id);
    }
}