namespace SmilingCup_Backend.profiles.interfaces.rest.resources;

public record CreateMonthlySaleResource(int producerStatId, string month, int sales);