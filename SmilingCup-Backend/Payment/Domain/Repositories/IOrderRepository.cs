using SmilingCup_Backend.Payment.Domain.Model.Aggregates;
using SmilingCup_Backend.Shared.domain.repositories;

namespace SmilingCup_Backend.Payment.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    
}