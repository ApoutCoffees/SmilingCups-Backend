using SmilingCup_Backend.Payment.Domain.Model.Aggregates;
using SmilingCup_Backend.Payment.Domain.Model.Queries;
using SmilingCup_Backend.Payment.Domain.Repositories;
using SmilingCup_Backend.Payment.Domain.Services;

namespace SmilingCup_Backend.Payment.Application.Internal.QueryServices;

public class OrderQueryService(IOrderRepository orderRepository) : IOrderQueryService
{
    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query)
    {
        return await orderRepository.ListAsync();
    }

    public async Task<Order?> Handle(GetOrderByIdQuery query)
    {
        return await orderRepository.FindByIdAsync(query.Id);
    }
}