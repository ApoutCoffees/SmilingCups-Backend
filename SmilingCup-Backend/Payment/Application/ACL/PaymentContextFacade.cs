using SmilingCup_Backend.Payment.Domain.Model.Commands;
using SmilingCup_Backend.Payment.Domain.Services;
using SmilingCup_Backend.Payment.Interfaces.ACL;

namespace SmilingCup_Backend.Payment.Application.ACL;

public class PaymentContextFacade(
    ISubscriptionCommandService subscriptionCommandService,
    IOrderCommandService orderCommandService) : IPaymentContextFacade
{
    public async Task<int> CreateSubscription(string status, string plan)
    {
        var createSubscriptionCommand = new CreateSubscriptionCommand(plan, status);
        var subscription = await subscriptionCommandService.Handle(createSubscriptionCommand);
        return subscription?.Id ?? 0;
    }

    public async Task<int> CreateOrder(
        int orderId,
        int subscriptionId,
        int orderNumber,
        decimal total,
        string status,
        string type)
    {
        var createOrderCommand = new CreateOrderCommand(orderId, subscriptionId, orderNumber, total, status, type);
        var order = await orderCommandService.Handle(createOrderCommand);
        return order?.Id ?? 0;
    }
}
