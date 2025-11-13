using SmilingCup_Backend.Iam.Application.Internal.OutboundServices;
using BCryptNet = BCrypt.Net.BCrypt;

namespace SmilingCup_Backend.Iam.Infrastructure.Hashing.Bcrypt.Services;

public class HashingService : IHashingService
{
    public string HashPassword(string password)
    {
        return BCryptNet.HashPassword(password);
    }
    
    public bool VerifyPassword(string providedPassword, string storedHash)
    {
        return BCryptNet.Verify(providedPassword, storedHash);
    }
}