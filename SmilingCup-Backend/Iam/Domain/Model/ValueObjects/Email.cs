namespace SmilingCup_Backend.Iam.Domain.Model.ValueObjects;

public record Email(string Address)
{
    public Email() : this(string.Empty) { }
}