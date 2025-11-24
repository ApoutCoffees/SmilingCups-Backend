using SmilingCup_Backend.Payment.Domain.Model.Aggregates;
using SmilingCup_Backend.Payment.Domain.Model.Commands;

namespace SmilingCup_Backend.Payment.Domain.Services;

public interface IOrderCommandService
{
    Task<Order?> Handle(CreateOrderCommand command);
}