namespace SmilingCup_Backend.profiles.domain.model.commands;

public record CreateProducerStatCommand(int userId, int unitsSold, int topCoffeeId);