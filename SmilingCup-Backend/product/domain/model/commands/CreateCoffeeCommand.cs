namespace SmilingCup_Backend.product.domain.model.commands;

public record CreateCoffeeCommand(
    int mysteryBoxId,
    int producerId,
    string name,
    string kind,
    List<string> notes,
    string place,
    decimal price,
    string toasted,
    string description,
    string imageUrl,
    string originKey,
    string minSuscription);