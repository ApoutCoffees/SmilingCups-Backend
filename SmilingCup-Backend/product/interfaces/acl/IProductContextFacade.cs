namespace SmilingCup_Backend.product.interfaces.acl;

public interface IProductContextFacade
{
    Task<int> CreateMysteryBox(decimal totalAmount);

    Task<int> CreateCoffee(
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
        string minSubscription);
}