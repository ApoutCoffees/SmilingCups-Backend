namespace SmilingCup_Backend.Iam.Domain.Model.ValueObjects;

public record Password(string Value)
{
    public Password() : this(string.Empty) { }
}