using SmilingCup_Backend.product.domain.model.aggregates;
using SmilingCup_Backend.product.domain.model.commands;

namespace SmilingCup_Backend.product.domain.services;

public interface IMysteryBoxCommandService
{
    Task<MysteryBox?> Handle(CreateMysteryBoxCommand command);
}