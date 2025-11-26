namespace SmilingCup_Backend.Iam.Interfaces.REST.Resources;

public record SignUpResource(
    int SubscriptionId,
    string FullName,
    string Email,
    string Password,
    long Phone,
    string Address,
    string City,
    string Country,
    string Type 
);