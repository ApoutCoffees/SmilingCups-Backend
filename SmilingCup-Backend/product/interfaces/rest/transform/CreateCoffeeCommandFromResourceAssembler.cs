using SmilingCup_Backend.product.domain.model.commands;
using SmilingCup_Backend.product.interfaces.rest.resources;

namespace SmilingCup_Backend.product.interfaces.rest.transform;

public static class CreateCoffeeCommandFromResourceAssembler
{
    public static CreateCoffeeCommand ToCommandFromResource(CreateCoffeeResource resource)
    {
        return new CreateCoffeeCommand(
            resource.mysteryBoxId,
            resource.producerId,
            resource.name,
            resource.kind,
            resource.notes,
            resource.place,
            resource.price,
            resource.toasted,
            resource.description,
            resource.imageUrl,
            resource.originKey,
            resource.minSuscription);
    }
    
}