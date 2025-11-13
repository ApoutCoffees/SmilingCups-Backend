namespace SmilingCup_Backend.product.domain.model.valueobjects;

public record UserId(int userId)
{
    public UserId(): this(0){}
}