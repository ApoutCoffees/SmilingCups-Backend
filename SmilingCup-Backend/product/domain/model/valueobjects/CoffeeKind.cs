namespace SmilingCup_Backend.product.domain.model.valueobjects;

public record CoffeeKind(string kind)
{
    public CoffeeKind(): this(""){}
}