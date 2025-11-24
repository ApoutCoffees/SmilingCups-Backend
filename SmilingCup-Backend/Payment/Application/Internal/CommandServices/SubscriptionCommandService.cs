using SmilingCup_Backend.Payment.Domain.Model.Aggregates;
using SmilingCup_Backend.Payment.Domain.Model.Commands;
using SmilingCup_Backend.Payment.Domain.Repositories;
using SmilingCup_Backend.Payment.Domain.Services;
using SmilingCup_Backend.Shared.domain.repositories;

namespace SmilingCup_Backend.Payment.Application.Internal.CommandServices;

public class SubscriptionCommandService
    (ISubscriptionRepository  subscriptionRepository, IUnitOfWork unitOfWork)
    : ISubscriptionCommandService
{
    public async Task<Subscription?> Handle(CreateSubscriptionCommand command)
    {
        var subscription = new Subscription(command);
        try
        {
            await subscriptionRepository.AddAsync(subscription);
            await unitOfWork.CompleteAsync();
            return subscription;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}