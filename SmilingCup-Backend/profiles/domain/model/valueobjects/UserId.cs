namespace SmilingCup_Backend.profiles.domain.model.valueobjects;

public record UserId(int userId)
{
    public UserId(): this(0){}
}