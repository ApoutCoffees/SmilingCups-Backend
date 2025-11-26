using SmilingCup_Backend.Iam.Domain.Model.Aggregates;

namespace SmilingCup_Backend.Iam.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}