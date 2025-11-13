using SmilingCup_Backend.product.domain.model.commands;
using SmilingCup_Backend.product.interfaces.rest.resources;

namespace SmilingCup_Backend.product.interfaces.rest.transform;

public static class CreateMysteryBoxFromResourceAssembler
{
    public static CreateMysteryBoxCommand ToCommandFromResource(CreateMysteryBoxResource resource)
    {
        return new CreateMysteryBoxCommand(resource.totalAmount);
    }
}