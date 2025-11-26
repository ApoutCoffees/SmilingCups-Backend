using SmilingCup_Backend.profiles.domain.model.commands;

namespace SmilingCup_Backend.profiles.domain.model.aggregates;

using SmilingCup_Backend.profiles.domain.model.valueobjects;

public class ProducerStat
{
    public int id { get; }
    public UserId userId { get; }
    public int unitsSold { get; }
    public CoffeeId topCoffeeId { get; }

    public ProducerStat()
    {
        userId = new UserId(); 
        unitsSold = 0;
        topCoffeeId = new CoffeeId();
    }

    public ProducerStat(CreateProducerStatCommand command)
    {
        userId = new UserId(command.userId);
        unitsSold = command.unitsSold;
        topCoffeeId = new CoffeeId(command.topCoffeeId);
    }
}