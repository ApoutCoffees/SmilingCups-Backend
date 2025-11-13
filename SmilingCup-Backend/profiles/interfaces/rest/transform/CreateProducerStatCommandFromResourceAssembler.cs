using SmilingCup_Backend.profiles.domain.model.commands;
using SmilingCup_Backend.profiles.interfaces.rest.resources;

namespace SmilingCup_Backend.profiles.interfaces.rest.transform;

public static class CreateProducerStatCommandFromResourceAssembler
{
    public static CreateProducerStatCommand ToCommandFromResource(CreateProducerStatResource resource)
    {
        return new CreateProducerStatCommand(resource.userId, resource.unitsSold, resource.topCoffeeId);
    }
}