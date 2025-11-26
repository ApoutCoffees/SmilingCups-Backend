using SmilingCup_Backend.Payment.Domain.Model.Aggregates;
using SmilingCup_Backend.Payment.Domain.Model.Queries;
using SmilingCup_Backend.Payment.Domain.Repositories;
using SmilingCup_Backend.Payment.Domain.Services;

namespace SmilingCup_Backend.Payment.Application.Internal.QueryServices;

public class SubscriptionQueryService
    (ISubscriptionRepository subscriptionRepository) 
    : ISubscriptionQueryService
{
    public async Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery query)
    {
        return await subscriptionRepository.ListAsync();
    }

    public async Task<Subscription?> Handle(GetSubscriptionByIdQuery query)
    {
        return await subscriptionRepository.FindByIdAsync(query.Id);
    }
}