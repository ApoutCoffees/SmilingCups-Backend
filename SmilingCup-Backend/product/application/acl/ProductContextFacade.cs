using SmilingCup_Backend.product.domain.model.commands;
using SmilingCup_Backend.product.domain.services;
using SmilingCup_Backend.product.interfaces.acl;

namespace SmilingCup_Backend.product.application.acl;

public class ProductContextFacade(
    IMysteryBoxCommandService mysteryBoxCommandService,
    ICoffeeCommandService coffeeCommandService) : IProductContextFacade
{

    public async Task<int> CreateMysteryBox(decimal totalAmount)
    {
        var createMysteryBoxCommand = new CreateMysteryBoxCommand(totalAmount);
        var mysteryBox = await mysteryBoxCommandService.Handle(createMysteryBoxCommand);
        return mysteryBox?.id ?? 0;
    }

    public async Task<int> CreateCoffee(
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
        string minSubscription)
    {
        var createCoffeeCommand = new CreateCoffeeCommand(
            mysteryBoxId,
            producerId,
            name,
            kind,
            notes,
            place,
            price, 
            toasted, 
            description, 
            imageUrl, 
            originKey, 
            minSubscription);
        var coffee = await coffeeCommandService.Handle(createCoffeeCommand);
        return coffee?.id ?? 0;
    }
    
    

}