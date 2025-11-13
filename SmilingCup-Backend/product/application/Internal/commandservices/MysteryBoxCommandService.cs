using SmilingCup_Backend.product.domain.model.aggregates;
using SmilingCup_Backend.product.domain.model.commands;
using SmilingCup_Backend.product.domain.repositories;
using SmilingCup_Backend.product.domain.services;
using SmilingCup_Backend.Shared.domain.repositories;

namespace SmilingCup_Backend.product.application.Internal.commandservices;

public class MysteryBoxCommandService(
    IMysteryBoxRepository mysteryBoxRepository,
    IUnitOfWork unitOfWork)
    : IMysteryBoxCommandService
{
    public async Task<MysteryBox?> Handle(CreateMysteryBoxCommand command)
    {
        var mysteryBox = new MysteryBox(command);
        try
        {
            await mysteryBoxRepository.AddAsync(mysteryBox);
            await unitOfWork.CompleteAsync();
            return mysteryBox;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}