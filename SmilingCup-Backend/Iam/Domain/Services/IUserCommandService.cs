using SmilingCup_Backend.Iam.Domain.Model.Aggregates;
using SmilingCup_Backend.Iam.Domain.Model.Commands;

namespace SmilingCup_Backend.Iam.Domain.Services;

public interface IUserCommandService
{
    Task<(User user, string token)> Handle(SignInCommand command);
    
    Task Handle(SignUpCommand command);
}