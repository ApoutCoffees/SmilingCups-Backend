using SmilingCup_Backend.profiles.domain.model.aggregates;
using SmilingCup_Backend.profiles.domain.model.queries;
using SmilingCup_Backend.profiles.domain.repositories;
using SmilingCup_Backend.profiles.domain.services;

namespace SmilingCup_Backend.profiles.application.Internal.queryservices;

public class FavoriteQueryService(IFavoriteRepository favoriteRepository)
    : IFavoriteQueryService
{
    public async Task<IEnumerable<Favorite>> Handle(GetAllFavoritesQuery query)
    {
        return await favoriteRepository.ListAsync();
    }

    public async Task<Favorite?> Handle(GetFavoriteByIdQuery query)
    {
        return await favoriteRepository.FindByIdAsync(query.id);
    }
}