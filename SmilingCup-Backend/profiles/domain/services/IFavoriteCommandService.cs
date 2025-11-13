using SmilingCup_Backend.profiles.domain.model.aggregates;
using SmilingCup_Backend.profiles.domain.model.commands;

namespace SmilingCup_Backend.profiles.domain.services;

public interface IFavoriteCommandService
{
    Task<Favorite?> Handle(CreateFavoriteCommand command);
}