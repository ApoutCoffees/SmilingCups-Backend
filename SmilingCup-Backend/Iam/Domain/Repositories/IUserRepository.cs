using SmilingCup_Backend.Iam.Domain.Model.Aggregates;
using SmilingCup_Backend.Shared.domain.repositories;

namespace SmilingCup_Backend.Iam.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User> 
{
    Task<User?> FindByEmailAsync(string email);
    
    Task<bool> ExistsByEmailAsync(string email);
}