using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;
using SmilingCup_Backend.product.domain.model.commands;
using SmilingCup_Backend.Shared.Domain.Model.ValueObjects;

namespace SmilingCup_Backend.product.domain.model.aggregates;

public class MysteryBox : IEntityWithCreatedUpdatedDate
{
    public int id { get; }
    public Money totalAmount { get; }
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }

    public MysteryBox()
    {
        totalAmount = new Money();
    }

    public MysteryBox(CreateMysteryBoxCommand command)
    {
        totalAmount = new Money(command.totalAmount, "PEN");
    }
}