namespace SmilingCup_Backend.Payment.Interfaces.ACL;

public interface IPaymentContextFacade
{
    Task<int> CreateSubscription(string status, string plan);

    Task<int> CreateOrder(
        int orderId,
        int subscriptionId, 
        int orderNumber,
        decimal total, 
        string status, 
        string type );
}