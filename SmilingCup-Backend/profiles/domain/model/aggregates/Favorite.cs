using SmilingCup_Backend.profiles.domain.model.commands;
using SmilingCup_Backend.profiles.domain.model.valueobjects;

namespace SmilingCup_Backend.profiles.domain.model.aggregates;

public class Favorite
{
    public int id { get; }
    public UserId userId { get; }
    public CoffeeId coffeeId { get; }

    public Favorite()
    {
        userId = new UserId();
        coffeeId = new CoffeeId();
    }

    public Favorite(CreateFavoriteCommand command)
    {
        userId = new UserId(command.userId);
        coffeeId = new CoffeeId(command.coffeeId);
    }
    
}