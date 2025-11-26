namespace SmilingCup_Backend.Iam.Domain.Model.Commands;

public record SignUpCommand(
    int SubscriptionId, 
    string FullName, 
    string Email, 
    string Password, 
    long Phone, 
    string Address, 
    string City, 
    string Country, 
    bool IsVerified, // Mantenemos el campo del diagrama
    string Type);