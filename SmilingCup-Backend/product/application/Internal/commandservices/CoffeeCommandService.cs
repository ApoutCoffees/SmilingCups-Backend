using SmilingCup_Backend.product.domain.model.aggregates;
using SmilingCup_Backend.product.domain.model.commands;
using SmilingCup_Backend.product.domain.repositories;
using SmilingCup_Backend.product.domain.services;
using SmilingCup_Backend.Shared.domain.repositories;

namespace SmilingCup_Backend.product.application.Internal.commandservices;

public class CoffeeCommandService(
    ICoffeeRepository coffeeRepository,
    IUnitOfWork unitOfWork)
    : ICoffeeCommandService
{
    public async Task<Coffee?> Handle(CreateCoffeeCommand command)
    {
        var coffee = new Coffee(command);
        try
        {
            await coffeeRepository.AddAsync(coffee);
            await unitOfWork.CompleteAsync();
            return coffee;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
}