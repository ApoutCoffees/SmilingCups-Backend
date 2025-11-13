using SmilingCup_Backend.product.domain.model.aggregates;
using SmilingCup_Backend.product.domain.repositories;
using SmilingCup_Backend.Shared.infrastructure.persistence.efc.configuration;
using SmilingCup_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SmilingCup_Backend.product.infrastructure.persistence.efc.repositories;

public class CoffeeRepository(AppDbContext context)
    : BaseRepository<Coffee>(context),  ICoffeeRepository
{
    
}