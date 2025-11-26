namespace SmilingCup_Backend.profiles.interfaces.acl;

public interface IProfilesContextFacade
{
    Task<int> CreateProducerStat(int userId, int unitsSold, int topCoffeeId);

    Task<int> CreateMonthlySale(int producerStatId, string month, int sales);

    Task<int> CreateFavorite(int userId, int coffeeId);
}