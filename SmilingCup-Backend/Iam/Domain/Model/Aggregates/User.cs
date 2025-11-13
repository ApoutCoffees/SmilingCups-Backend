using System.Text.Json.Serialization;
using SmilingCup_Backend.Iam.Domain.Model.ValueObjects;

namespace SmilingCup_Backend.Iam.Domain.Model.Aggregates;

public class User
{

    public User(SubscriptionId subscriptionId, FullName fullName, Email email, Password password, 
                long phone, Address address, string city, string country, UserType type)
    {
        SubscriptionId = subscriptionId;
        FullName = fullName;
        Email = email;
        Password = password;
        Phone = phone;
        Address = address; 
        City = city; 
        Country = country;
        IsVerified = false; 
        Type = type;
    }
    
    public User()
    {
        SubscriptionId = new SubscriptionId(0);
        FullName = new FullName("Default", "User");
        Email = new Email("default@example.com");
        Password = new Password(string.Empty);
        Address = new Address(string.Empty);
        City = string.Empty;
        Country = string.Empty;
        Type = UserType.CUSTOMER;
    }
    
    public int Id { get; init; } 
    public SubscriptionId SubscriptionId { get; private set; }
    public FullName FullName { get; private set; } 
    public Email Email { get; private set; }
    [JsonIgnore] 
    public Password Password { get; private set; }
    public long Phone { get; private set; }
    public Address Address { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; } 
    public bool IsVerified { get; private set; }
    public UserType Type { get; private set; } 
    
    
    public User UpdatePassword(Password newPassword) 
    {
        Password = newPassword;
        return this;
    }
    public User UpdateFullName(FullName newFullName)
    {
        FullName = newFullName;
        return this;
    }
}