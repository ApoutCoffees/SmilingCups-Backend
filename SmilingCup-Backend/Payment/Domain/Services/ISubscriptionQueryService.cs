using SmilingCup_Backend.Payment.Domain.Model.Aggregates;
using SmilingCup_Backend.Payment.Domain.Model.Queries;

namespace SmilingCup_Backend.Payment.Domain.Services;

public interface ISubscriptionQueryService 
{
    Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery query);
    
    Task<Subscription?> Handle(GetSubscriptionByIdQuery query);
}