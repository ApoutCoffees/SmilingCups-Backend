namespace SmilingCup_Backend.profiles.domain.model.valueobjects;

public record CoffeeId(int coffeeId)
{
    public CoffeeId(): this(0){}
}