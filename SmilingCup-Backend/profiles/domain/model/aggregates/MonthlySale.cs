using SmilingCup_Backend.profiles.domain.model.commands;
using SmilingCup_Backend.profiles.domain.model.valueobjects;

namespace SmilingCup_Backend.profiles.domain.model.aggregates;

public class MonthlySale
{
    public int id { get; }
    public ProducerStatId producerStatId { get; }
    public Month month { get; }
    public int sales { get; }

    public MonthlySale()
    {
        producerStatId = new ProducerStatId();
        month = new Month();
        sales = 0;
    }

    public MonthlySale(CreateMonthlySaleCommand command)
    {
        producerStatId = new ProducerStatId(command.producerStatId);
        month = Enum.Parse<Month>(command.month, ignoreCase: true);
        sales = command.sales;
    }
}