using SmilingCup_Backend.profiles.domain.model.aggregates;
using SmilingCup_Backend.profiles.domain.model.commands;
using SmilingCup_Backend.profiles.domain.repositories;
using SmilingCup_Backend.profiles.domain.services;
using SmilingCup_Backend.Shared.domain.repositories;

namespace SmilingCup_Backend.profiles.application.Internal.commandservices;

public class ProducerStatCommandService(
    IProducerStatRepository producerStatRepository, IUnitOfWork unitOfWork)
    : IProducerStatCommandService
{
    public async Task<ProducerStat?> Handle(CreateProducerStatCommand command)
    {
        var producerStat = new ProducerStat(command);
        try
        {
            await producerStatRepository.AddAsync(producerStat);
            await unitOfWork.CompleteAsync();
            return producerStat;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
}