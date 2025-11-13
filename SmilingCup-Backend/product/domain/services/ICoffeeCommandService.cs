using SmilingCup_Backend.product.domain.model.aggregates;
using SmilingCup_Backend.product.domain.model.commands;

namespace SmilingCup_Backend.product.domain.services;

public interface ICoffeeCommandService
{
    Task<Coffee> Handle(CreateCoffeeCommand command);
}