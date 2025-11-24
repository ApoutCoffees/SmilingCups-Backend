using SmilingCup_Backend.Payment.Domain.Model.Aggregates;
using SmilingCup_Backend.Payment.Domain.Model.Commands;
using SmilingCup_Backend.Payment.Domain.Repositories;
using SmilingCup_Backend.Payment.Domain.Services;
using SmilingCup_Backend.Shared.domain.repositories;

namespace SmilingCup_Backend.Payment.Application.Internal.CommandServices;

public class OrderCommandService
    (IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    : IOrderCommandService
{
    public async Task<Order?> Handle(CreateOrderCommand command)
    {
        var order = new Order(command);
        try
        {
            await orderRepository.AddAsync(order);
            await unitOfWork.CompleteAsync();
            return order;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}