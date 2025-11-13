using SmilingCup_Backend.profiles.domain.model.aggregates;
using SmilingCup_Backend.profiles.domain.repositories;
using SmilingCup_Backend.Shared.infrastructure.persistence.efc.configuration;
using SmilingCup_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SmilingCup_Backend.profiles.infrastructure.persistence.efc.repositories;

public class ProducerStatRepository(AppDbContext context)
    : BaseRepository<ProducerStat>(context), IProducerStatRepository
{
    
}