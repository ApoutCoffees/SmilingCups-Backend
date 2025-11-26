using Microsoft.EntityFrameworkCore; 
using SmilingCup_Backend.Iam.Domain.Model.Aggregates;
using SmilingCup_Backend.Iam.Domain.Repositories;
using SmilingCup_Backend.Shared.infrastructure.persistence.efc.configuration; // Para AppDbContext
using SmilingCup_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SmilingCup_Backend.Iam.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindByEmailAsync(string email)
    {
        return await Context.Set<User>()
            .FirstOrDefaultAsync(user => user.Email.Address.Equals(email));
    }
    
    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await Context.Set<User>()
            .AnyAsync(user => user.Email.Address.Equals(email));
    }
}