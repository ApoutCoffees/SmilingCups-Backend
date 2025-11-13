using SmilingCup_Backend.profiles.domain.model.aggregates;
using SmilingCup_Backend.profiles.domain.model.commands;
using SmilingCup_Backend.profiles.domain.repositories;
using SmilingCup_Backend.profiles.domain.services;
using SmilingCup_Backend.Shared.domain.repositories;

namespace SmilingCup_Backend.profiles.application.Internal.commandservices;

public class FavoriteCommandService(
    IFavoriteRepository favoriteRepository, IUnitOfWork  unitOfWork)
    : IFavoriteCommandService
{
    public async Task<Favorite> Handle(CreateFavoriteCommand command)
    {
        var favorite = new Favorite(command);
        try
        {
            await favoriteRepository.AddAsync(favorite);
            await unitOfWork.CompleteAsync();
            return favorite;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
}