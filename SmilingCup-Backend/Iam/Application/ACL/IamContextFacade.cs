using SmilingCup_Backend.Iam.Domain.Model.Aggregates;
using SmilingCup_Backend.Iam.Domain.Model.Commands;
using SmilingCup_Backend.Iam.Domain.Model.Queries; 
using SmilingCup_Backend.Iam.Domain.Services;
using SmilingCup_Backend.Iam.Interfaces.ACL;

namespace SmilingCup_Backend.Iam.Application.ACL;

public class IamContextFacade(
    IUserCommandService userCommandService, 
    IUserQueryService userQueryService) : IIamContextFacade
{

    public async Task<int> CreateUser(int subscriptionId, string fullName, string email, string password, 
        long phone, string address, string city, string country, string type)
    {

        var signUpCommand = new SignUpCommand(
            subscriptionId, fullName, email, password,
            phone, address, city, country,
            false, 
            type
        );
        
        await userCommandService.Handle(signUpCommand);

        var user = await userQueryService.Handle(new GetUserByEmailQuery(email));
        
        return user?.Id ?? 0;
    }
    
    public async Task<User?> FetchUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        return await userQueryService.Handle(getUserByIdQuery);
    }
}