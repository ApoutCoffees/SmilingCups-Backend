using Cortex.Mediator.Queries;
using SmilingCup_Backend.Iam.Domain.Model.Aggregates;
namespace SmilingCup_Backend.Iam.Domain.Model.Queries;

public record GetAllUsersQuery() : IQuery<IEnumerable<User>>;