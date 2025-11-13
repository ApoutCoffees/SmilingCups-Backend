using SmilingCup_Backend.Iam.Domain.Model.Aggregates;
using SmilingCup_Backend.Iam.Domain.Model.Queries;

namespace SmilingCup_Backend.Iam.Domain.Services;

public interface IUserQueryService
{

    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
    
    Task<User?> Handle(GetUserByEmailQuery query);
}