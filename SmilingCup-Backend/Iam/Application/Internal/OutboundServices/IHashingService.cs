namespace SmilingCup_Backend.Iam.Application.Internal.OutboundServices;

public interface IHashingService
{
    string HashPassword(string password);
    bool VerifyPassword(string providedPassword, string storedHash);
}