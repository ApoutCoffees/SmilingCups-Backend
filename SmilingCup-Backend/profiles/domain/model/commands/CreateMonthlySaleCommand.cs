namespace SmilingCup_Backend.profiles.domain.model.commands;

public record CreateMonthlySaleCommand(int producerStatId, string month, int sales);