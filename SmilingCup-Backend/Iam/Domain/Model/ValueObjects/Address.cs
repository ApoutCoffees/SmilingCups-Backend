namespace SmilingCup_Backend.Iam.Domain.Model.ValueObjects;

public record Address(string Value)
{
    public Address() : this(string.Empty) { }
}