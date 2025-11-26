using SmilingCup_Backend.Iam.Application.Internal.OutboundServices;
using SmilingCup_Backend.Iam.Domain.Model.Aggregates;
using SmilingCup_Backend.Iam.Domain.Model.Commands;
using SmilingCup_Backend.Iam.Domain.Repositories;
using SmilingCup_Backend.Iam.Domain.Services;
using SmilingCup_Backend.Iam.Domain.Model.ValueObjects;
using SmilingCup_Backend.Shared.domain.repositories;

namespace SmilingCup_Backend.Iam.Application.Internal.CommandServices;

public class UserCommandService(
    IUserRepository userRepository,
    ITokenService tokenService,
    IHashingService hashingService,
    IUnitOfWork unitOfWork) 
    : IUserCommandService
{

    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByEmailAsync(command.Email);
        
        if (user == null || !hashingService.VerifyPassword(command.Password, user.Password.Value))
            throw new Exception("Invalid email or password");
        
        var token = tokenService.GenerateToken(user);

        return (user, token);
    }


    public async Task Handle(SignUpCommand command)
    {
        if (await userRepository.ExistsByEmailAsync(command.Email))
            throw new Exception($"Email {command.Email} is already taken");
        
        var emailVo = new Email(command.Email);
        
        var nameParts = command.FullName.Split([' '], 2, StringSplitOptions.RemoveEmptyEntries);
        if (nameParts.Length < 2) 
            throw new ArgumentException("FullName must contain both first and last name.");
        
        var fullNameVo = new FullName(nameParts[0], nameParts[1]);
        
        if (!Enum.TryParse(command.Type, true, out UserType userType))
            throw new ArgumentException("Invalid user type specified.");
        
        var hashedPassword = hashingService.HashPassword(command.Password);
        var passwordVo = new Password(hashedPassword);
        var subscriptionIdVo = new SubscriptionId(command.SubscriptionId);
        var addressVo = new Address(command.Address);
        var user = new User(
            subscriptionIdVo,
            fullNameVo,
            emailVo,
            passwordVo,
            command.Phone,
            addressVo,
            command.City,
            command.Country,
            userType);

        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync(); // Commit
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating user: {e.Message}");
        }
    }
}