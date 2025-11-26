namespace SmilingCup_Backend.product.interfaces.rest.resources;

public record CoffeeResource(
    int id,
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