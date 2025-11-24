
using SmilingCup_Backend.Payment.Domain.Model.Commands;
using SmilingCup_Backend.Payment.Domain.Model.ValueObjects;

namespace SmilingCup_Backend.Payment.Domain.Model.Aggregates;

public class Subscription
{
    public int Id { get;}
    public SubscriptionStatus Status { get; private set; }
    public SubscriptionPlan Plan { get; private set; }

    public Subscription()
    {
        Status = new SubscriptionStatus();
        Plan = new SubscriptionPlan();
    }

    public Subscription(CreateSubscriptionCommand command)
    {
        Status = Enum.Parse<SubscriptionStatus>(command.Status, ignoreCase: true);
        Plan = Enum.Parse<SubscriptionPlan>(command.Plan, ignoreCase: true);
    }
   
}