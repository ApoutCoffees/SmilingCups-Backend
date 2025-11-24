namespace SmilingCup_Backend.Payment.Domain.Model.ValueObjects;

public record UserId(int userId)
{
    public UserId(): this(0){}
}