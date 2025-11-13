using SmilingCup_Backend.profiles.domain.model.aggregates;
using SmilingCup_Backend.profiles.domain.model.queries;

namespace SmilingCup_Backend.profiles.domain.services;

public interface IProducerStatQueryService
{
    Task<IEnumerable<ProducerStat>> Handle(GetAllProducerStatsQuery query);
    
    Task<ProducerStat> Handle(GetProducerStatByIdQuery query);
}