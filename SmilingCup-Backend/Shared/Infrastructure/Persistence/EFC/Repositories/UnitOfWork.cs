
using SmilingCup_Backend.Shared.domain.repositories;
using SmilingCup_Backend.Shared.infrastructure.persistence.efc.configuration;

namespace SmilingCup_Backend.Shared.infrastructure.persistence.efc.repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    // inheritedDoc
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}