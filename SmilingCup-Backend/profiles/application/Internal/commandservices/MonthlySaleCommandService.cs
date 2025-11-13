using SmilingCup_Backend.profiles.domain.model.aggregates;
using SmilingCup_Backend.profiles.domain.model.commands;
using SmilingCup_Backend.profiles.domain.repositories;
using SmilingCup_Backend.profiles.domain.services;
using SmilingCup_Backend.Shared.domain.repositories;

namespace SmilingCup_Backend.profiles.application.Internal.commandservices;

public class MonthlySaleCommandService(
    IMonthlySaleRepository monthlySaleRepository, IUnitOfWork unitOfWork)
    : IMonthlySaleCommandService
{
    public async Task<MonthlySale?> Handle(CreateMonthlySaleCommand command)
    {
        var  monthlySale = new MonthlySale(command);
        try
        {
            await monthlySaleRepository.AddAsync(monthlySale);
            await unitOfWork.CompleteAsync();
            return monthlySale;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}