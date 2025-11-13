using SmilingCup_Backend.profiles.domain.model.aggregates;
using SmilingCup_Backend.profiles.domain.model.queries;
using SmilingCup_Backend.profiles.domain.repositories;
using SmilingCup_Backend.profiles.domain.services;

namespace SmilingCup_Backend.profiles.application.Internal.queryservices;

public class ProducerStatQueryService(IProducerStatRepository producerStatRepository)
    : IProducerStatQueryService
{
    public async Task<IEnumerable<ProducerStat>> Handle(GetAllProducerStatsQuery query)
    {
        return await producerStatRepository.ListAsync();
    }

    public async Task<ProducerStat?> Handle(GetProducerStatByIdQuery query)
    {
        return await producerStatRepository.FindByIdAsync(query.id);
    }
}