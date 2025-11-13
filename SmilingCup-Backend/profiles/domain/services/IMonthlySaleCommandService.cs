using SmilingCup_Backend.profiles.domain.model.aggregates;
using SmilingCup_Backend.profiles.domain.model.commands;

namespace SmilingCup_Backend.profiles.domain.services;

public interface IMonthlySaleCommandService
{
    Task<MonthlySale> Handle(CreateMonthlySaleCommand command);
}