using SmilingCup_Backend.Iam.Domain.Model.Aggregates;

namespace SmilingCup_Backend.Iam.Interfaces.ACL;

public interface IIamContextFacade
{
    Task<int> CreateUser(int subscriptionId, string fullName, string email, string password, 
        long phone, string address, string city, string country, string type);
    
    Task<User?> FetchUserById(int id);
}