namespace SmilingCup_Backend.product.domain.model.valueobjects;

public record CoffeeName(string name)
{
    public CoffeeName(): this(""){}
}