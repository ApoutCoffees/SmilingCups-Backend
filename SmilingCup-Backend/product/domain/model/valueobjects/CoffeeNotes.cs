namespace SmilingCup_Backend.product.domain.model.valueobjects;

public record CoffeeNotes(List<string> notes)
{
    public CoffeeNotes(): this(new List<string>()){}
}