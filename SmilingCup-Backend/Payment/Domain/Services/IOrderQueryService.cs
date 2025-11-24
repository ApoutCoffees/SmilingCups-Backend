using SmilingCup_Backend.Payment.Domain.Model.Aggregates;
using SmilingCup_Backend.Payment.Domain.Model.Queries;

namespace SmilingCup_Backend.Payment.Domain.Services;

public interface IOrderQueryService
{
    Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query);
    
    Task<Order?> Handle(GetOrderByIdQuery query);
}