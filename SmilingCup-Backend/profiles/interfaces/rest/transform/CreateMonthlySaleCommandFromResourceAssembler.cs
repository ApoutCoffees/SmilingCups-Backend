using SmilingCup_Backend.profiles.domain.model.commands;
using SmilingCup_Backend.profiles.interfaces.rest.resources;

namespace SmilingCup_Backend.profiles.interfaces.rest.transform;

public static class CreateMonthlySaleCommandFromResourceAssembler
{
    public static CreateMonthlySaleCommand ToCommandFromResource(CreateMonthlySaleResource resource)
    {
        return new CreateMonthlySaleCommand(resource.producerStatId, resource.month, resource.sales);
    }
    
}