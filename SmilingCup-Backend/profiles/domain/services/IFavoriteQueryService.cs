using SmilingCup_Backend.profiles.domain.model.aggregates;
using SmilingCup_Backend.profiles.domain.model.queries;

namespace SmilingCup_Backend.profiles.domain.services;

public interface IFavoriteQueryService
{
    Task<IEnumerable<Favorite>> Handle(GetAllFavoritesQuery query);
    
    Task<Favorite> Handle(GetFavoriteByIdQuery query);
}