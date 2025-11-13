using SmilingCup_Backend.profiles.domain.model.commands;
using SmilingCup_Backend.profiles.domain.services;
using SmilingCup_Backend.profiles.interfaces.acl;

namespace SmilingCup_Backend.profiles.application.acl;

public class ProfilesContextFacade(
    IFavoriteCommandService favoriteCommandService,
    IMonthlySaleCommandService monthlySaleCommandService,
    IProducerStatCommandService producerStatCommandService) : IProfilesContextFacade
{
    public async Task<int> CreateProducerStat(int userId, int unitsSold, int topCoffeeId)
    {
        var createProducerStatCommand = new CreateProducerStatCommand(userId, unitsSold, topCoffeeId);
        var producerStat = await producerStatCommandService.Handle(createProducerStatCommand);
        return producerStat?.id ?? 0;
    }

    public async Task<int> CreateMonthlySale(int producerStatId, string month, int sales)
    {
        var createMonthlySaleCommand = new CreateMonthlySaleCommand(producerStatId, month, sales);
        var monthlySale = await monthlySaleCommandService.Handle(createMonthlySaleCommand);
        return monthlySale?.id ?? 0;
    }

    public async Task<int> CreateFavorite(int userId, int coffeeId)
    {
        var createFavoriteCommand = new CreateFavoriteCommand(userId, coffeeId);
        var favorite = await favoriteCommandService.Handle(createFavoriteCommand);
        return favorite?.id ?? 0;
    }
}