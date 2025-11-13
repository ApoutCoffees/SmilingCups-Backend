using SmilingCup_Backend.product.domain.model.aggregates;
using SmilingCup_Backend.product.domain.model.queries;
using SmilingCup_Backend.product.domain.repositories;
using SmilingCup_Backend.product.domain.services;

namespace SmilingCup_Backend.product.application.Internal.queryservices;

public class CoffeeQueryService(ICoffeeRepository  coffeeRepository):ICoffeeQueryService
{
    public async Task<IEnumerable<Coffee>> Handle(GetAllCoffeesQuery query)
    {
        return await coffeeRepository.ListAsync();
    }

    public async Task<Coffee?> Handle(GetCoffeeByIdQuery query)
    {
        return await coffeeRepository.FindByIdAsync(query.id);
    }
}