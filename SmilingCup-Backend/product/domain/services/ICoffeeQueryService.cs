using SmilingCup_Backend.product.domain.model.aggregates;
using SmilingCup_Backend.product.domain.model.queries;

namespace SmilingCup_Backend.product.domain.services;

public interface ICoffeeQueryService
{
    Task<IEnumerable<Coffee>> Handle(GetAllCoffeesQuery query);
    
    Task<Coffee> Handle(GetCoffeeByIdQuery query);
}