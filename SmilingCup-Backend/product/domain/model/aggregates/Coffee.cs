using SmilingCup_Backend.product.domain.model.commands;
using SmilingCup_Backend.product.domain.model.valueobjects;
using SmilingCup_Backend.Shared.Domain.Model.ValueObjects;

namespace SmilingCup_Backend.product.domain.model.aggregates;

public class Coffee
{
    public int id { get; }
    public MysteryBoxId mysteryBoxId { get;}
    public UserId producerId { get; }
    public CoffeeName name { get; }
    public CoffeeKind kind { get; }
    public CoffeeNotes notes { get; }
    public OriginPlace place { get; }
    public Money price { get; }
    public RoastLevel toasted { get; }
    public string description { get; }
    public string imageUrl { get; }
    public string originKey { get; }
    public string minSubscription { get; }

    public Coffee()
    {
        mysteryBoxId = new MysteryBoxId();
        producerId = new UserId();
        name = new CoffeeName();
        kind = new CoffeeKind();
        notes = new CoffeeNotes();
        place = new OriginPlace();
        price = new Money();
        toasted = new RoastLevel();
        description = "";
        imageUrl = "";
        originKey = "";
        minSubscription = "";
    }

    public Coffee(CreateCoffeeCommand command)
    {
        mysteryBoxId = new MysteryBoxId(command.mysteryBoxId);
        producerId = new UserId(command.producerId);
        name = new CoffeeName(command.name);
        kind = new CoffeeKind(command.kind);
        notes = new CoffeeNotes(command.notes);
        place = new OriginPlace(command.place);
        price = new Money(command.price, "PEN");
        toasted = new RoastLevel(command.toasted);
        description = command.description;
        imageUrl = command.imageUrl;
        originKey = command.originKey;
        minSubscription = command.minSuscription;
    }
}