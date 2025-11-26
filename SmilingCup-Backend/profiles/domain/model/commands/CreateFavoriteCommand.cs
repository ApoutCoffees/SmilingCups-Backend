namespace SmilingCup_Backend.profiles.domain.model.commands;

public record CreateFavoriteCommand(int userId, int coffeeId);