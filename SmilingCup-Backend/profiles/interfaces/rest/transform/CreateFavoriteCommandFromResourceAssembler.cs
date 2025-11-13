using SmilingCup_Backend.profiles.domain.model.commands;
using SmilingCup_Backend.profiles.interfaces.rest.resources;

namespace SmilingCup_Backend.profiles.interfaces.rest.transform;

public static class CreateFavoriteCommandFromResourceAssembler
{
    public static CreateFavoriteCommand ToCommandFromResource(CreateFavoriteResource resource)
    {
        return new CreateFavoriteCommand(resource.userId, resource.coffeeId);
    }
}