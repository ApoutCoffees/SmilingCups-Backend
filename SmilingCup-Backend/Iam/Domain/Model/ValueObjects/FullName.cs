namespace SmilingCup_Backend.Iam.Domain.Model.ValueObjects;

public record FullName(string FirstName, string LastName)
{
    public FullName() : this(string.Empty, string.Empty) { }
}