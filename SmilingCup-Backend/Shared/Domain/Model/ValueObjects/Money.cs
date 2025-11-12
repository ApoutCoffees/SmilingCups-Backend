
namespace SmilingCup_Backend.Shared.Domain.Model.ValueObjects;

public record Money(decimal Amount, string Currency)
{
    public Money() : this(0, string.Empty) { } 

    /// <summary>
    /// Agrega otro objeto Money, retornando una nueva instancia (inmutabilidad).
    /// </summary>
    /// <param name="other">El objeto Money a sumar.</param>
    /// <returns>Un nuevo objeto Money con la suma de las cantidades.</returns>
    public Money Add(Money other)
    {
        if (Currency != other.Currency)
        {
            throw new InvalidOperationException("Cannot add amounts with different currencies.");
        }
        return new Money(Amount + other.Amount, Currency);
    }
}